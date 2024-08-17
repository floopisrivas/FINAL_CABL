using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        //private readonly List<Customer> _customers = new(); // Simulación de base de datos

        private readonly List<Customer> _customers = new()
        {
            new Customer { Id = 1, Name = "Florencia", Email = "floor@gmail.com" },
            new Customer { Id = 2, Name = "Juan", Email = "juan@example.com" },
            // Otros clientes...
        };

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await Task.FromResult(_customers.SingleOrDefault(c => c.Id == id));
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await Task.FromResult(_customers);
        }

        public async Task AddAsync(Customer customer)
        {
            // Generar un ID para el nuevo cliente (customer)
            customer.Id = _customers.Count > 0 ? _customers.Max(c => c.Id) + 1 : 1;

            // Agregar el cliente a la lista simulada
            _customers.Add(customer);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = _customers.SingleOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                _customers.Remove(existingCustomer);
                _customers.Add(customer);
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
            await Task.CompletedTask;
        }
    }


    ////private readonly List<Customer> _customers = new(); // Simulación de base de datos

    ////public async Task<Customer> GetByIdAsync(int id)
    ////{
    ////    return await Task.FromResult(_customers.SingleOrDefault(c => c.Id == id));
    ////}

    ////public async Task<IEnumerable<Customer>> GetAllAsync()
    ////{
    ////    return await Task.FromResult(_customers);
    ////}

    ////public async Task AddAsync(Customer customer)
    ////{
    ////    _customers.Add(customer);
    ////    await Task.CompletedTask;
    ////}

    ////public async Task UpdateAsync(Customer customer)
    ////{
    ////    var existingCustomer = _customers.SingleOrDefault(c => c.Id == customer.Id);
    ////    if (existingCustomer != null)
    ////    {
    ////        _customers.Remove(existingCustomer);
    ////        _customers.Add(customer);
    ////    }
    ////    await Task.CompletedTask;
    ////}

    ////public async Task DeleteAsync(int id)
    ////{
    ////    var customer = _customers.SingleOrDefault(c => c.Id == id);
    ////    if (customer != null)
    ////    {
    ////        _customers.Remove(customer);
    ////    }
    ////    await Task.CompletedTask;
    ////}

}

