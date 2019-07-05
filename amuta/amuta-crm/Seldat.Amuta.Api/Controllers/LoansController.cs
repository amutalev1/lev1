using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Seldat.Amuta.Dto;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Validations;
using Seldat.Amuta.Dal;
using Seldat.Amuta.BL;
using Seldat.Amuta.Api;
using Seldat.Amuta.Bl;



namespace Seldat.Amuta.Api.Controllers
{
    [RoutePrefix("api/loans")]
    public class LoansController : ApiController
    {
        [HttpPost]
        [Route("InsertLoans")]
        public HttpResponseMessage InsertLoans([FromBody] LoansDto loanDto)
        {
            try
            {
                LoanSupportRequest loan = Converters.Convert(loanDto);
                if (!ValidateModel.IsValid(new List<object>() { loan }))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ValidateModel.ModelsResults);
                }
                LoanManager.InsertLoan(loan);
                return Request.CreateResponse(HttpStatusCode.OK, loan.Id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to insert the loan, {ex.Message}");
            }
        }

        //check?
        [HttpGet]
        [Route("GetLoans/{from?}/{amount?}")]
        public HttpResponseMessage GetLoans([FromUri]int? from = null, [FromUri]int? amount = null)
        {
            try
            {
                LoanSupportRequests loans = LoanManager.GetLoans(from, amount);
                List<LoansDto> loansDto = Converters.Convert(loans);
                return Request.CreateResponse(HttpStatusCode.OK, loansDto);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to load loans");
            }
        }




    }
}
