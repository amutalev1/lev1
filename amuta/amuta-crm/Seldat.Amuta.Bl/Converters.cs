using Seldat.Amuta.Dto;
using Seldat.Amuta.Entities;
using System;
using System.Collections.Generic;

namespace Seldat.Amuta.BL
{
    public class Converters
    {
        public static Student Convert(StudentDto studentDto)
        {
            return new Student()
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                AccountNumber = studentDto.AccountNumber,
                Bank = studentDto.Bank,
                Address =studentDto.Address,
                BornDate = studentDto.BornDate,
                PhoneNumber = studentDto.PhoneNumber,
                CellphoneNumber = studentDto.CellphoneNumber != null ? studentDto.CellphoneNumber : null,
                ChildrenNumber = studentDto.ChildrenNumber != null ? studentDto.ChildrenNumber : null,
                FaxNumber = studentDto.FaxNumber != null ? studentDto.FaxNumber : null,
                IdCard = studentDto.IdCard,
                IdentityNumber = studentDto.IdentityNumber,
                Image = studentDto.Image,
                JobWife = studentDto.JobWife != null ? studentDto.JobWife : null,
                MarriedChildrenNumber = studentDto.MarriedChildrenNumber != null ? studentDto.MarriedChildrenNumber : null,
                MonthlyIncome = studentDto.MonthlyIncome != null ? studentDto.MonthlyIncome : null,
                Id = studentDto.Id,
                TravelExpenses = studentDto.TravelExpenses != null ? studentDto.TravelExpenses : null,
                WifeName = studentDto.WifeName != null ? studentDto.WifeName : null,
                StudentChildren = studentDto.StudentChildren != null ? studentDto.StudentChildren : null,
                StudentBranches = studentDto.StudentBranches != null ?studentDto.StudentBranches : null
            };
        }

       

        public static StudentDto ConvertToDto(Student student)
        {
            if (student == null)
                return null;
            return new StudentDto()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                AccountNumber = student.AccountNumber,
                Bank = student.Bank ,
                Address = student.Address,
                BornDate = student.BornDate,
                PhoneNumber = student.PhoneNumber,
                CellphoneNumber = student.CellphoneNumber ,
                ChildrenNumber =student.ChildrenNumber,
                FaxNumber =student.FaxNumber,
                IdCard = student.IdCard,
                IdentityNumber = student.IdentityNumber,
                Image = student.Image,
                JobWife =student.JobWife,
                MarriedChildrenNumber = student.MarriedChildrenNumber,
                MonthlyIncome = student.MonthlyIncome,
                Id = student.Id,
                TravelExpenses = student.TravelExpenses,
                WifeName = student.WifeName,
                StudentChildren =  student.StudentChildren,
                StudentBranches =student.StudentBranches,
                IsActive=student.IsActive
            };
        }

        public static List<StudentDto> Convert(Students students)
        {
            if (students != null)
            {
                List<StudentDto> studentsDto = new List<StudentDto>();
                foreach (Student student in students)
                {
                    StudentDto item = ConvertToDto(student);
                    studentsDto.Add(item);
                }
                return studentsDto;
            }
            return null;

        }
        public static List<BranchStudentDto> Convert(BranchesStudents studentBranches)
        {
            if (studentBranches != null)
            {
                List<BranchStudentDto> studentBranchDto = new List<BranchStudentDto>();
                foreach (BranchStudent studentBranch in studentBranches)
                {
                    BranchStudentDto item = Convert(studentBranch);
                    studentBranchDto.Add(item);
                }
                return studentBranchDto;
            }
            return null;
        }
        public static BranchStudentDto Convert(BranchStudent studentBranch)
        {
            if (studentBranch == null)
                return null;
            return new BranchStudentDto()
            {
                Id = studentBranch.Id,
                Student=new Student() { Id = studentBranch.Student.Id },
                Branch = studentBranch.Branch,
                EntryHebrewDate = studentBranch.EntryHebrewDate,
                EntryGregorianDate = studentBranch.EntryGregorianDate,
                ReleaseGregorianDate = studentBranch.ReleaseGregorianDate,
                ReleaseHebrewDate = studentBranch.ReleaseHebrewDate,
                IsActive = studentBranch.IsActive,
                Status=studentBranch.Status,
                StudyPath =studentBranch.StudyPath,
              
            };
        }

        public static BranchesStudents Convert(List<BranchStudentDto> studentBranchsDto)
        {
            if (studentBranchsDto != null)
            {
                BranchesStudents studentsBranchs = new BranchesStudents();
                foreach (BranchStudentDto studentBranch in studentBranchsDto)
                {
                    BranchStudent item = Convert(studentBranch);
                    studentsBranchs.Add(item);
                }
                return studentsBranchs;
            }
            return null;
        }

        public static BranchStudent Convert(BranchStudentDto studentBranchDto)
        {
            if (studentBranchDto == null)
                return null;
            int Id;
            Student Student;
            Branch Branch;
            DateTime EntryHebrewDate, EntryGregorianDate, ReleaseGregorianDate, ReleaseHebrewDate;
            bool IsActive;

            Id = studentBranchDto.Id;
            Student = new Student() { Id = 1 };
            Branch = studentBranchDto.Branch;
            EntryHebrewDate = studentBranchDto.EntryHebrewDate;
            EntryGregorianDate = studentBranchDto.EntryGregorianDate;
            ReleaseGregorianDate = studentBranchDto.ReleaseGregorianDate;
            ReleaseHebrewDate = studentBranchDto.ReleaseHebrewDate;
            IsActive = studentBranchDto.IsActive;

               // Status = (StatusInBranch)Enum.Parse(typeof(StatusInBranch), studentBranchDto.Status.ToString()),
               // StudyPath = studentBranchDto.StudyPath
            return new BranchStudent()
            {
                Id = studentBranchDto.Id,
                Student = new Student() { Id = studentBranchDto.Student.Id, IdentityNumber= studentBranchDto.Student.IdentityNumber },
                Branch = new Branch() { Id = studentBranchDto.Branch.Id },
                EntryHebrewDate = studentBranchDto.EntryHebrewDate,
                EntryGregorianDate = studentBranchDto.EntryGregorianDate,
                ReleaseGregorianDate = studentBranchDto.ReleaseGregorianDate,
                ReleaseHebrewDate = studentBranchDto.ReleaseHebrewDate,
                IsActive = studentBranchDto.IsActive,
                Status =(StatusInBranch)Enum.Parse(typeof(StatusInBranch),studentBranchDto.Status.ToString()),
                StudyPath=studentBranchDto.StudyPath
            };
        }

        //public static List<StudentChildrenDto> Convert(List<StudentChildren> studentChildren)
        //{
        //    if (studentChildren != null)
        //    {
        //        List<StudentChildrenDto> studentChildrenDto = new List<StudentChildrenDto>();
        //        foreach (StudentChildren child in studentChildren)
        //        {
        //            StudentChildrenDto item = Convert(child);
        //            studentChildrenDto.Add(item);
        //        }
        //        return studentChildrenDto;
        //    }
        //    return null;
        //}
        //public static List<StudentChildren> Convert(List<StudentChildrenDto> studentChildrenDto)
        //{
        //    if (studentChildrenDto != null)
        //    {
        //        List<StudentChildren> studentChildren = new List<StudentChildren>();
        //        foreach (StudentChildrenDto child in studentChildrenDto)
        //        {
        //            StudentChildren item = Convert(child);
        //            studentChildren.Add(item);
        //        }
        //        return studentChildren;
        //    }
        //    return null;
        //}
        //public static StudentChildrenDto Convert(StudentChildren child)
        //{
        //    if (child == null)
        //        return null;
        //    return new StudentChildrenDto()
        //    {
        //        Id = child.Id,
        //        StudentId = child.Student.Id,
        //        FirstName = child.FirstName,
        //        LastName = child.LastName,
        //        Gender = child.Gender,
        //        Age = child.Age,
        //        Status = child.Status
        //    };
        //}
        //public static StudentChildren Convert(StudentChildrenDto childDto)
        //{
        //    if (childDto == null)
        //        return null;
        //    return new StudentChildren()
        //    {
        //        Id = childDto.Id,
        //        Student = new Student() { Id = childDto.StudentId },
        //        FirstName = childDto.FirstName,
        //        LastName = childDto.LastName,
        //        Gender = childDto.Gender,
        //        Age = childDto.Age,
        //        Status = childDto.Status
        //    };
        //}
        
        public static BranchActivityHours Convert(BranchActivityHoursDto branchActivityHoursDto)
        {
            if (branchActivityHoursDto == null)
                return null;
            return new BranchActivityHours()
            {
                Id = branchActivityHoursDto.Id,
                EndStudyHours = branchActivityHoursDto.EndStudyHours,
                Branch = new Branch() { Id = branchActivityHoursDto.BranchId },
                LateHour = branchActivityHoursDto.LateHour,
                StartStudyHours = branchActivityHoursDto.StartStudyHours
            };
        }
        public static StudentPayment Convert(StudentPaymentDto studentPaymentDto)
        {
            if (studentPaymentDto == null)
                return null;
            return new StudentPayment()
            {
                AttendanceSum = studentPaymentDto.AttendanceSum,
                DentalHealthSupportSum = studentPaymentDto.DentalHealthSupportSum,
                ExamsSum = studentPaymentDto.ExamsSum,
                FinancialSupportSum = studentPaymentDto.FinancialSupportSum,
                HealthSupportSum = studentPaymentDto.HealthSupportSum,
                LoansGivenSum = studentPaymentDto.LoansGivenSum,
                LoansReturnSum = studentPaymentDto.LoansReturnSum,
                Month = studentPaymentDto.Month,
                PaymentSum = studentPaymentDto.PaymentSum,
                StateBudgetSum = studentPaymentDto.StateBudgetSum,
                Year = studentPaymentDto.Year,
                Student = studentPaymentDto.Student

            };
        }
        //public static BranchActivityHoursDto Convert(BranchActivityHours branchActivityHours)
        //{
        //    if (branchActivityHours == null)
        //        return null;
        //    return new BranchActivityHoursDto()
        //    {
        //        Id = branchActivityHours.Id,
        //        EndStudyHours = branchActivityHours.EndStudyHours,
        //        StartStudyHours = branchActivityHours.StartStudyHours,
        //        LateHour = branchActivityHours.LateHour,
        //        BranchId = branchActivityHours.Branch.Id
        //    };
        //}
        //public static List<BranchActivityHoursDto> Convert(List<BranchActivityHours> branchActivityHours)
        //{
        //    if (branchActivityHours != null)
        //    {
        //        List<BranchActivityHoursDto> branchActivityHoursDto = new List<BranchActivityHoursDto>();
        //        foreach (BranchActivityHours branchActivityHour in branchActivityHours)
        //        {
        //            BranchActivityHoursDto item = Convert(branchActivityHour);
        //            branchActivityHoursDto.Add(item);
        //        }
        //        return branchActivityHoursDto;
        //    }
        //    return null;
        //}
        public static List<BranchActivityHours> Convert(List<BranchActivityHoursDto> branchActivityHoursDto)
        {
            if (branchActivityHoursDto != null)
            {
                List<BranchActivityHours> branchActivityHours = new List<BranchActivityHours>();
                foreach (BranchActivityHoursDto branchActivityHourDto in branchActivityHoursDto)
                {
                    BranchActivityHours item = Convert(branchActivityHourDto);
                    branchActivityHours.Add(item);
                }
                return branchActivityHours;
            }
            return null;
        }

        public static Branch Convert(BranchDto branchDto)
        {
            if (branchDto == null)
                return null;
            return new Branch()
            {
                Id = branchDto.Id,
                ActivityHours = branchDto.ActivityHours,
                Address = branchDto.Address,
                Image = branchDto.Image,
                ExamRules = branchDto.ExamRules,
                AttendanceRules = branchDto.AttendanceRules,
                IsActive = branchDto.IsActive,
                Name = branchDto.Name,
                OpeningDate = branchDto.OpeningDate,
                StudentsNumber = branchDto.StudentsNumber,
                StudySubjects = branchDto.StudySubjects,
                Type = branchDto.Type,
                Institution = branchDto.Institution,
                Head=branchDto.Head
            };
        }
        public static BranchDto Convert(Branch branch)
        {
            if (branch == null)
                return null;
            return new BranchDto()
            {
                Id = branch.Id,
                ActivityHours = branch.ActivityHours,
                Address = branch.Address,
                Image = branch.Image,
                AttendanceRules = branch.AttendanceRules,
                ExamRules = branch.ExamRules,
                IsActive = branch.IsActive,
                Name = branch.Name,
                OpeningDate = branch.OpeningDate,
                StudentsNumber = branch.StudentsNumber,
                StudySubjects = branch.StudySubjects,
                Type =branch.Type,
                Institution = branch.Institution,
                Head = branch.Head,
               
            };
        }
        public static List<BranchDto> Convert(Branches branchs)
        {
            if (branchs != null)
            {
                List<BranchDto> branchsDto = new List<BranchDto>();
                foreach (Branch branch in branchs)
                {
                    BranchDto item = Convert(branch);
                    branchsDto.Add(item);
                }
                return branchsDto;
            }
            return null;
        }
        public static Branches Convert(List<BranchDto> branchsDto)
        {
            if (branchsDto != null)
            {
                Branches branchs = new Branches();
                foreach (BranchDto branchDto in branchsDto)
                {
                    Branch item = Convert(branchDto);
                    branchs.Add(item);
                }
                return branchs;
            }
            return null;
        }
        public static UserExtraDetails Convert(UserExtraDetailsDto userExtraDetailsDto)
        {
            if (userExtraDetailsDto == null)
                return null;
            return new UserExtraDetails()
            {
                Identitynumber = userExtraDetailsDto.Identitynumber,
                Address = userExtraDetailsDto.Address,
                Image = userExtraDetailsDto.Image,
                CellphoneNumber = userExtraDetailsDto.CellphoneNumber,
                FirstName = userExtraDetailsDto.PhoneNumber,
                LastName = userExtraDetailsDto.LastName
            };
        }
        public static UserExtraDetailsDto Convert(UserExtraDetails userExtraDetails)
        {
            if (userExtraDetails == null)
                return null;
            return new UserExtraDetailsDto()
            {
                Identitynumber = userExtraDetails.Identitynumber,
                Address = userExtraDetails.Address,
                Image = userExtraDetails.Image,
                CellphoneNumber = userExtraDetails.CellphoneNumber,
                FirstName = userExtraDetails.PhoneNumber,
                LastName = userExtraDetails.LastName
            };
        }

        //#region Helpers
        //public static Address DtoToAddress(AddressDto addressDto)
        //{
        //    if (addressDto == null)
        //        return null;
        //    return new Address()
        //    {
        //        Id = addressDto.Id,
        //        Country = addressDto.Country,
        //        City = DtoToCity(addressDto.City),
        //        Street = DtoToStreet(addressDto.Street),
        //        NeighborhoodName = addressDto.NeighborhoodName,
        //        HouseNumber = addressDto.HouseNumber,
        //        ApartmentNumber = addressDto.ApartmentNumber,
        //        ZipCode = addressDto.ZipCode
        //    };
        //}
        //public static AddressDto AddressToDto(Address address)
        //{
        //    if (address == null)
        //        return null;
        //    return new AddressDto()
        //    {
        //        Id = address.Id,
        //        Country = address.Country,
        //        City = CityToDto(address.City),
        //        Street = StreetToDto(address.Street),
        //        NeighborhoodName = address.NeighborhoodName,
        //        HouseNumber = address.HouseNumber,
        //        ApartmentNumber = address.ApartmentNumber,
        //        ZipCode = address.ZipCode
        //    };
        //}
        //public static City DtoToCity(CityDto cityDto)
        //{
        //    if (cityDto == null)
        //        return null;
        //    return new City()
        //    {
        //        Id = cityDto.Id,
        //        Name = cityDto.Name,
        //    };
        //}
        //public static CityDto CityToDto(City city)
        //{
        //    if (city == null)
        //        return null;
        //    return new CityDto()
        //    {
        //        Id = city.Id,
        //        Name = city.Name,
        //    };
        //}
        //public static Street DtoToStreet(StreetDto streetDto)
        //{
        //    if (streetDto == null)
        //        return null;
        //    return new Street()
        //    {
        //        Id = streetDto.Id,
        //        Name = streetDto.Name,
        //    };
        //}
        //public static StreetDto StreetToDto(Street street)
        //{
        //    if (street == null)
        //        return null;
        //    return new StreetDto()
        //    {
        //        Id = street.Id,
        //        Name = street.Name,
        //    };
        //}

        //#endregion

        public static LoanSupportRequest Convert(LoansDto loansDto)
        {

            return new LoanSupportRequest()
            {
                Details = loansDto.Details,
                AmountRequested= loansDto.AmountRequested,
                AmountRepaymentMonthly= loansDto.AmountRepaymentMonthly,
                branch= loansDto.branch,
                ApprovedAmount= loansDto.ApprovedAmount,
                CurrentStatus= loansDto.CurrentStatus,
                Date= loansDto.Date,
                DateReturningEntireAmount= loansDto.DateReturningEntireAmount,
                DigitalSignature= loansDto.DigitalSignature,
                Id= loansDto.Id,
                IsApproved= loansDto.IsApproved,
                Iscanceled= loansDto.Iscanceled,
                IsDisapprovedClosedRequest= loansDto.IsDisapprovedClosedRequest,
                LoanGuarantors= loansDto.LoanGuarantors,
                NumberApprovedMonths= loansDto.NumberApprovedMonths,
                ReasonIsApproved= loansDto.ReasonIsApproved,
                Student= loansDto.Student
            };
        }

        public static LoansDto ConvertToDto(LoanSupportRequest loan)
        {
            if (loan == null)
                return null;
            return new LoansDto()
            {
                Details = loan.Details,
                AmountRequested = loan.AmountRequested,
                AmountRepaymentMonthly = loan.AmountRepaymentMonthly,
                branch = loan.branch,
                ApprovedAmount = loan.ApprovedAmount,
                CurrentStatus = loan.CurrentStatus,
                Date = loan.Date,
                DateReturningEntireAmount = loan.DateReturningEntireAmount,
                DigitalSignature = loan.DigitalSignature,
                Id = loan.Id,
                IsApproved = loan.IsApproved,
                Iscanceled = loan.Iscanceled,
                IsDisapprovedClosedRequest = loan.IsDisapprovedClosedRequest,
                LoanGuarantors = loan.LoanGuarantors,
                NumberApprovedMonths = loan.NumberApprovedMonths,
                ReasonIsApproved = loan.ReasonIsApproved,
                Student = loan.Student
            };
        }

        public static List<LoansDto> Convert(LoanSupportRequests loans)
        {
            if (loans != null)
            {
                List<LoansDto> loansDto = new List<LoansDto>();
                foreach (LoanSupportRequest loan in loans)
                {
                    LoansDto item = ConvertToDto(loan);
                    loansDto.Add(item);
                }
                return loansDto;
            }
            return null;

        }
        public static List<StudentPaymentDto> Convert(StudentPayments studentPayments)
        {
            if (studentPayments != null)
            {
                List<StudentPaymentDto> studentPaymentsDto = new List<StudentPaymentDto>();
                foreach (StudentPayment studentPayment in studentPayments)
                {
                    StudentPaymentDto item = ConvertToDto(studentPayment);
                    studentPaymentsDto.Add(item);
                }
                return studentPaymentsDto;
            }
            return null;
        }

        private static StudentPaymentDto ConvertToDto(StudentPayment studentPayment)
        {
            if (studentPayment == null)
                return null;
            return new StudentPaymentDto()
            {
                AttendanceSum= studentPayment.AttendanceSum,
                DentalHealthSupportSum= studentPayment.DentalHealthSupportSum,
                ExamsSum= studentPayment.ExamsSum,
                FinancialSupportSum= studentPayment.FinancialSupportSum,
                HealthSupportSum= studentPayment.HealthSupportSum,
                LoansGivenSum= studentPayment.LoansGivenSum,
                LoansReturnSum= studentPayment.LoansReturnSum,
                Month= studentPayment.Month,
                Year= studentPayment.Year,
                PaymentSum= studentPayment.PaymentSum,
                StateBudgetSum= studentPayment.StateBudgetSum,
                Student= studentPayment.Student
            };
        }

        public static FinancialSupportRequest Convert(FinancialSupportRequestDto financialSupportRequestDto)
        {
            if (financialSupportRequestDto == null)
                return null;
            return new FinancialSupportRequest()
            {
                ApprovedAmount = financialSupportRequestDto.ApprovedAmount,
                branch = financialSupportRequestDto.branch,
                CurrentStatus = financialSupportRequestDto.CurrentStatus,
                Date = financialSupportRequestDto.Date,
                Details = financialSupportRequestDto.Details,
                DigitalSignature = financialSupportRequestDto.DigitalSignature,
                Id = financialSupportRequestDto.Id,
                IsApproved = financialSupportRequestDto.IsApproved,
                Iscanceled = financialSupportRequestDto.Iscanceled,
                NumberOfMonthsApproved = financialSupportRequestDto.NumberOfMonthsApproved,
                Student = financialSupportRequestDto.Student
            };
        }

        public static FinancialSupportRequestDto ConvertToDto(FinancialSupportRequest financialSupportRequest)
        {
            if (financialSupportRequest == null)
                return null;
            return new FinancialSupportRequestDto()
            {
                ApprovedAmount = financialSupportRequest.ApprovedAmount,
                branch = financialSupportRequest.branch,
                CurrentStatus = financialSupportRequest.CurrentStatus,
                Date = financialSupportRequest.Date,
                Details = financialSupportRequest.Details,
                DigitalSignature = financialSupportRequest.DigitalSignature,
                Id = financialSupportRequest.Id,
                IsApproved = financialSupportRequest.IsApproved,
                Iscanceled = financialSupportRequest.Iscanceled,
                NumberOfMonthsApproved = financialSupportRequest.NumberOfMonthsApproved,
                Student = financialSupportRequest.Student
            };
        }
        public static List<FinancialSupportRequestDto> Convert(FinancialSupportRequests financialSupportRequests)
        {
            if (financialSupportRequests != null)
            {
                List<FinancialSupportRequestDto> financialSupportRequestsDto = new List<FinancialSupportRequestDto>();
                foreach (FinancialSupportRequest financialSupportRequest in financialSupportRequests)
                {
                    FinancialSupportRequestDto item = ConvertToDto(financialSupportRequest);
                    financialSupportRequestsDto.Add(item);
                }
                return financialSupportRequestsDto;
            }
            return null;
        }
    }
}

