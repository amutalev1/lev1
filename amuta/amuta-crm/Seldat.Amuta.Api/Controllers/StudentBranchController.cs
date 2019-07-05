using Seldat.Amuta.BL;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Seldat.Amuta.Dto;
using Seldat.Amuta.Api;
using Seldat.Amuta.Api.Controllers;

namespace Seldat.Amuta.Api.Controllers
{
    [RoutePrefix("api/branchStudent")]
    public class StudentBranchController : ApiController
    {
        [HttpPost]
        [Route("RequestRegistrationBranchStudent")]
        public HttpResponseMessage RequestRegistrationBranchStudent([FromBody] BranchStudentDto branchStudentDto)
        {
            //private StudentController db = new StudentController();
            try
            {
                BranchStudent branchStud = Converters.Convert(branchStudentDto);
                if (!ValidateModel.IsValid(new List<object>() { branchStud }))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ValidateModel.ModelsResults);
                }
                Students s = StudentManager.GetStudents(Student.Includes.Address | Student.Includes.Bank | Student.Includes.Children, null, null);
                int f = 0;
                //foreach (var item in s.students)
                //{   
                //    if (item.IdentityNumber == branchStud.Student.IdentityNumber)
                //    {
                //        branchStud.Student.Id = item.Id;
                //        f = 1;
                //    }
                //}
                //if(f==0)
                //    return Request.CreateResponse(HttpStatusCode.BadRequest);
                BranchStudentManager.RequestRregistration(branchStud);
                return Request.CreateResponse(HttpStatusCode.OK, branchStud.Id);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to insert the student to branch, {ex.Message}");
            }
        }
    }
}
