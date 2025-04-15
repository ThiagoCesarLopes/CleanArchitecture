


using CleanArchitecture.OrderManagement.Application.DTOs.Orders;
using CleanArchitecture.OrderManagement.Domain.Clients.Interfaces;
using CleanArchitecture.OrderManagement.Domain.Orders;
using CleanArchitecture.OrderManagement.Domain.Orders.Interfaces;
using CleanArchitecture.OrderManagement.Infrastructure.FeatureManager.Interfaces;

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

            var order = new Order(request.OrderId, request.ClienteId);

            foreach (var produtoId in request.ProdutosIds)
            {
                int produtoIdInt = produtoId.GetHashCode(); 
                order.AdicionarItem(produtoIdInt, 1, 0);
            }

            var usarNovaRegra = await _featureManager.IsEnabledAsync("NovaRegraImposto");
            order.CalcularImposto(usarNovaRegra);

            await _orderRepository.AddAsync(order);

            return new OrderResponse(order);
        }

        public async Task<OrderResponse?> GetOrderIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderIdAsync(id);
            return order == null ? null : new OrderResponse(order);
        }

        public async Task<IEnumerable<OrderResponse>> ListOrderStatusAsync(string status)
        {
            var orders = await _orderRepository.ListOrderStatusAsync(status);
            return orders.Select(p => new OrderResponse(p));
        }
    }

}
