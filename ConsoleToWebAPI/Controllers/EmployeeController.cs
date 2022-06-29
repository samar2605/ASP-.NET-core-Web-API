using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Route("{id}")]
        public string GetId(int id)
        {
            return "hello "+ id;
        }

        public List<EmployeeModel> GetList()
        {
            return new List<EmployeeModel>(){
                new EmployeeModel()
                {
                    Id=1,Name="John"
                },
                new EmployeeModel()
                {
                    Id=2, Name="David"
                }
            };
        }
        [Route("{id}")]
        public IActionResult GetEmployees(int id=0)
        {
            if(id == 0)
            {
                return NotFound();
            }
            return Ok(new List<EmployeeModel>(){
                new EmployeeModel()
                {
                    Id=1,Name="John"
                },
                new EmployeeModel()
                {
                    Id=2, Name="David"
                }
            });
        }

        [Route("{id}/basic")]
        public ActionResult<EmployeeModel> GetEmployeesbasic(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            return new EmployeeModel()
            {
                Id = 1,
                Name = "John"
            };
        }
    }
}
