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
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _repo;

        public PaymentController(IPaymentRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetPayments")]
        public async Task<IActionResult> Get()
        {
            var payment = await _repo.Get();
            return Ok(payment);
        }

        [HttpGet, Route("GetPayment/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var payment = await _repo.Get(id);
            if (payment == null)
            {
                return Content("Can not find the payment");
            }
            return Ok(payment);
        }

        [HttpPost]
        [Route("InsertPayment")]
        public async Task<IActionResult> Post(Payment model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdatePayment/{id}")]
        public async Task<IActionResult> Put(int id, Payment model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeletePayment/{id}")]
        public async Task<IActionResult> Delete(int id, Payment model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Payment you want to delete is not exist.");
        }
    }
}

