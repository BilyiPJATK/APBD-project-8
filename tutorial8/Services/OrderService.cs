using System.Collections.Generic;
using System.Threading.Tasks;
using tutorial8.Entities;
using tutorial8.Infrastructure;
using tutorial8.Infrastructure.Repositories.Abstractions;
using tutorial8.Services.Abstractions;

namespace tutorial8.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var connection = await _unitOfWork.GetConnectionAsync();
            var transaction = _unitOfWork.Transaction;

            return await _orderRepository.GetAllOrdersAsync(connection, transaction);
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            var connection = await _unitOfWork.GetConnectionAsync();
            var transaction = _unitOfWork.Transaction;

            return await _orderRepository.GetOrderByIdAsync(connection, transaction, orderId);
        }

        public async Task AddOrderAsync(Order order)
        {
            var connection = await _unitOfWork.GetConnectionAsync();
            var transaction = _unitOfWork.Transaction;

            await _orderRepository.InsertOrderAsync(connection, transaction, order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var connection = await _unitOfWork.GetConnectionAsync();
            var transaction = _unitOfWork.Transaction;

            await _orderRepository.UpdateOrderAsync(connection, transaction, order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var connection = await _unitOfWork.GetConnectionAsync();
            var transaction = _unitOfWork.Transaction;

            await _orderRepository.DeleteOrderAsync(connection, transaction, orderId);
        }

        public async Task<bool> IsOrderFulfilledAsync(int orderId)
        {
            var connection = await _unitOfWork.GetConnectionAsync();
            var transaction = _unitOfWork.Transaction;

            return await _orderRepository.IsOrderFulfilledAsync(connection, transaction, orderId);
        }
    }
}
