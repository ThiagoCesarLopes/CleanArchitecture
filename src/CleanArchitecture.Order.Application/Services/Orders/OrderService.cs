using CleanArchitecture.OrderManagement.Application.DTOs.Orders.Request;
using CleanArchitecture.OrderManagement.Application.DTOs.Orders.Response;
using CleanArchitecture.OrderManagement.Domain.Clients.Interfaces;
using CleanArchitecture.OrderManagement.Domain.Orders;
using CleanArchitecture.OrderManagement.Domain.Orders.Enum;
using CleanArchitecture.OrderManagement.Domain.Orders.Interfaces;
using CleanArchitecture.OrderManagement.Infrastructure.FeatureManagers.Interfaces;

namespace CleanArchitecture.OrderManagement.Application.Services.Orders
{

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IFeatureManager _featureManager;

        public OrderService(
            IOrderRepository orderRepository,
            IClientRepository clientRepository,
            IFeatureManager featureManager)
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _featureManager = featureManager;
       
        }

        public async Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            if (await _orderRepository.ExistOrderAsync(request.OrderId))
                throw new InvalidOperationException("order duplicado");

            var cliente = await _clientRepository.GetClientByIdAsync(request.ClienteId);
            if (cliente == null)
                throw new InvalidOperationException("Cliente não encontrado");

            var order = new Order(request.OrderId, request.ClienteId,request.Tax, request.Status);

            foreach (var item in request.Items)
            {
                order.AddItem(order.OrderId, item.ProductId,item.Amount,item.value);
            }

            var usarNovaRegra = await _featureManager.IsEnabledAsync("NewRuleTax");

            order.CalcularImposto(usarNovaRegra);

            await _orderRepository.AddAsync(order);

            var items = order.Items.Select(i => new OrderItemsResponse(i.OrderId, i.ProductId, i.Amount, i.Value)).ToList();
            
            var orderResponse = new OrderResponse(order.OrderId, order.ClientId, order.Tax, order.Status, items);           

            return orderResponse;
        }

        public async Task<OrderResponse?> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            var items = order.Items.Select(i => new OrderItemsResponse(i.OrderId, i.ProductId, i.Amount, i.Value)).ToList();

            return order == null ? null : new OrderResponse(order.OrderId,order.ClientId, order.Tax,order.Status, items);
        }

        public async Task<IEnumerable<OrderResponse>> ListOrderByStatusAsync(Status status)
        {
            var orders = await _orderRepository.ListOrderByStatusAsync(status);
            
            var ordersResponses = new List<OrderResponse>();

            foreach (var order in orders)
            {

                var items = order.Items.Select(i => new OrderItemsResponse(i.OrderId, i.ProductId, i.Amount, i.Value)).ToList();
                var orderResponse = new OrderResponse(order.OrderId, order.ClientId, order.Tax, order.Status, items);
       
                ordersResponses.Add(orderResponse);
            }
            return ordersResponses;
        }
    }

}
