using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {

            private readonly List<Order> _orders = new()
            {
                new Order { Id = 1, CustomerId = 1, OrderDate = DateTime.UtcNow, TotalAmount = 100 },
                new Order { Id = 2, CustomerId = 1, OrderDate = DateTime.UtcNow.AddDays(-1), TotalAmount = 50 },
                new Order { Id = 3, CustomerId = 2, OrderDate = DateTime.UtcNow.AddDays(-2), TotalAmount = 200 },
                // Agrega más pedidos aquí si es necesario
            };

            public async Task<Order> GetByIdAsync(int id)
            {
                return await Task.FromResult(_orders.SingleOrDefault(o => o.Id == id));
            }

            public async Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId)
            {
                return await Task.FromResult(_orders.Where(o => o.CustomerId == customerId));
            }

            public async Task AddAsync(Order order)
            {
                // Generar un ID para el nuevo pedido (order)
                order.Id = _orders.Count > 0 ? _orders.Max(o => o.Id) + 1 : 1;

                // Agregar el pedido a la lista simulada
                _orders.Add(order);

                await Task.CompletedTask;
            }

            public async Task UpdateAsync(Order order)
            {
                var existingOrder = _orders.SingleOrDefault(o => o.Id == order.Id);
                if (existingOrder != null)
                {
                    _orders.Remove(existingOrder);
                    _orders.Add(order);
                }
                await Task.CompletedTask;
            }

            public async Task DeleteAsync(int id)
            {
                var order = _orders.SingleOrDefault(o => o.Id == id);
                if (order != null)
                {
                    _orders.Remove(order);
                }
                await Task.CompletedTask;
            }
        }
    }

