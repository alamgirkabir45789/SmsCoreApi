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
    [Route("api/City")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IRepository<City> _repo;

        public CityController(IRepository<City> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetCities")]
        public async Task<IActionResult> Get()
        {
            var city = await _repo.Get();
            return Ok(city);
        }

        [HttpGet, Route("GetCity/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var city = await _repo.Get(id);
            if (city == null)
            {
                return Content("Can not find the city");
            }
            return Ok(city);
        }

        [HttpPost, Route("InsertCity")]
        public async Task<IActionResult> Post(City model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateCity/{id}")]
        public async Task<IActionResult> Put(int id, City model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteCity/{id}")]
        public async Task<IActionResult> Delete(int id, City model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The City you want to delete is not exist.");
        }
    }
}
