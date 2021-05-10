using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Tarea3_DWB.NorthwindData;
using Tarea3_DWB.Models;

namespace Tarea3_DWB.BackEnd
{
    public class CustomerSC : BaseSC
    {
        public IQueryable<Customer> GetCustomers()
        {
            return dbContext.Customers.AsQueryable();
        }

        public Customer GetCustomersById(string Id)
        {
            var customer = GetCustomers().FirstOrDefault(f => f.CustomerId == Id);

            if(customer == null)
            {
                throw new Exception("No existe el cliente con ese ID");
            }

            return customer;
        }

        public void  AddCustomer(CustomerModel newCustomer)
        {
            var newCustomerRegister = new Customer()
            {
                CompanyName = newCustomer.Company,
                ContactName = newCustomer.CustomerName,
                Phone = newCustomer.Phone,
                
            };

            dbContext.Customers.Add(newCustomerRegister);
            dbContext.SaveChanges();
        }

        public void UpdateCustomer(string id, CustomerModel customerUpdate)
        {
            var currentCustomer = GetCustomersById(id);

            currentCustomer.ContactName = customerUpdate.CustomerName;
            currentCustomer.Phone = customerUpdate.Phone;
            currentCustomer.CompanyName = customerUpdate.Company;

            dbContext.SaveChanges();
        }

        public void DeleteCustomerById(string id)
        {
            var currentCustomer = GetCustomersById(id);

            dbContext.Customers.Remove(currentCustomer);
            dbContext.SaveChanges();

            
        }
    }
}
