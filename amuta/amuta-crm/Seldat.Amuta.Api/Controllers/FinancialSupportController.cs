using Seldat.Amuta.Bl;
using Seldat.Amuta.BL;
using Seldat.Amuta.Dto;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Seldat.Amuta.Api.Controllers
{
    [RoutePrefix("api/financialSupport")]
    public class FinancialSupportController : ApiController
    {
        [HttpPost]
        [Route("insertFinancialSupportRequest/{studentId}")]
        public HttpResponseMessage InsertFinancialSupportRequest([FromBody]FinancialSupportRequestDto financialSupportRequestDto, [FromUri] int studentId)
        {
            try
            {
                FinancialSupportRequest financialSupportRequest = Converters.Convert(financialSupportRequestDto);
                if (!ValidateModel.IsValid(new List<object>() { financialSupportRequest }))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ValidateModel.ModelsResults);
                }
                FinancialSupportManager.InsertFinancialSupportRequest(financialSupportRequest);

                return Request.CreateResponse(HttpStatusCode.OK, financialSupportRequest.Id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to insert the financial support request, {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetFinancialSupportRequests")]
        public HttpResponseMessage GetFinancialSupportRequests()
        {
            try
            {
                FinancialSupportRequests financialSupportRequests = FinancialSupportManager.GetFinancialSupportRequests();
                List<FinancialSupportRequestDto> financialSupportRequestsDto = Converters.Convert(financialSupportRequests);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to load students");
            }
        }
    }
}
