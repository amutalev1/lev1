using Seldat.Amuta.BL;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Seldat.Amuta.Api.Controllers
{
    [RoutePrefix("api/institutionStudent")]
    public class StudentInstitutionController : ApiController
    {//change----------------------------------------------------------
        [HttpPut]
        [Route("UpdateStudentInstitution/{id}/{institutionId}")]
        public HttpResponseMessage TransferStudentInstitution([FromUri] int id, [FromUri] int institutionId)
        {
            try
            {
                int rowsAffected = BranchStudentManager.TransferStudentInstitution(id,institutionId);
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "failed to update student institution");
            }
        }
    }
}
