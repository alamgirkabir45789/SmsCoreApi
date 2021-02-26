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
    [Route("api/PaymentType")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeRepository _repo;
        public PaymentTypeController (IPaymentTypeRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetPaymentTypes")]
        public async Task<IActionResult> Get()
        {
            var paymentType = await _repo.Get();
            return Ok(paymentType);
        }

        [HttpGet,Route("GetPaymentType{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var paymentType = await _repo.Get(id);
            if (paymentType == null)
            {
                return Content("Can not find the paymentType");
            }
            return Ok(paymentType);
        }


        [HttpPost]
        [Route("InsertPaymentType")]
        public async Task<IActionResult> Post(PaymentType model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut,Route("UpdatePaymentType/{id}")]
        public async Task<IActionResult> Put(int id,PaymentType model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete,Route("DeletePaymentType/{id}")]
        public async Task<IActionResult> Delete(int id,PaymentType model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Payment Type you want to delete is not exit");
        }
    }
}
