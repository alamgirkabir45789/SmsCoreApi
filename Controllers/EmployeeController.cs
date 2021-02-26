using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsCoreApi.DAL.Interfaces;
using SmsCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _repo;

        public EmployeeController (IEmployeeRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult>Get()
        {
            var employees = await _repo.Get();
            return Ok(employees);

        }

        [HttpGet, Route("GetEmployee/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _repo.Get(id);
            if (employee == null)
            {
                return Content("Can not find the employee");
            }
            return Ok(employee);
        }

        [HttpPost]
        [Route("InsertEmployee")]
        public async Task<IActionResult> Post(Employee model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut,Route("UpdateEmployee/{id}")]
        public async Task<IActionResult> Put(int id,Employee model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete,Route("DeleteEmployee/{id}")]
        public async Task<IActionResult> Delete(int id, Employee model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Employee you want to delete is not exit.");
        }
    }
}
