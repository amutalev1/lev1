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
    [RoutePrefix("api/branch")]
    public class BranchController : ApiController
    {     
        [HttpGet]
        [Route("GetBranches/{typeId}")]
        public HttpResponseMessage GetBranches([FromUri] int typeId)
        {
            try
            {
                Branches branchs = BranchManager.GetBranchesBasicDetails(typeId,Branch.Includes.Address | Branch.Includes.BranchType|Branch.Includes.UserExtraDetails|Branch.Includes.ActivityHours | Branch.Includes.Rules | Branch.Includes.Institution|Branch.Includes.Scolarship);
                List<BranchDto> branchsDto = Converters.Convert(branchs);
                return Request.CreateResponse(HttpStatusCode.OK, branchsDto);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to get branchs {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Contain/{str}")]
        public HttpResponseMessage Contains([FromUri]string str = "")
        {
            try
            {

                Branches bra = BranchManager.Contains(Branch.Includes.Address, str);
                List<BranchDto> branchesDto = Converters.Convert(bra);
                return Request.CreateResponse(HttpStatusCode.OK, branchesDto);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to search branch, {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetBranch/{branchId}")]
        public HttpResponseMessage GetBranch([FromUri] int branchId)
        {
            try
            {
                Branch branch = BranchManager.GetBranch(branchId,Branch.Includes.Address| Branch.Includes.BranchType| Branch.Includes.ActivityHours|Branch.Includes.Rules|Branch.Includes.Institution);
                BranchDto branchDto = Converters.Convert(branch);
                return Request.CreateResponse(HttpStatusCode.OK, branchDto);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to get branch {branchId},{ex.Message}");
            }
        }
        [HttpPost]
        [Route("InsertBranch")]
        public HttpResponseMessage InsertBranch([FromBody]BranchDto branchDto)
        {
            try
            {
                Branch branch = Converters.Convert(branchDto);
                if (!ValidateModel.IsValid(new List<object>() { branch }))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ValidateModel.ModelsResults);
                }
                int rowsAffected = BranchManager.Insert(branch);
                return Request.CreateResponse(HttpStatusCode.Created, rowsAffected);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to insert branch {ex.Message}");
            }
        }
        [HttpPut]
        [Route("UpdateBranch")]
        public HttpResponseMessage UpdateBranch([FromBody]BranchDto branchDto)
        {
            try
            {
                Branch branch = Converters.Convert(branchDto);
                if (!ValidateModel.IsValid(new List<object>() { branch }))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ValidateModel.ModelsResults);
                }
                int rowsAffected = BranchManager.Update(branch);
                return Request.CreateResponse(HttpStatusCode.Created, rowsAffected);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to update branch {ex.Message}");
            }

        }
        [HttpPut]
        [Route("MakeBranchInactive")]
        public HttpResponseMessage MakeBranchInactive([FromBody] int id)
        {
            try
            {

                int rowsAffected = BranchManager.MakeBranchInactive(id);
                return Request.CreateResponse(HttpStatusCode.Created, rowsAffected);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to delete branch {id} {ex.Message}");
            }

        }
        [HttpPut]
        [Route("IncreaseNumberOfStudents")]
        public HttpResponseMessage IncreaseNumberOfStudents([FromBody] int branchId)
        {
            try
            {
                int rowsAffected = BranchManager.IncreaseNumberOfStudents(branchId);
                return Request.CreateResponse(HttpStatusCode.Created, rowsAffected);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to get branch {branchId},{ex.Message}");
            }
        }



        [HttpPut]
        [Route("ReduceNumberOfStudents")]
        public HttpResponseMessage ReduceNumberOfStudents([FromBody] int branchId)
        {
            try
            {
                int rowsAffected = BranchManager.ReduceNumberOfStudents(branchId);
                return Request.CreateResponse(HttpStatusCode.Created, rowsAffected);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to get branch {branchId},{ex.Message}");
            }
        }
        [HttpPut]
        [Route("MakeBranchActive")]
        public HttpResponseMessage MakeBranchActive([FromBody] int id)
        {
            try
            {
                int rowsAffected = BranchManager.MakeBranchActive(id);
                return Request.CreateResponse(HttpStatusCode.Created, rowsAffected);
            }
            catch (Exception)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to update branch to not active {id}");
            }

        }

        [HttpGet]
        [Route("GetBranchExamsBybranchId/{id}")]
        public HttpResponseMessage GetBranchExamsBybranchId([FromUri] int id)
        {
            try
            {
                List<BranchExam> ListBranchExamByBranchId = new List<BranchExam>();
                ListBranchExamByBranchId = BranchExamsManager.GetBranchExamsBybranchId(id);
                return Request.CreateResponse(HttpStatusCode.Created, ListBranchExamByBranchId);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to get GetBranchExamsBybranchId {id}");
            }
        }

        [HttpGet]
        [Route("GetExams")]
        public HttpResponseMessage GetExams()
        {
            try
            {
                List<BranchExam> ListExams = new List<BranchExam>();
                ListExams = BranchExamsManager.GetExams();
                return Request.CreateResponse(HttpStatusCode.Created, ListExams);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to get exams");
            }
        }

        [HttpGet]
        [Route("GetBranchsActivityHoursByBranch/{id}")]
        public HttpResponseMessage GetBranchsActivityHoursByBranch([FromUri] int id)
        {
            try
            {
                List<BranchActivityHours> ListBranchExamByBranchId = new List<BranchActivityHours>();
                ListBranchExamByBranchId = BranchActivityHoursManager.GetBranchsActivityHoursByBranch(id);
                return Request.CreateResponse(HttpStatusCode.Created, ListBranchExamByBranchId);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to get GetBranchExamsBybranchId {id}");
            }
        }

        [HttpPut]
        [Route("Delete")]
        public HttpResponseMessage Delete([FromBody]Branch[] branches)
        {
            try
            {
                int rowsAffected = BranchManager.Delete(branches);
                return Request.CreateResponse(HttpStatusCode.Created, rowsAffected);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"failed to delete branch {ex.Message}");
            }
        }

    }
}
