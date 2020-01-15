using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServiceExample.Models;

namespace WebServiceExample.Services
{
    public class DataService : IDataService
    {
        private readonly BlockingCollection<Employee> _lstEmployee = new BlockingCollection<Employee>();
        
        public DataService()
        {
            var employee1 = new Employee
            {
                Id = 1, FirstName = "John", LastName = "Smith", Address = "123 Lemon Street"
            };
            _lstEmployee.Add(employee1);

            var employee2 = new Employee
            {
                Id = 2, FirstName = "Tom", LastName = "Jerry", Address = "123 Pepper Street"
            };
            _lstEmployee.Add(employee2);
        }
        
        public async Task<List<Employee>> Get()
        {
            if (_lstEmployee.Count > 0)
                return await Task.Run(()=> _lstEmployee.ToList());
            return null;
        }
        
        public async Task<Employee> GetById(int id)
        {
            foreach (var emp in _lstEmployee)
            {
                if (emp.Id == id)
                    return await Task.Run( ()=> emp);
            }
            return null;
        }

        public async Task<Employee> Post(Employee employee)
        {
            _lstEmployee.Add(employee);
            return await Task.Run( ()=> employee);;
        }
    }
}