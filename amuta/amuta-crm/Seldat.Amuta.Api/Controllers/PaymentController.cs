using Seldat.Amuta.Bl;
using Seldat.Amuta.BL;
using Seldat.Amuta.Dto;
using Seldat.Amuta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Seldat.Amuta.Api.Controllers
{
    [RoutePrefix("api/payment")]
    public class PaymentController : ApiController
    {
        
        [HttpGet]
        [Route("GetPayments/{from?}/{amount?}")]
        public HttpResponseMessage GetPayments([FromUri]int? from = null, [FromUri]int? amount = null)
        {
            try
            {
                StudentPayments studentPayments = StudentPaymentManager.GetPayments(from, amount);
                List<StudentPaymentDto> studentPaymentsDto = Converters.Convert(studentPayments);
                return Request.CreateResponse(HttpStatusCode.OK, studentPaymentsDto);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to load payment");
            }

        }


    }
}