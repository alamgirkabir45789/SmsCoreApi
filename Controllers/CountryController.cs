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
    [Route("api/Country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _repo;

        public CountryController(ICountryRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetCountries")]
        public async Task<IActionResult> Get()
        {
            var country = await _repo.Get();
            return Ok(country);
        }

        [HttpGet, Route("GetCountry/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var country = await _repo.Get(id);
            if (country == null)
            {
                return Content("Can not find the country");
            }
            return Ok(country);
        }

        [HttpPost]
        [Route("InsertCountry")]
        public async Task<IActionResult> Post(Country model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateCountry/{id}")]
        public async Task<IActionResult> Put(int id, Country model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteCountry/{id}")]
        public async Task<IActionResult> Delete(int id, Country model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Country you want to delete is not exist.");
        }
    }
}
