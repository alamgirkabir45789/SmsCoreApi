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
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repo;

        public TeacherController(ITeacherRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetTeachers")]
        public async Task<IActionResult> Get()
        {
            var teacher = await _repo.Get();
            return Ok(teacher);
        }

        [HttpGet, Route("GetTeacher/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var teacher = await _repo.Get(id);
            if (teacher == null)
            {
                return Content("Can not find the teacher");
            }
            return Ok(teacher);
        }

        [HttpPost]
        [Route("InsertTeacher")]
        public async Task<IActionResult> Post(Teacher model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateTeacher/{id}")]
        public async Task<IActionResult> Put(int id, Teacher model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteTeacher/{id}")]
        public async Task<IActionResult> Delete(int id, Teacher model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Teacher you want to delete is not exist.");
        }
    }
}
