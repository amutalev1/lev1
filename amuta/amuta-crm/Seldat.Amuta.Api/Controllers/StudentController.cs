using Seldat.Amuta.BL;
using Seldat.Amuta.Dto;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Seldat.Amuta.Api.Controllers
{

    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        [HttpPost]
        [Route("InsertPendingStudent/{branchId}/{studyPathId?}")]
        public HttpResponseMessage InsertPendingStudent([FromBody]StudentDto studentDto, [FromUri] int branchId,[FromUri] int? studyPathId = null)
        {
            try
            {
               
                Student student = Converters.Convert(studentDto);
                if (!ValidateModel.IsValid(new List<object>() { student }))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ValidateModel.ModelsResults);
                }
               
                StudentManager.InsertPendingStudent(student,branchId, studyPathId);
                return Request.CreateResponse(HttpStatusCode.OK, student.Id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to insert the pending student, {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Contain/{str?}")]
        public HttpResponseMessage Contains([FromUri]string str = "")
        {
            try
            {

                Students studs = StudentManager.Contains(Student.Includes.Address | Student.Includes.Bank | Student.Includes.Children, str);
                List<StudentDto> studentsDto = Converters.Convert(studs);
                return Request.CreateResponse(HttpStatusCode.OK, studentsDto);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to insert the  payment of student, {ex.Message}");
            }
        }

        [HttpPut]
        [Route("approvalRegistration")]
        public HttpResponseMessage ApprovalRegistration([FromBody]BranchStudentDto branchStudentDto)
        {
            try
            {
                //TODO not in that sprint-create login
                BranchStudent branchStudent = Converters.Convert(branchStudentDto);
                int update = StudentManager.ApprovalRegistration(branchStudent);
                return Request.CreateResponse(HttpStatusCode.OK, update);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to approve registration for the student in this Branch.");
            }
        }

        [HttpPut]
        [Route("updateStudent")]
        public HttpResponseMessage UpdateStudent([FromBody]StudentDto studentDto)
        {
            try
            {
                Student student = Converters.Convert(studentDto);
                if (!ValidateModel.IsValid(new List<object>() { student }))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ValidateModel.ModelsResults);
                }
                int update = StudentManager.UpdateStudent(student);
                return Request.CreateResponse(HttpStatusCode.OK, update);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to update student, studentId:{studentDto.Id}");
            }
        }

        [HttpGet]
        [Route("getStudents/{from?}/{amount?}")]
        public HttpResponseMessage GetStudents([FromUri]int? from = null, [FromUri]int? amount = null)
        {
            try
            {
                Students students = StudentManager.GetStudents(Student.Includes.Address|Student.Includes.Bank|Student.Includes.Children, from, amount);
                List<StudentDto> studentsDto = Converters.Convert(students);
                return Request.CreateResponse(HttpStatusCode.OK, studentsDto);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to load students");
            }
        }

        [HttpGet]
        [Route("getStudentsOfBranch/{branchId}/{from?}/{amount?}")]
        public HttpResponseMessage GetStudentsOfBranch([FromUri] int branchId,[FromUri]int? from = null, [FromUri]int? amount = null)
      {
            try
            {
                Students students = StudentManager.GetStudentsOfBranch(branchId,Student.Includes.All,from,amount);
                List<StudentDto> studentsDto = Converters.Convert(students);
                return Request.CreateResponse(HttpStatusCode.OK, studentsDto);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to load the students of this branch");
            }
        }
        [HttpGet]
        [Route("getPendingStudents")]
        public HttpResponseMessage GetPendingStudents()
        {
            try
            {
                Students students = StudentManager.GetPendingStudents(Student.Includes.Address | Student.Includes.Bank | Student.Includes.Children);
                List<StudentDto> studentsDto = Converters.Convert(students);
                return Request.CreateResponse(HttpStatusCode.OK, studentsDto);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to load pending students");
            }
        }
        [HttpGet]
        [Route("getStudent/{studentId}")]
        public HttpResponseMessage GetStudent([FromUri] int studentId)
        {
            try
            {
                Student student = StudentManager.GetStudent(studentId,Student.Includes.All);
                StudentDto studentDto = Converters.ConvertToDto(student);
                return Request.CreateResponse(HttpStatusCode.OK, studentDto);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to load student {studentId}");
            }
        }
        [HttpGet]
        [Route("getStudentByIdentityNumber/{studentIdentityNumber}")]
        public HttpResponseMessage GetStudentByIdentityNumber([FromUri] int studentIdentityNumber)
        {
            try
            {
                Student student = StudentManager.GetStudentByIdentityNumber(studentIdentityNumber, Student.Includes.All);
                StudentDto studentDto = Converters.ConvertToDto(student);
                return Request.CreateResponse(HttpStatusCode.OK, studentDto);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to load student {studentIdentityNumber}");
            }
        }
        [HttpGet]
        [Route("getPayment/{studentId}")]
        public HttpResponseMessage GetPayment([FromUri] int studentId)
        {
            try
            {
                //TODO-not in this sprint
                decimal payment = StudentManager.GetPayment(studentId);
                return Request.CreateResponse(HttpStatusCode.OK, payment);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to calculate student's payment,studentId: {studentId}.");
            }
        }

        [HttpDelete]
        [Route("setStudentInactive/{studentId}")]
        public HttpResponseMessage SetStudentInactive([FromUri] int studentId)
        {
            try
            {
                int update = StudentManager.SetStudentInactive(studentId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to set the student to inactive,studentId: {studentId}.");
            }
        }

        [HttpPut]
        [Route("setStudentActive/{studentId}")]
        public HttpResponseMessage SetStudentActive([FromUri] int studentId, [FromBody] int branchId)
        {
            try
            {
                int update = StudentManager.SetStudentActive(studentId, branchId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to set the student {studentId} to active.");
            }
        }

        [HttpDelete]
        [Route("setStudentInactiveInBranch/{studentId}/{branchId}")]
        public HttpResponseMessage SetStudentInactiveInBranch([FromUri] int studentId, [FromUri] int branchId)
        {
            try
            {
                int update = BranchStudentManager.SetStudentInactiveInBranch(studentId, branchId);
                return Request.CreateResponse(HttpStatusCode.OK, update);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to update student {studentId} to active in this branch");
            }
        }

        [HttpPut]
        [Route("setStudentActiveInBranch/{studentId}")]
        public HttpResponseMessage SetStudentActiveInBranch([FromUri] int studentId, [FromBody] int branchId)
        {
            try
            {
                int update = BranchStudentManager.SetStudentActiveInBranch(studentId, branchId);
                return Request.CreateResponse(HttpStatusCode.OK, update);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to update student to active in this branch");
            }
        }

        [HttpPost]
        [Route("InsertStudentPayment")]
        public HttpResponseMessage InsertStudentPayment([FromBody]StudentPaymentDto studentPaymentDto)
        {
            try
            {
                StudentPayment studentPayment = Converters.Convert(studentPaymentDto);
                if (!ValidateModel.IsValid(new List<object>() { studentPayment }))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ValidateModel.ModelsResults);
                }
                StudentManager.InsertStudentPayment(studentPayment);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Failed to insert the  payment of student, {ex.Message}");
            }
        }


    }
}

