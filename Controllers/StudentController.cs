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
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetStudents")]
        public async Task<IActionResult> Get()
        {
            var students = await _repo.Get();
            return Ok(students);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var students = await _repo.Get(id);
            if (students == null)
            {
                return Content("Can not find the Student");
            }
            return Ok(students);
        }

        [HttpPost]
        [Route("InsertStudent")]
        public async Task<IActionResult> Post(Student model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut]
        [Route("UpdateStudent/{id}")]
        public async Task<IActionResult> Put(int id, Student model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete] 
        [ Route("DeleteStudent/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return RedirectToRoute("GetStudents");
            }
            return Content("The Student you want to delete is not exit.");
        }
    }
}
