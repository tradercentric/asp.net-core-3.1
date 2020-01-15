using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;
using WebServiceExample.Models;

namespace WebServiceExample.Services
{
    public interface IDataService
    {
        Task<List<Employee>> Get();
        Task<Employee> GetById(int id);

        Task<Employee> Post(Employee employee);
    } 
}