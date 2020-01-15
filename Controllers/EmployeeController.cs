using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServiceExample.Models;
using WebServiceExample.Services;

namespace WebServiceExample.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataService _dataService;
        
        public EmployeeController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var records = await _dataService.Get();
            
            if(records !=null)
                if(records.Count > 0)
                    return Ok(records);
            return NotFound();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _dataService.GetById(id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpPost]
        public async Task <IActionResult> Put(Employee employee)
        {
            var data = await _dataService.Post(employee);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
    }
}