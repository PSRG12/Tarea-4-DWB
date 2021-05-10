using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea3_DWB.BackEnd;
using Tarea3_DWB.NorthwindData;
using Tarea3_DWB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestNortwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            var employee = new EmployeesSC().GetEmployees().ToList();

            return employee;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return new EmployeesSC().GetEmployeeById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] EmployeeModel newEmployee)
        {
            new EmployeesSC().AddEmployee(newEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeModel newEmployee)
        {
            new EmployeesSC().UpdateEmployeeById(id);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new EmployeesSC().DeleteEmployeeById(id);
        }
    }
}
