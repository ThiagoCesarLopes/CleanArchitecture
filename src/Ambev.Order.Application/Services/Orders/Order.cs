


using CleanArchitecture.OrderManagement.Application.DTOs.Orders;
using CleanArchitecture.OrderManagement.Domain.Clientes.Interfaces;
using CleanArchitecture.OrderManagement.Domain.Orders;
using CleanArchitecture.OrderManagement.Domain.Orders.Interfaces;

namespace CleanArchitecture.OrderManagement.Application.Services.Orders
{

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFeatureManager _featureManager;

        public OrderService(
            IOrderRepository orderRepository,
            IClienteRepository clienteRepository,
            IFeatureManager featureManager)
        {
            _orderRepository = orderRepository;
            _clienteRepository = clienteRepository;
            _featureManager = featureManager;
       
        }

        public async Task<OrderResponse> CriarOrderAsync(CriarOrderRequest request)
        {
            if (await _orderRepository.ExisteOrderAsync(request.orderId))
                throw new InvalidOperationException("order duplicado");

            var cliente = await _clienteRepository.ObterPorIdAsync(request.ClienteId);
            if (cliente == null)
                throw new InvalidOperationException("Cliente não encontrado");

            var order = new Order(request.orderId, request.ClienteId);
            foreach (var item in request.Itens)
            {
                order.AdicionarItem(item.ProdutoId, item.Quantidade, item.Valor);
            }

            var usarNovaRegra = await _featureManager.IsEnabledAsync("NovaRegraImposto");
            order.CalcularImposto(usarNovaRegra);

            await _orderRepository.AdicionarAsync(order);

            return new OrderResponse(order);
        }

        public async Task<OrderResponse?> ObterPorIdAsync(int id)
        {
            var order = await _orderRepository.ObterPorIdAsync(id);
            return order == null ? null : new OrderResponse(order);
        }

        public async Task<IEnumerable<OrderResponse>> ListarPorStatusAsync(string status)
        {
            var orders = await _orderRepository.ListarPorStatusAsync(status);
            return orders.Select(p => new OrderResponse(p));
        }
    }

}
