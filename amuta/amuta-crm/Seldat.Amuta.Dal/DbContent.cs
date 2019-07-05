namespace Seldat.Amuta.Dal
{
	public static class DbContent
	{
        public class ColumnDetails
        {
            public string Name;
            public string FullName;
        }
		public static class Tables
		{
			/// <summary>
			/// </summary>
			public static class Countries
			{
			public static string TableName  = "countries";
			public static string SelectAllTable  = "Select * from countries";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "countries_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "countries_name"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails ShortName = new ColumnDetails()
				{
					 Name="short_name",
					 FullName= "countries_short_name"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails DialingCode = new ColumnDetails()
				{
					 Name="dialing_code",
					 FullName= "countries_dialing_code"
				};
				public static string allColumnsAlias = "countries.id as countries_id, countries.name as countries_name, countries.short_name as countries_short_name, countries.dialing_code as countries_dialing_code";
				public static string UpdateTable = "Update countries set name = @name, short_name = @short_name, dialing_code = @dialing_code where id = @id";
				public static string Delete = "Delete from countries where id = @id";
				public static string Select = "Select * from countries where id = @id";
				public static string InsertTable = "Insert into countries(name, short_name, dialing_code)Values(@name, @short_name, @dialing_code)";
			}
			/// <summary>
			/// </summary>
			public static class Cities
			{
			public static string TableName  = "cities";
			public static string SelectAllTable  = "Select * from cities";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "cities_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "cities_name"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails CountryId = new ColumnDetails()
				{
					 Name="country_id",
					 FullName= "cities_country_id"
				};
				public static string allColumnsAlias = "cities.id as cities_id, cities.name as cities_name, cities.country_id as cities_country_id";
				public static string UpdateTable = "Update cities set name = @name, country_id = @country_id where id = @id";
				public static string Delete = "Delete from cities where id = @id";
				public static string Select = "Select * from cities where id = @id";
				public static string InsertTable = "Insert into cities(name, country_id)Values(@name, @country_id)";
			}
			/// <summary>
			/// </summary>
			public static class Streets
			{
			public static string TableName  = "streets";
			public static string SelectAllTable  = "Select * from streets";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "streets_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "streets_name"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails CityId = new ColumnDetails()
				{
					 Name="city_id",
					 FullName= "streets_city_id"
				};
				public static string allColumnsAlias = "streets.id as streets_id, streets.name as streets_name, streets.city_id as streets_city_id";
				public static string UpdateTable = "Update streets set name = @name, city_id = @city_id where id = @id";
				public static string Delete = "Delete from streets where id = @id";
				public static string Select = "Select * from streets where id = @id";
				public static string InsertTable = "Insert into streets(name, city_id)Values(@name, @city_id)";
			}
			/// <summary>
			/// </summary>
			public static class Address
			{
			public static string TableName  = "address";
			public static string SelectAllTable  = "Select * from address";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "address_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails CountryId = new ColumnDetails()
				{
					 Name="country_id",
					 FullName= "address_country_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails CityId = new ColumnDetails()
				{
					 Name="city_id",
					 FullName= "address_city_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails NeighborhoodName = new ColumnDetails()
				{
					 Name="neighborhood_name",
					 FullName= "address_neighborhood_name"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StreetId = new ColumnDetails()
				{
					 Name="street_id",
					 FullName= "address_street_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails HouseNumber = new ColumnDetails()
				{
					 Name="house_number",
					 FullName= "address_house_number"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails ApartmentNumber = new ColumnDetails()
				{
					 Name="apartment_number",
					 FullName= "address_apartment_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails ZipCode = new ColumnDetails()
				{
					 Name="zip_code",
					 FullName= "address_zip_code"
				};
				public static string allColumnsAlias = "address.id as address_id, address.country_id as address_country_id, address.city_id as address_city_id, address.neighborhood_name as address_neighborhood_name, address.street_id as address_street_id, address.house_number as address_house_number, address.apartment_number as address_apartment_number, address.zip_code as address_zip_code";
				public static string UpdateTable = "Update address set country_id = @country_id, city_id = @city_id, neighborhood_name = @neighborhood_name, street_id = @street_id, house_number = @house_number, apartment_number = @apartment_number, zip_code = @zip_code where id = @id";
				public static string Delete = "Delete from address where id = @id";
				public static string Select = "Select * from address where id = @id";
				public static string InsertTable = "Insert into address(country_id, city_id, neighborhood_name, street_id, house_number, apartment_number, zip_code)Values(@country_id, @city_id, @neighborhood_name, @street_id, @house_number, @apartment_number, @zip_code)";
			}
			/// <summary>
			/// </summary>
			public static class AttendanceTypes
			{
			public static string TableName  = "attendance_types";
			public static string SelectAllTable  = "Select * from attendance_types";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "attendance_types_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "attendance_types_name"
				};
				public static string allColumnsAlias = "attendance_types.id as attendance_types_id, attendance_types.name as attendance_types_name";
				public static string UpdateTable = "Update attendance_types set id = @id, name = @name where id = @id";
				public static string Delete = "Delete from attendance_types where id = @id";
				public static string Select = "Select * from attendance_types where id = @id";
				public static string InsertTable = "Insert into attendance_types(id, name)Values(@id, @name)";
			}
			/// <summary>
			/// </summary>
			public static class BranchTypes
			{
			public static string TableName  = "branch_types";
			public static string SelectAllTable  = "Select * from branch_types";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "branch_types_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Type = new ColumnDetails()
				{
					 Name="type",
					 FullName= "branch_types_type"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "branch_types_name"
				};
				public static string allColumnsAlias = "branch_types.id as branch_types_id, branch_types.type as branch_types_type, branch_types.name as branch_types_name";
				public static string UpdateTable = "Update branch_types set id = @id, type = @type, name = @name where id = @id";
				public static string Delete = "Delete from branch_types where id = @id";
				public static string Select = "Select * from branch_types where id = @id";
				public static string InsertTable = "Insert into branch_types(id, type, name)Values(@id, @type, @name)";
			}
			/// <summary>
			/// </summary>
			public static class Institutions
			{
			public static string TableName  = "institutions";
			public static string SelectAllTable  = "Select * from institutions";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "institutions_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "institutions_name"
				};
				public static string allColumnsAlias = "institutions.id as institutions_id, institutions.name as institutions_name";
				public static string UpdateTable = "Update institutions set name = @name where id = @id";
				public static string Delete = "Delete from institutions where id = @id";
				public static string Select = "Select * from institutions where id = @id";
				public static string InsertTable = "Insert into institutions(name)Values(@name)";
			}
			/// <summary>
			/// </summary>
			public static class DevicesTypes
			{
			public static string TableName  = "devices_types";
			public static string SelectAllTable  = "Select * from devices_types";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "devices_types_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "devices_types_name"
				};
				public static string allColumnsAlias = "devices_types.id as devices_types_id, devices_types.name as devices_types_name";
				public static string UpdateTable = "Update devices_types set id = @id, name = @name where id = @id";
				public static string Delete = "Delete from devices_types where id = @id";
				public static string Select = "Select * from devices_types where id = @id";
				public static string InsertTable = "Insert into devices_types(id, name)Values(@id, @name)";
			}
			/// <summary>
			/// </summary>
			public static class Devices
			{
			public static string TableName  = "devices";
			public static string SelectAllTable  = "Select * from devices";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "devices_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails DeviceTypeId = new ColumnDetails()
				{
					 Name="device_type_id",
					 FullName= "devices_device_type_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails SerialNumber = new ColumnDetails()
				{
					 Name="serial_number",
					 FullName= "devices_serial_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "devices_name"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Model = new ColumnDetails()
				{
					 Name="model",
					 FullName= "devices_model"
				};
				public static string allColumnsAlias = "devices.id as devices_id, devices.device_type_id as devices_device_type_id, devices.serial_number as devices_serial_number, devices.name as devices_name, devices.model as devices_model";
				public static string UpdateTable = "Update devices set device_type_id = @device_type_id, serial_number = @serial_number, name = @name, model = @model where id = @id";
				public static string Delete = "Delete from devices where id = @id";
				public static string Select = "Select * from devices where id = @id";
				public static string InsertTable = "Insert into devices(device_type_id, serial_number, name, model)Values(@device_type_id, @serial_number, @name, @model)";
			}
			/// <summary>
			/// </summary>
			public static class Banks
			{
			public static string TableName  = "banks";
			public static string SelectAllTable  = "Select * from banks";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "banks_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails BankNumber = new ColumnDetails()
				{
					 Name="bank_number",
					 FullName= "banks_bank_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "banks_name"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails BranchNumber = new ColumnDetails()
				{
					 Name="branch_number",
					 FullName= "banks_branch_number"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails AddressId = new ColumnDetails()
				{
					 Name="address_id",
					 FullName= "banks_address_id"
				};
				public static string allColumnsAlias = "banks.id as banks_id, banks.bank_number as banks_bank_number, banks.name as banks_name, banks.branch_number as banks_branch_number, banks.address_id as banks_address_id";
				public static string UpdateTable = "Update banks set bank_number = @bank_number, name = @name, branch_number = @branch_number, address_id = @address_id where id = @id";
				public static string Delete = "Delete from banks where id = @id";
				public static string Select = "Select * from banks where id = @id";
				public static string InsertTable = "Insert into banks(bank_number, name, branch_number, address_id)Values(@bank_number, @name, @branch_number, @address_id)";
			}
			/// <summary>
			/// </summary>
			public static class Attendance
			{
			public static string TableName  = "attendance";
			public static string SelectAllTable  = "Select * from attendance";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "attendance_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StudentId = new ColumnDetails()
				{
					 Name="student_id",
					 FullName= "attendance_student_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "attendance_branch_id"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails Time = new ColumnDetails()
				{
					 Name="time",
					 FullName= "attendance_time"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsEntry = new ColumnDetails()
				{
					 Name="is_entry",
					 FullName= "attendance_is_entry"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails UserLoggedId = new ColumnDetails()
				{
					 Name="user_logged_id",
					 FullName= "attendance_user_logged_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails DeviceId = new ColumnDetails()
				{
					 Name="device_id",
					 FullName= "attendance_device_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails LocationDevice = new ColumnDetails()
				{
					 Name="location_device",
					 FullName= "attendance_location_device"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails TimeLogged = new ColumnDetails()
				{
					 Name="time_logged",
					 FullName= "attendance_time_logged"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Reason = new ColumnDetails()
				{
					 Name="reason",
					 FullName= "attendance_reason"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsApproved = new ColumnDetails()
				{
					 Name="is_approved",
					 FullName= "attendance_is_approved"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails UserApprovedId = new ColumnDetails()
				{
					 Name="user_approved_id",
					 FullName= "attendance_user_approved_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails AttendanceTypeId = new ColumnDetails()
				{
					 Name="attendance_type_id",
					 FullName= "attendance_attendance_type_id"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsActive = new ColumnDetails()
				{
					 Name="is_active",
					 FullName= "attendance_is_active"
				};
				public static string allColumnsAlias = "attendance.id as attendance_id, attendance.student_id as attendance_student_id, attendance.branch_id as attendance_branch_id, attendance.time as attendance_time, attendance.is_entry as attendance_is_entry, attendance.user_logged_id as attendance_user_logged_id, attendance.device_id as attendance_device_id, attendance.location_device as attendance_location_device, attendance.time_logged as attendance_time_logged, attendance.reason as attendance_reason, attendance.is_approved as attendance_is_approved, attendance.user_approved_id as attendance_user_approved_id, attendance.attendance_type_id as attendance_attendance_type_id, attendance.is_active as attendance_is_active";
				public static string UpdateTable = "Update attendance set student_id = @student_id, branch_id = @branch_id, time = @time, is_entry = @is_entry, user_logged_id = @user_logged_id, device_id = @device_id, location_device = @location_device, time_logged = @time_logged, reason = @reason, is_approved = @is_approved, user_approved_id = @user_approved_id, attendance_type_id = @attendance_type_id, is_active = @is_active where id = @id";
				public static string Delete = "Delete from attendance where id = @id";
				public static string Select = "Select * from attendance where id = @id";
				public static string InsertTable = "Insert into attendance(student_id, branch_id, time, is_entry, user_logged_id, device_id, location_device, time_logged, reason, is_approved, user_approved_id, attendance_type_id, is_active)Values(@student_id, @branch_id, @time, @is_entry, @user_logged_id, @device_id, @location_device, @time_logged, @reason, @is_approved, @user_approved_id, @attendance_type_id, @is_active)";
			}
			/// <summary>
			/// </summary>
			public static class BranchActivityHours
			{
			public static string TableName  = "branch_activity_hours";
			public static string SelectAllTable  = "Select * from branch_activity_hours";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "branch_activity_hours_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "branch_activity_hours_branch_id"
				};
			/// <summary>
			///Type: return time
			/// </summary>
				public static ColumnDetails LateHour = new ColumnDetails()
				{
					 Name="late_hour",
					 FullName= "branch_activity_hours_late_hour"
				};
			/// <summary>
			///Type: return time
			/// </summary>
				public static ColumnDetails StartStudyHours = new ColumnDetails()
				{
					 Name="start_study_hours",
					 FullName= "branch_activity_hours_start_study_hours"
				};
			/// <summary>
			///Type: return time
			/// </summary>
				public static ColumnDetails EndStudyHours = new ColumnDetails()
				{
					 Name="end_study_hours",
					 FullName= "branch_activity_hours_end_study_hours"
				};
				public static string allColumnsAlias = "branch_activity_hours.id as branch_activity_hours_id, branch_activity_hours.branch_id as branch_activity_hours_branch_id, branch_activity_hours.late_hour as branch_activity_hours_late_hour, branch_activity_hours.start_study_hours as branch_activity_hours_start_study_hours, branch_activity_hours.end_study_hours as branch_activity_hours_end_study_hours";
				public static string UpdateTable = "Update branch_activity_hours set branch_id = @branch_id, late_hour = @late_hour, start_study_hours = @start_study_hours, end_study_hours = @end_study_hours where id = @id";
				public static string Delete = "Delete from branch_activity_hours where id = @id";
				public static string Select = "Select * from branch_activity_hours where id = @id";
				public static string InsertTable = "Insert into branch_activity_hours(branch_id, late_hour, start_study_hours, end_study_hours)Values(@branch_id, @late_hour, @start_study_hours, @end_study_hours)";
			}
			/// <summary>
			/// </summary>
			public static class BranchDevices
			{
			public static string TableName  = "branch_devices";
			public static string SelectAllTable  = "Select * from branch_devices";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "branch_devices_branch_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails DeviceId = new ColumnDetails()
				{
					 Name="device_id",
					 FullName= "branch_devices_device_id"
				};
				public static string allColumnsAlias = "branch_devices.branch_id as branch_devices_branch_id, branch_devices.device_id as branch_devices_device_id";
				public static string UpdateTable = "Update branch_devices set branch_id = @branch_id, device_id = @device_id where branch_id = @branch_id";
				public static string Delete = "Delete from branch_devices where branch_id = @branch_id";
				public static string Select = "Select * from branch_devices where branch_id = @branch_id";
				public static string InsertTable = "Insert into branch_devices(branch_id, device_id)Values(@branch_id, @device_id)";
			}
			/// <summary>
			/// </summary>
			public static class BranchExams
			{
			public static string TableName  = "branch_exams";
			public static string SelectAllTable  = "Select * from branch_exams";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "branch_exams_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "branch_exams_branch_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails SubmitExamScholarshipAddition = new ColumnDetails()
				{
					 Name="submit_exam_scholarship_addition",
					 FullName= "branch_exams_submit_exam_scholarship_addition"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails FailingSubmitExamScholarshipReducing = new ColumnDetails()
				{
					 Name="failing_submit_exam_scholarship_reducing",
					 FullName= "branch_exams_failing_submit_exam_scholarship_reducing"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails PassedExamScholarshipAddition = new ColumnDetails()
				{
					 Name="passed_exam_scholarship_addition",
					 FullName= "branch_exams_passed_exam_scholarship_addition"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails NotPassedExamScholarshipReducing = new ColumnDetails()
				{
					 Name="not_passed_exam_scholarship_reducing",
					 FullName= "branch_exams_not_passed_exam_scholarship_reducing"
				};
			/// <summary>
			///Type: return decimal
			/// </summary>
				public static ColumnDetails PassGrade = new ColumnDetails()
				{
					 Name="pass_grade",
					 FullName= "branch_exams_pass_grade"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Subject = new ColumnDetails()
				{
					 Name="subject",
					 FullName= "branch_exams_subject"
				};
				public static string allColumnsAlias = "branch_exams.id as branch_exams_id, branch_exams.branch_id as branch_exams_branch_id, branch_exams.submit_exam_scholarship_addition as branch_exams_submit_exam_scholarship_addition, branch_exams.failing_submit_exam_scholarship_reducing as branch_exams_failing_submit_exam_scholarship_reducing, branch_exams.passed_exam_scholarship_addition as branch_exams_passed_exam_scholarship_addition, branch_exams.not_passed_exam_scholarship_reducing as branch_exams_not_passed_exam_scholarship_reducing, branch_exams.pass_grade as branch_exams_pass_grade, branch_exams.subject as branch_exams_subject";
				public static string UpdateTable = "Update branch_exams set branch_id = @branch_id, submit_exam_scholarship_addition = @submit_exam_scholarship_addition, failing_submit_exam_scholarship_reducing = @failing_submit_exam_scholarship_reducing, passed_exam_scholarship_addition = @passed_exam_scholarship_addition, not_passed_exam_scholarship_reducing = @not_passed_exam_scholarship_reducing, pass_grade = @pass_grade, subject = @subject where id = @id";
				public static string Delete = "Delete from branch_exams where id = @id";
				public static string Select = "Select * from branch_exams where id = @id";
				public static string InsertTable = "Insert into branch_exams(branch_id, submit_exam_scholarship_addition, failing_submit_exam_scholarship_reducing, passed_exam_scholarship_addition, not_passed_exam_scholarship_reducing, pass_grade, subject)Values(@branch_id, @submit_exam_scholarship_addition, @failing_submit_exam_scholarship_reducing, @passed_exam_scholarship_addition, @not_passed_exam_scholarship_reducing, @pass_grade, @subject)";
			}
			/// <summary>
			/// </summary>
			public static class StudyPath
			{
			public static string TableName  = "study_path";
			public static string SelectAllTable  = "Select * from study_path";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "study_path_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "study_path_name"
				};
				public static string allColumnsAlias = "study_path.id as study_path_id, study_path.name as study_path_name";
				public static string UpdateTable = "Update study_path set name = @name where id = @id";
				public static string Delete = "Delete from study_path where id = @id";
				public static string Select = "Select * from study_path where id = @id";
				public static string InsertTable = "Insert into study_path(name)Values(@name)";
			}
			/// <summary>
			/// </summary>
			public static class RequestStatus
			{
			public static string TableName  = "request_status";
			public static string SelectAllTable  = "Select * from request_status";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "request_status_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "request_status_name"
				};
				public static string allColumnsAlias = "request_status.id as request_status_id, request_status.name as request_status_name";
				public static string UpdateTable = "Update request_status set id = @id, name = @name where id = @id";
				public static string Delete = "Delete from request_status where id = @id";
				public static string Select = "Select * from request_status where id = @id";
				public static string InsertTable = "Insert into request_status(id, name)Values(@id, @name)";
			}
			/// <summary>
			/// </summary>
			public static class FamilyRelation
			{
			public static string TableName  = "family_relation";
			public static string SelectAllTable  = "Select * from family_relation";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "family_relation_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "family_relation_name"
				};
				public static string allColumnsAlias = "family_relation.id as family_relation_id, family_relation.name as family_relation_name";
				public static string UpdateTable = "Update family_relation set id = @id, name = @name where id = @id";
				public static string Delete = "Delete from family_relation where id = @id";
				public static string Select = "Select * from family_relation where id = @id";
				public static string InsertTable = "Insert into family_relation(id, name)Values(@id, @name)";
			}
			/// <summary>
			/// </summary>
			public static class DentalHealthSupportRequest
			{
			public static string TableName  = "dental_health_support_request";
			public static string SelectAllTable  = "Select * from dental_health_support_request";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "dental_health_support_request_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails VoucherNumber = new ColumnDetails()
				{
					 Name="voucher_number",
					 FullName= "dental_health_support_request_voucher_number"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails RealizationDate = new ColumnDetails()
				{
					 Name="realization_date",
					 FullName= "dental_health_support_request_realization_date"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails PatientName = new ColumnDetails()
				{
					 Name="patient_name",
					 FullName= "dental_health_support_request_patient_name"
				};
			/// <summary>
			///Type: return decimal
			/// </summary>
				public static ColumnDetails Age = new ColumnDetails()
				{
					 Name="age",
					 FullName= "dental_health_support_request_age"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails FamilyRelationId = new ColumnDetails()
				{
					 Name="family_relation_id",
					 FullName= "dental_health_support_request_family_relation_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StudentId = new ColumnDetails()
				{
					 Name="student_id",
					 FullName= "dental_health_support_request_student_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "dental_health_support_request_branch_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Details = new ColumnDetails()
				{
					 Name="details",
					 FullName= "dental_health_support_request_details"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails Date = new ColumnDetails()
				{
					 Name="date",
					 FullName= "dental_health_support_request_date"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails CurrentStatusId = new ColumnDetails()
				{
					 Name="current_status_id",
					 FullName= "dental_health_support_request_current_status_id"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsApproved = new ColumnDetails()
				{
					 Name="is_approved",
					 FullName= "dental_health_support_request_is_approved"
				};
			/// <summary>
			///Type: return varbinary
			/// </summary>
				public static ColumnDetails DigitalSignature = new ColumnDetails()
				{
					 Name="digital_signature",
					 FullName= "dental_health_support_request_digital_signature"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsCanceled = new ColumnDetails()
				{
					 Name="is_canceled",
					 FullName= "dental_health_support_request_is_canceled"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails ReasonIsApproved = new ColumnDetails()
				{
					 Name="reason_is_approved",
					 FullName= "dental_health_support_request_reason_is_approved"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsDisapprovedClosedRequest = new ColumnDetails()
				{
					 Name="is_disapproved_closed_request",
					 FullName= "dental_health_support_request_is_disapproved_closed_request"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsActive = new ColumnDetails()
				{
					 Name="is_active",
					 FullName= "dental_health_support_request_is_active"
				};
				public static string allColumnsAlias = "dental_health_support_request.id as dental_health_support_request_id, dental_health_support_request.voucher_number as dental_health_support_request_voucher_number, dental_health_support_request.realization_date as dental_health_support_request_realization_date, dental_health_support_request.patient_name as dental_health_support_request_patient_name, dental_health_support_request.age as dental_health_support_request_age, dental_health_support_request.family_relation_id as dental_health_support_request_family_relation_id, dental_health_support_request.student_id as dental_health_support_request_student_id, dental_health_support_request.branch_id as dental_health_support_request_branch_id, dental_health_support_request.details as dental_health_support_request_details, dental_health_support_request.date as dental_health_support_request_date, dental_health_support_request.current_status_id as dental_health_support_request_current_status_id, dental_health_support_request.is_approved as dental_health_support_request_is_approved, dental_health_support_request.digital_signature as dental_health_support_request_digital_signature, dental_health_support_request.is_canceled as dental_health_support_request_is_canceled, dental_health_support_request.reason_is_approved as dental_health_support_request_reason_is_approved, dental_health_support_request.is_disapproved_closed_request as dental_health_support_request_is_disapproved_closed_request, dental_health_support_request.is_active as dental_health_support_request_is_active";
				public static string UpdateTable = "Update dental_health_support_request set voucher_number = @voucher_number, realization_date = @realization_date, patient_name = @patient_name, age = @age, family_relation_id = @family_relation_id, student_id = @student_id, branch_id = @branch_id, details = @details, date = @date, current_status_id = @current_status_id, is_approved = @is_approved, digital_signature = @digital_signature, is_canceled = @is_canceled, reason_is_approved = @reason_is_approved, is_disapproved_closed_request = @is_disapproved_closed_request, is_active = @is_active where id = @id";
				public static string Delete = "Delete from dental_health_support_request where id = @id";
				public static string Select = "Select * from dental_health_support_request where id = @id";
				public static string InsertTable = "Insert into dental_health_support_request(voucher_number, realization_date, patient_name, age, family_relation_id, student_id, branch_id, details, date, current_status_id, is_approved, digital_signature, is_canceled, reason_is_approved, is_disapproved_closed_request, is_active)Values(@voucher_number, @realization_date, @patient_name, @age, @family_relation_id, @student_id, @branch_id, @details, @date, @current_status_id, @is_approved, @digital_signature, @is_canceled, @reason_is_approved, @is_disapproved_closed_request, @is_active)";
			}
			/// <summary>
			/// </summary>
			public static class FinancialSupportRequest
			{
			public static string TableName  = "financial_support_request";
			public static string SelectAllTable  = "Select * from financial_support_request";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "financial_support_request_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StudentId = new ColumnDetails()
				{
					 Name="student_id",
					 FullName= "financial_support_request_student_id"
				};
			/// <summary>
			///Type: return decimal
			/// </summary>
				public static ColumnDetails ApprovedAmount = new ColumnDetails()
				{
					 Name="approved_amount",
					 FullName= "financial_support_request_approved_amount"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails NumberOfMonthsApproved = new ColumnDetails()
				{
					 Name="number_of_months_approved",
					 FullName= "financial_support_request_number_of_months_approved"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Details = new ColumnDetails()
				{
					 Name="details",
					 FullName= "financial_support_request_details"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails Date = new ColumnDetails()
				{
					 Name="date",
					 FullName= "financial_support_request_date"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsApproved = new ColumnDetails()
				{
					 Name="is_approved",
					 FullName= "financial_support_request_is_approved"
				};
			/// <summary>
			///Type: return varbinary
			/// </summary>
				public static ColumnDetails DigitalSignature = new ColumnDetails()
				{
					 Name="digital_signature",
					 FullName= "financial_support_request_digital_signature"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "financial_support_request_branch_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails CurrentStatusId = new ColumnDetails()
				{
					 Name="current_status_id",
					 FullName= "financial_support_request_current_status_id"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsCanceled = new ColumnDetails()
				{
					 Name="is_canceled",
					 FullName= "financial_support_request_is_canceled"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails ReasonIsApproved = new ColumnDetails()
				{
					 Name="reason_is_approved",
					 FullName= "financial_support_request_reason_is_approved"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsDisapprovedClosedRequest = new ColumnDetails()
				{
					 Name="is_disapproved_closed_request",
					 FullName= "financial_support_request_is_disapproved_closed_request"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsActive = new ColumnDetails()
				{
					 Name="is_active",
					 FullName= "financial_support_request_is_active"
				};
				public static string allColumnsAlias = "financial_support_request.id as financial_support_request_id, financial_support_request.student_id as financial_support_request_student_id, financial_support_request.approved_amount as financial_support_request_approved_amount, financial_support_request.number_of_months_approved as financial_support_request_number_of_months_approved, financial_support_request.details as financial_support_request_details, financial_support_request.date as financial_support_request_date, financial_support_request.is_approved as financial_support_request_is_approved, financial_support_request.digital_signature as financial_support_request_digital_signature, financial_support_request.branch_id as financial_support_request_branch_id, financial_support_request.current_status_id as financial_support_request_current_status_id, financial_support_request.is_canceled as financial_support_request_is_canceled, financial_support_request.reason_is_approved as financial_support_request_reason_is_approved, financial_support_request.is_disapproved_closed_request as financial_support_request_is_disapproved_closed_request, financial_support_request.is_active as financial_support_request_is_active";
				public static string UpdateTable = "Update financial_support_request set student_id = @student_id, approved_amount = @approved_amount, number_of_months_approved = @number_of_months_approved, details = @details, date = @date, is_approved = @is_approved, digital_signature = @digital_signature, branch_id = @branch_id, current_status_id = @current_status_id, is_canceled = @is_canceled, reason_is_approved = @reason_is_approved, is_disapproved_closed_request = @is_disapproved_closed_request, is_active = @is_active where id = @id";
				public static string Delete = "Delete from financial_support_request where id = @id";
				public static string Select = "Select * from financial_support_request where id = @id";
				public static string InsertTable = "Insert into financial_support_request(student_id, approved_amount, number_of_months_approved, details, date, is_approved, digital_signature, branch_id, current_status_id, is_canceled, reason_is_approved, is_disapproved_closed_request, is_active)Values(@student_id, @approved_amount, @number_of_months_approved, @details, @date, @is_approved, @digital_signature, @branch_id, @current_status_id, @is_canceled, @reason_is_approved, @is_disapproved_closed_request, @is_active)";
			}
			/// <summary>
			/// </summary>
			public static class Guarantors
			{
			public static string TableName  = "guarantors";
			public static string SelectAllTable  = "Select * from guarantors";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "guarantors_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails FirstName = new ColumnDetails()
				{
					 Name="first_name",
					 FullName= "guarantors_first_name"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails LastName = new ColumnDetails()
				{
					 Name="last_name",
					 FullName= "guarantors_last_name"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails IdentityNumber = new ColumnDetails()
				{
					 Name="identity_number",
					 FullName= "guarantors_identity_number"
				};
			/// <summary>
			///Type: return varbinary
			/// </summary>
				public static ColumnDetails DigitalSignature = new ColumnDetails()
				{
					 Name="digital_signature",
					 FullName= "guarantors_digital_signature"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails IdCard = new ColumnDetails()
				{
					 Name="id_card",
					 FullName= "guarantors_id_card"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails GuaranteeDeedWritingDate = new ColumnDetails()
				{
					 Name="guarantee_deed_writing_date",
					 FullName= "guarantors_guarantee_deed_writing_date"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails LoanNote = new ColumnDetails()
				{
					 Name="loan_note",
					 FullName= "guarantors_loan_note"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails PassportNumber = new ColumnDetails()
				{
					 Name="passport_number",
					 FullName= "guarantors_passport_number"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails AddressId = new ColumnDetails()
				{
					 Name="address_id",
					 FullName= "guarantors_address_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails PhoneNumber = new ColumnDetails()
				{
					 Name="phone_number",
					 FullName= "guarantors_phone_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails CellphoneNumber = new ColumnDetails()
				{
					 Name="cellphone_number",
					 FullName= "guarantors_cellphone_number"
				};
				public static string allColumnsAlias = "guarantors.id as guarantors_id, guarantors.first_name as guarantors_first_name, guarantors.last_name as guarantors_last_name, guarantors.identity_number as guarantors_identity_number, guarantors.digital_signature as guarantors_digital_signature, guarantors.id_card as guarantors_id_card, guarantors.guarantee_deed_writing_date as guarantors_guarantee_deed_writing_date, guarantors.loan_note as guarantors_loan_note, guarantors.passport_number as guarantors_passport_number, guarantors.address_id as guarantors_address_id, guarantors.phone_number as guarantors_phone_number, guarantors.cellphone_number as guarantors_cellphone_number";
				public static string UpdateTable = "Update guarantors set first_name = @first_name, last_name = @last_name, identity_number = @identity_number, digital_signature = @digital_signature, id_card = @id_card, guarantee_deed_writing_date = @guarantee_deed_writing_date, loan_note = @loan_note, passport_number = @passport_number, address_id = @address_id, phone_number = @phone_number, cellphone_number = @cellphone_number where id = @id";
				public static string Delete = "Delete from guarantors where id = @id";
				public static string Select = "Select * from guarantors where id = @id";
				public static string InsertTable = "Insert into guarantors(first_name, last_name, identity_number, digital_signature, id_card, guarantee_deed_writing_date, loan_note, passport_number, address_id, phone_number, cellphone_number)Values(@first_name, @last_name, @identity_number, @digital_signature, @id_card, @guarantee_deed_writing_date, @loan_note, @passport_number, @address_id, @phone_number, @cellphone_number)";
			}
			/// <summary>
			/// </summary>
			public static class HealthSupportRequest
			{
			public static string TableName  = "health_support_request";
			public static string SelectAllTable  = "Select * from health_support_request";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "health_support_request_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "health_support_request_branch_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails CurrentStatusId = new ColumnDetails()
				{
					 Name="current_status_id",
					 FullName= "health_support_request_current_status_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails FamilyRelationId = new ColumnDetails()
				{
					 Name="family_relation_id",
					 FullName= "health_support_request_family_relation_id"
				};
			/// <summary>
			///Type: return decimal
			/// </summary>
				public static ColumnDetails ApprovedAmount = new ColumnDetails()
				{
					 Name="approved_amount",
					 FullName= "health_support_request_approved_amount"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails RealizationDate = new ColumnDetails()
				{
					 Name="realization_date",
					 FullName= "health_support_request_realization_date"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails PatientName = new ColumnDetails()
				{
					 Name="patient_name",
					 FullName= "health_support_request_patient_name"
				};
			/// <summary>
			///Type: return decimal
			/// </summary>
				public static ColumnDetails Age = new ColumnDetails()
				{
					 Name="age",
					 FullName= "health_support_request_age"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Details = new ColumnDetails()
				{
					 Name="details",
					 FullName= "health_support_request_details"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails Date = new ColumnDetails()
				{
					 Name="date",
					 FullName= "health_support_request_date"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsApproved = new ColumnDetails()
				{
					 Name="is_approved",
					 FullName= "health_support_request_is_approved"
				};
			/// <summary>
			///Type: return varbinary
			/// </summary>
				public static ColumnDetails DigitalSignature = new ColumnDetails()
				{
					 Name="digital_signature",
					 FullName= "health_support_request_digital_signature"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StudentId = new ColumnDetails()
				{
					 Name="student_id",
					 FullName= "health_support_request_student_id"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsCanceled = new ColumnDetails()
				{
					 Name="is_canceled",
					 FullName= "health_support_request_is_canceled"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails ReasonIsApproved = new ColumnDetails()
				{
					 Name="reason_is_approved",
					 FullName= "health_support_request_reason_is_approved"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsDisapprovedClosedRequest = new ColumnDetails()
				{
					 Name="is_disapproved_closed_request",
					 FullName= "health_support_request_is_disapproved_closed_request"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsActive = new ColumnDetails()
				{
					 Name="is_active",
					 FullName= "health_support_request_is_active"
				};
				public static string allColumnsAlias = "health_support_request.id as health_support_request_id, health_support_request.branch_id as health_support_request_branch_id, health_support_request.current_status_id as health_support_request_current_status_id, health_support_request.family_relation_id as health_support_request_family_relation_id, health_support_request.approved_amount as health_support_request_approved_amount, health_support_request.realization_date as health_support_request_realization_date, health_support_request.patient_name as health_support_request_patient_name, health_support_request.age as health_support_request_age, health_support_request.details as health_support_request_details, health_support_request.date as health_support_request_date, health_support_request.is_approved as health_support_request_is_approved, health_support_request.digital_signature as health_support_request_digital_signature, health_support_request.student_id as health_support_request_student_id, health_support_request.is_canceled as health_support_request_is_canceled, health_support_request.reason_is_approved as health_support_request_reason_is_approved, health_support_request.is_disapproved_closed_request as health_support_request_is_disapproved_closed_request, health_support_request.is_active as health_support_request_is_active";
				public static string UpdateTable = "Update health_support_request set branch_id = @branch_id, current_status_id = @current_status_id, family_relation_id = @family_relation_id, approved_amount = @approved_amount, realization_date = @realization_date, patient_name = @patient_name, age = @age, details = @details, date = @date, is_approved = @is_approved, digital_signature = @digital_signature, student_id = @student_id, is_canceled = @is_canceled, reason_is_approved = @reason_is_approved, is_disapproved_closed_request = @is_disapproved_closed_request, is_active = @is_active where id = @id";
				public static string Delete = "Delete from health_support_request where id = @id";
				public static string Select = "Select * from health_support_request where id = @id";
				public static string InsertTable = "Insert into health_support_request(branch_id, current_status_id, family_relation_id, approved_amount, realization_date, patient_name, age, details, date, is_approved, digital_signature, student_id, is_canceled, reason_is_approved, is_disapproved_closed_request, is_active)Values(@branch_id, @current_status_id, @family_relation_id, @approved_amount, @realization_date, @patient_name, @age, @details, @date, @is_approved, @digital_signature, @student_id, @is_canceled, @reason_is_approved, @is_disapproved_closed_request, @is_active)";
			}
			/// <summary>
			/// </summary>
			public static class LoanSupportRequest
			{
			public static string TableName  = "loan_support_request";
			public static string SelectAllTable  = "Select * from loan_support_request";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "loan_support_request_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StudentId = new ColumnDetails()
				{
					 Name="student_id",
					 FullName= "loan_support_request_student_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "loan_support_request_branch_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails CurrentStatusId = new ColumnDetails()
				{
					 Name="current_status_id",
					 FullName= "loan_support_request_current_status_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails AmountRequested = new ColumnDetails()
				{
					 Name="amount_requested",
					 FullName= "loan_support_request_amount_requested"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails AmountRepaymentMonthly = new ColumnDetails()
				{
					 Name="amount_repayment_monthly",
					 FullName= "loan_support_request_amount_repayment_monthly"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails DateReturningEntireAmount = new ColumnDetails()
				{
					 Name="date_returning_entire_amount",
					 FullName= "loan_support_request_date_returning_entire_amount"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails ReasonIsApproved = new ColumnDetails()
				{
					 Name="reason_is_approved",
					 FullName= "loan_support_request_reason_is_approved"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsDisapprovedClosedRequest = new ColumnDetails()
				{
					 Name="is_disapproved_closed_request",
					 FullName= "loan_support_request_is_disapproved_closed_request"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Details = new ColumnDetails()
				{
					 Name="details",
					 FullName= "loan_support_request_details"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails Date = new ColumnDetails()
				{
					 Name="date",
					 FullName= "loan_support_request_date"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsApproved = new ColumnDetails()
				{
					 Name="is_approved",
					 FullName= "loan_support_request_is_approved"
				};
			/// <summary>
			///Type: return varbinary
			/// </summary>
				public static ColumnDetails DigitalSignature = new ColumnDetails()
				{
					 Name="digital_signature",
					 FullName= "loan_support_request_digital_signature"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsCanceled = new ColumnDetails()
				{
					 Name="is_canceled",
					 FullName= "loan_support_request_is_canceled"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails NumberApprovedMonths = new ColumnDetails()
				{
					 Name="number_approved_months",
					 FullName= "loan_support_request_number_approved_months"
				};
			/// <summary>
			///Type: return decimal
			/// </summary>
				public static ColumnDetails ApprovedAmount = new ColumnDetails()
				{
					 Name="approved_amount",
					 FullName= "loan_support_request_approved_amount"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsActive = new ColumnDetails()
				{
					 Name="is_active",
					 FullName= "loan_support_request_is_active"
				};
				public static string allColumnsAlias = "loan_support_request.id as loan_support_request_id, loan_support_request.student_id as loan_support_request_student_id, loan_support_request.branch_id as loan_support_request_branch_id, loan_support_request.current_status_id as loan_support_request_current_status_id, loan_support_request.amount_requested as loan_support_request_amount_requested, loan_support_request.amount_repayment_monthly as loan_support_request_amount_repayment_monthly, loan_support_request.date_returning_entire_amount as loan_support_request_date_returning_entire_amount, loan_support_request.reason_is_approved as loan_support_request_reason_is_approved, loan_support_request.is_disapproved_closed_request as loan_support_request_is_disapproved_closed_request, loan_support_request.details as loan_support_request_details, loan_support_request.date as loan_support_request_date, loan_support_request.is_approved as loan_support_request_is_approved, loan_support_request.digital_signature as loan_support_request_digital_signature, loan_support_request.is_canceled as loan_support_request_is_canceled, loan_support_request.number_approved_months as loan_support_request_number_approved_months, loan_support_request.approved_amount as loan_support_request_approved_amount, loan_support_request.is_active as loan_support_request_is_active";
				public static string UpdateTable = "Update loan_support_request set student_id = @student_id, branch_id = @branch_id, current_status_id = @current_status_id, amount_requested = @amount_requested, amount_repayment_monthly = @amount_repayment_monthly, date_returning_entire_amount = @date_returning_entire_amount, reason_is_approved = @reason_is_approved, is_disapproved_closed_request = @is_disapproved_closed_request, details = @details, date = @date, is_approved = @is_approved, digital_signature = @digital_signature, is_canceled = @is_canceled, number_approved_months = @number_approved_months, approved_amount = @approved_amount, is_active = @is_active where id = @id";
				public static string Delete = "Delete from loan_support_request where id = @id";
				public static string Select = "Select * from loan_support_request where id = @id";
				public static string InsertTable = "Insert into loan_support_request(student_id, branch_id, current_status_id, amount_requested, amount_repayment_monthly, date_returning_entire_amount, reason_is_approved, is_disapproved_closed_request, details, date, is_approved, digital_signature, is_canceled, number_approved_months, approved_amount, is_active)Values(@student_id, @branch_id, @current_status_id, @amount_requested, @amount_repayment_monthly, @date_returning_entire_amount, @reason_is_approved, @is_disapproved_closed_request, @details, @date, @is_approved, @digital_signature, @is_canceled, @number_approved_months, @approved_amount, @is_active)";
			}
			/// <summary>
			/// </summary>
			public static class LoanGuarantors
			{
			public static string TableName  = "loan_guarantors";
			public static string SelectAllTable  = "Select * from loan_guarantors";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails LoanId = new ColumnDetails()
				{
					 Name="loan_id",
					 FullName= "loan_guarantors_loan_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails GuarantorId = new ColumnDetails()
				{
					 Name="guarantor_id",
					 FullName= "loan_guarantors_guarantor_id"
				};
				public static string allColumnsAlias = "loan_guarantors.loan_id as loan_guarantors_loan_id, loan_guarantors.guarantor_id as loan_guarantors_guarantor_id";
				public static string UpdateTable = "Update loan_guarantors set loan_id = @loan_id, guarantor_id = @guarantor_id where loan_id = @loan_id";
				public static string Delete = "Delete from loan_guarantors where loan_id = @loan_id";
				public static string Select = "Select * from loan_guarantors where loan_id = @loan_id";
				public static string InsertTable = "Insert into loan_guarantors(loan_id, guarantor_id)Values(@loan_id, @guarantor_id)";
			}
			/// <summary>
			/// </summary>
			public static class Network
			{
			public static string TableName  = "network";
			public static string SelectAllTable  = "Select * from network";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "network_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "network_name"
				};
				public static string allColumnsAlias = "network.id as network_id, network.name as network_name";
				public static string UpdateTable = "Update network set name = @name where id = @id";
				public static string Delete = "Delete from network where id = @id";
				public static string Select = "Select * from network where id = @id";
				public static string InsertTable = "Insert into network(name)Values(@name)";
			}
			/// <summary>
			/// </summary>
			public static class NetworkInstitutions
			{
			public static string TableName  = "network_institutions";
			public static string SelectAllTable  = "Select * from network_institutions";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails NetworkId = new ColumnDetails()
				{
					 Name="network_id",
					 FullName= "network_institutions_network_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails InstitutionId = new ColumnDetails()
				{
					 Name="institution_id",
					 FullName= "network_institutions_institution_id"
				};
				public static string allColumnsAlias = "network_institutions.network_id as network_institutions_network_id, network_institutions.institution_id as network_institutions_institution_id";
				public static string UpdateTable = "Update network_institutions set network_id = @network_id, institution_id = @institution_id where network_id = @network_id";
				public static string Delete = "Delete from network_institutions where network_id = @network_id";
				public static string Select = "Select * from network_institutions where network_id = @network_id";
				public static string InsertTable = "Insert into network_institutions(network_id, institution_id)Values(@network_id, @institution_id)";
			}
			/// <summary>
			/// </summary>
			public static class SupportTypes
			{
			public static string TableName  = "support_types";
			public static string SelectAllTable  = "Select * from support_types";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "support_types_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "support_types_name"
				};
				public static string allColumnsAlias = "support_types.id as support_types_id, support_types.name as support_types_name";
				public static string UpdateTable = "Update support_types set id = @id, name = @name where id = @id";
				public static string Delete = "Delete from support_types where id = @id";
				public static string Select = "Select * from support_types where id = @id";
				public static string InsertTable = "Insert into support_types(id, name)Values(@id, @name)";
			}
			/// <summary>
			/// </summary>
			public static class RequestProcessInfo
			{
			public static string TableName  = "request_process_info";
			public static string SelectAllTable  = "Select * from request_process_info";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "request_process_info_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails SupportRequestId = new ColumnDetails()
				{
					 Name="support_request_id",
					 FullName= "request_process_info_support_request_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails SupportTypeId = new ColumnDetails()
				{
					 Name="support_type_id",
					 FullName= "request_process_info_support_type_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails UserId = new ColumnDetails()
				{
					 Name="user_id",
					 FullName= "request_process_info_user_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails PreviousStatusId = new ColumnDetails()
				{
					 Name="previous_status_id",
					 FullName= "request_process_info_previous_status_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails NextStatusId = new ColumnDetails()
				{
					 Name="next_status_id",
					 FullName= "request_process_info_next_status_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails CurrentStatusId = new ColumnDetails()
				{
					 Name="current_status_id",
					 FullName= "request_process_info_current_status_id"
				};
				public static string allColumnsAlias = "request_process_info.id as request_process_info_id, request_process_info.support_request_id as request_process_info_support_request_id, request_process_info.support_type_id as request_process_info_support_type_id, request_process_info.user_id as request_process_info_user_id, request_process_info.previous_status_id as request_process_info_previous_status_id, request_process_info.next_status_id as request_process_info_next_status_id, request_process_info.current_status_id as request_process_info_current_status_id";
				public static string UpdateTable = "Update request_process_info set support_request_id = @support_request_id, support_type_id = @support_type_id, user_id = @user_id, previous_status_id = @previous_status_id, next_status_id = @next_status_id, current_status_id = @current_status_id where id = @id";
				public static string Delete = "Delete from request_process_info where id = @id";
				public static string Select = "Select * from request_process_info where id = @id";
				public static string InsertTable = "Insert into request_process_info(support_request_id, support_type_id, user_id, previous_status_id, next_status_id, current_status_id)Values(@support_request_id, @support_type_id, @user_id, @previous_status_id, @next_status_id, @current_status_id)";
			}
			/// <summary>
			/// </summary>
			public static class Roles
			{
			public static string TableName  = "roles";
			public static string SelectAllTable  = "Select * from roles";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "roles_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "roles_name"
				};
				public static string allColumnsAlias = "roles.id as roles_id, roles.name as roles_name";
				public static string UpdateTable = "Update roles set id = @id, name = @name where id = @id";
				public static string Delete = "Delete from roles where id = @id";
				public static string Select = "Select * from roles where id = @id";
				public static string InsertTable = "Insert into roles(id, name)Values(@id, @name)";
			}
			/// <summary>
			/// </summary>
			public static class Scolarships
			{
			public static string TableName  = "scolarships";
			public static string SelectAllTable  = "Select * from scolarships";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "scolarships_id"
				};
			/// <summary>
			///Type: return decimal
			/// </summary>
				public static ColumnDetails Amount = new ColumnDetails()
				{
					 Name="amount",
					 FullName= "scolarships_amount"
				};
				public static string allColumnsAlias = "scolarships.id as scolarships_id, scolarships.amount as scolarships_amount";
				public static string UpdateTable = "Update scolarships set amount = @amount where id = @id";
				public static string Delete = "Delete from scolarships where id = @id";
				public static string Select = "Select * from scolarships where id = @id";
				public static string InsertTable = "Insert into scolarships(amount)Values(@amount)";
			}
			/// <summary>
			/// </summary>
			public static class StudentExams
			{
			public static string TableName  = "student_exams";
			public static string SelectAllTable  = "Select * from student_exams";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "student_exams_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StudentId = new ColumnDetails()
				{
					 Name="student_id",
					 FullName= "student_exams_student_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchExamId = new ColumnDetails()
				{
					 Name="branch_exam_id",
					 FullName= "student_exams_branch_exam_id"
				};
			/// <summary>
			///Type: return decimal
			/// </summary>
				public static ColumnDetails Grade = new ColumnDetails()
				{
					 Name="grade",
					 FullName= "student_exams_grade"
				};
				public static string allColumnsAlias = "student_exams.id as student_exams_id, student_exams.student_id as student_exams_student_id, student_exams.branch_exam_id as student_exams_branch_exam_id, student_exams.grade as student_exams_grade";
				public static string UpdateTable = "Update student_exams set student_id = @student_id, branch_exam_id = @branch_exam_id, grade = @grade where id = @id";
				public static string Delete = "Delete from student_exams where id = @id";
				public static string Select = "Select * from student_exams where id = @id";
				public static string InsertTable = "Insert into student_exams(student_id, branch_exam_id, grade)Values(@student_id, @branch_exam_id, @grade)";
			}
			/// <summary>
			/// </summary>
			public static class StudentExceptions
			{
			public static string TableName  = "student_exceptions";
			public static string SelectAllTable  = "Select * from student_exceptions";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "student_exceptions_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StudentId = new ColumnDetails()
				{
					 Name="student_id",
					 FullName= "student_exceptions_student_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "student_exceptions_branch_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Type = new ColumnDetails()
				{
					 Name="type",
					 FullName= "student_exceptions_type"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Value = new ColumnDetails()
				{
					 Name="value",
					 FullName= "student_exceptions_value"
				};
				public static string allColumnsAlias = "student_exceptions.id as student_exceptions_id, student_exceptions.student_id as student_exceptions_student_id, student_exceptions.branch_id as student_exceptions_branch_id, student_exceptions.type as student_exceptions_type, student_exceptions.value as student_exceptions_value";
				public static string UpdateTable = "Update student_exceptions set student_id = @student_id, branch_id = @branch_id, type = @type, value = @value where id = @id";
				public static string Delete = "Delete from student_exceptions where id = @id";
				public static string Select = "Select * from student_exceptions where id = @id";
				public static string InsertTable = "Insert into student_exceptions(student_id, branch_id, type, value)Values(@student_id, @branch_id, @type, @value)";
			}
			/// <summary>
			/// </summary>
			public static class StudentsChildren
			{
			public static string TableName  = "students_children";
			public static string SelectAllTable  = "Select * from students_children";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "students_children_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StudentId = new ColumnDetails()
				{
					 Name="student_id",
					 FullName= "students_children_student_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails FirstName = new ColumnDetails()
				{
					 Name="first_name",
					 FullName= "students_children_first_name"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails LastName = new ColumnDetails()
				{
					 Name="last_name",
					 FullName= "students_children_last_name"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Gender = new ColumnDetails()
				{
					 Name="gender",
					 FullName= "students_children_gender"
				};
			/// <summary>
			///Type: return decimal
			/// </summary>
				public static ColumnDetails Age = new ColumnDetails()
				{
					 Name="age",
					 FullName= "students_children_age"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Status = new ColumnDetails()
				{
					 Name="status",
					 FullName= "students_children_status"
				};
				public static string allColumnsAlias = "students_children.id as students_children_id, students_children.student_id as students_children_student_id, students_children.first_name as students_children_first_name, students_children.last_name as students_children_last_name, students_children.gender as students_children_gender, students_children.age as students_children_age, students_children.status as students_children_status";
				public static string UpdateTable = "Update students_children set student_id = @student_id, first_name = @first_name, last_name = @last_name, gender = @gender, age = @age, status = @status where id = @id";
				public static string Delete = "Delete from students_children where id = @id";
				public static string Select = "Select * from students_children where id = @id";
				public static string InsertTable = "Insert into students_children(student_id, first_name, last_name, gender, age, status)Values(@student_id, @first_name, @last_name, @gender, @age, @status)";
			}
			/// <summary>
			/// </summary>
			public static class UserClaims
			{
			public static string TableName  = "user_claims";
			public static string SelectAllTable  = "Select * from user_claims";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "user_claims_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails UserId = new ColumnDetails()
				{
					 Name="user_id",
					 FullName= "user_claims_user_id"
				};
			/// <summary>
			///Type: return longtext
			/// </summary>
				public static ColumnDetails ClaimType = new ColumnDetails()
				{
					 Name="claim_type",
					 FullName= "user_claims_claim_type"
				};
			/// <summary>
			///Type: return longtext
			/// </summary>
				public static ColumnDetails ClaimValue = new ColumnDetails()
				{
					 Name="claim_value",
					 FullName= "user_claims_claim_value"
				};
				public static string allColumnsAlias = "user_claims.id as user_claims_id, user_claims.user_id as user_claims_user_id, user_claims.claim_type as user_claims_claim_type, user_claims.claim_value as user_claims_claim_value";
				public static string UpdateTable = "Update user_claims set id = @id, user_id = @user_id, claim_type = @claim_type, claim_value = @claim_value where id = @id";
				public static string Delete = "Delete from user_claims where id = @id";
				public static string Select = "Select * from user_claims where id = @id";
				public static string InsertTable = "Insert into user_claims(id, user_id, claim_type, claim_value)Values(@id, @user_id, @claim_type, @claim_value)";
			}
			/// <summary>
			/// </summary>
			public static class UserExtraDetails
			{
			public static string TableName  = "user_extra_details";
			public static string SelectAllTable  = "Select * from user_extra_details";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails UserId = new ColumnDetails()
				{
					 Name="user_id",
					 FullName= "user_extra_details_user_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails IdentityNumber = new ColumnDetails()
				{
					 Name="identity_number",
					 FullName= "user_extra_details_identity_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails PhoneNumber = new ColumnDetails()
				{
					 Name="phone_number",
					 FullName= "user_extra_details_phone_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails CellphoneNumber = new ColumnDetails()
				{
					 Name="cellphone_number",
					 FullName= "user_extra_details_cellphone_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Image = new ColumnDetails()
				{
					 Name="image",
					 FullName= "user_extra_details_image"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails AddressId = new ColumnDetails()
				{
					 Name="address_id",
					 FullName= "user_extra_details_address_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails FirstName = new ColumnDetails()
				{
					 Name="first_name",
					 FullName= "user_extra_details_first_name"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails LastName = new ColumnDetails()
				{
					 Name="last_name",
					 FullName= "user_extra_details_last_name"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Email = new ColumnDetails()
				{
					 Name="email",
					 FullName= "user_extra_details_email"
				};
				public static string allColumnsAlias = "user_extra_details.user_id as user_extra_details_user_id, user_extra_details.identity_number as user_extra_details_identity_number, user_extra_details.phone_number as user_extra_details_phone_number, user_extra_details.cellphone_number as user_extra_details_cellphone_number, user_extra_details.image as user_extra_details_image, user_extra_details.address_id as user_extra_details_address_id, user_extra_details.first_name as user_extra_details_first_name, user_extra_details.last_name as user_extra_details_last_name, user_extra_details.email as user_extra_details_email";
				public static string UpdateTable = "Update user_extra_details set user_id = @user_id, identity_number = @identity_number, phone_number = @phone_number, cellphone_number = @cellphone_number, image = @image, address_id = @address_id, first_name = @first_name, last_name = @last_name, email = @email where user_id = @user_id";
				public static string Delete = "Delete from user_extra_details where user_id = @user_id";
				public static string Select = "Select * from user_extra_details where user_id = @user_id";
				public static string InsertTable = "Insert into user_extra_details(user_id, identity_number, phone_number, cellphone_number, image, address_id, first_name, last_name, email)Values(@user_id, @identity_number, @phone_number, @cellphone_number, @image, @address_id, @first_name, @last_name, @email)";
			}
			/// <summary>
			/// </summary>
			public static class Users
			{
			public static string TableName  = "users";
			public static string SelectAllTable  = "Select * from users";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "users_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Email = new ColumnDetails()
				{
					 Name="email",
					 FullName= "users_email"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails EmailConfirmed = new ColumnDetails()
				{
					 Name="email_confirmed",
					 FullName= "users_email_confirmed"
				};
			/// <summary>
			///Type: return longtext
			/// </summary>
				public static ColumnDetails PasswordHash = new ColumnDetails()
				{
					 Name="password_hash",
					 FullName= "users_password_hash"
				};
			/// <summary>
			///Type: return longtext
			/// </summary>
				public static ColumnDetails SecurityStamp = new ColumnDetails()
				{
					 Name="security_stamp",
					 FullName= "users_security_stamp"
				};
			/// <summary>
			///Type: return longtext
			/// </summary>
				public static ColumnDetails PhoneNumber = new ColumnDetails()
				{
					 Name="phone_number",
					 FullName= "users_phone_number"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails PhoneNumberConfirmed = new ColumnDetails()
				{
					 Name="phone_number_confirmed",
					 FullName= "users_phone_number_confirmed"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails TwoFactorEnabled = new ColumnDetails()
				{
					 Name="two_factor_enabled",
					 FullName= "users_two_factor_enabled"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails LockoutEndDateUtc = new ColumnDetails()
				{
					 Name="lockout_end_date_utc",
					 FullName= "users_lockout_end_date_utc"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails LockoutEnabled = new ColumnDetails()
				{
					 Name="lockout_enabled",
					 FullName= "users_lockout_enabled"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails AccessFailedCount = new ColumnDetails()
				{
					 Name="access_failed_count",
					 FullName= "users_access_failed_count"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails UserName = new ColumnDetails()
				{
					 Name="user_name",
					 FullName= "users_user_name"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails PasswordCreated = new ColumnDetails()
				{
					 Name="password_created",
					 FullName= "users_password_created"
				};
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static ColumnDetails PasswordExpired = new ColumnDetails()
				{
					 Name="password_expired",
					 FullName= "users_password_expired"
				};
				public static string allColumnsAlias = "users.id as users_id, users.email as users_email, users.email_confirmed as users_email_confirmed, users.password_hash as users_password_hash, users.security_stamp as users_security_stamp, users.phone_number as users_phone_number, users.phone_number_confirmed as users_phone_number_confirmed, users.two_factor_enabled as users_two_factor_enabled, users.lockout_end_date_utc as users_lockout_end_date_utc, users.lockout_enabled as users_lockout_enabled, users.access_failed_count as users_access_failed_count, users.user_name as users_user_name, users.password_created as users_password_created, users.password_expired as users_password_expired";
				public static string UpdateTable = "Update users set id = @id, email = @email, email_confirmed = @email_confirmed, password_hash = @password_hash, security_stamp = @security_stamp, phone_number = @phone_number, phone_number_confirmed = @phone_number_confirmed, two_factor_enabled = @two_factor_enabled, lockout_end_date_utc = @lockout_end_date_utc, lockout_enabled = @lockout_enabled, access_failed_count = @access_failed_count, user_name = @user_name, password_created = @password_created, password_expired = @password_expired where id = @id";
				public static string Delete = "Delete from users where id = @id";
				public static string Select = "Select * from users where id = @id";
				public static string InsertTable = "Insert into users(id, email, email_confirmed, password_hash, security_stamp, phone_number, phone_number_confirmed, two_factor_enabled, lockout_end_date_utc, lockout_enabled, access_failed_count, user_name, password_created, password_expired)Values(@id, @email, @email_confirmed, @password_hash, @security_stamp, @phone_number, @phone_number_confirmed, @two_factor_enabled, @lockout_end_date_utc, @lockout_enabled, @access_failed_count, @user_name, @password_created, @password_expired)";
			}
			/// <summary>
			/// </summary>
			public static class UserLogins
			{
			public static string TableName  = "user_logins";
			public static string SelectAllTable  = "Select * from user_logins";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails LoginProvider = new ColumnDetails()
				{
					 Name="login_provider",
					 FullName= "user_logins_login_provider"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails ProviderKey = new ColumnDetails()
				{
					 Name="provider_key",
					 FullName= "user_logins_provider_key"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails UserId = new ColumnDetails()
				{
					 Name="user_id",
					 FullName= "user_logins_user_id"
				};
				public static string allColumnsAlias = "user_logins.login_provider as user_logins_login_provider, user_logins.provider_key as user_logins_provider_key, user_logins.user_id as user_logins_user_id";
				public static string UpdateTable = "Update user_logins set login_provider = @login_provider, provider_key = @provider_key, user_id = @user_id where login_provider = @login_provider";
				public static string Delete = "Delete from user_logins where login_provider = @login_provider";
				public static string Select = "Select * from user_logins where login_provider = @login_provider";
				public static string InsertTable = "Insert into user_logins(login_provider, provider_key, user_id)Values(@login_provider, @provider_key, @user_id)";
			}
			/// <summary>
			/// </summary>
			public static class UserRoles
			{
			public static string TableName  = "user_roles";
			public static string SelectAllTable  = "Select * from user_roles";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails UserId = new ColumnDetails()
				{
					 Name="user_id",
					 FullName= "user_roles_user_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails RoleId = new ColumnDetails()
				{
					 Name="role_id",
					 FullName= "user_roles_role_id"
				};
				public static string allColumnsAlias = "user_roles.user_id as user_roles_user_id, user_roles.role_id as user_roles_role_id";
				public static string UpdateTable = "Update user_roles set user_id = @user_id, role_id = @role_id where user_id = @user_id";
				public static string Delete = "Delete from user_roles where user_id = @user_id";
				public static string Select = "Select * from user_roles where user_id = @user_id";
				public static string InsertTable = "Insert into user_roles(user_id, role_id)Values(@user_id, @role_id)";
			}
			/// <summary>
			/// </summary>
			public static class ExamsRules
			{
			public static string TableName  = "exams_rules";
			public static string SelectAllTable  = "Select * from exams_rules";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "exams_rules_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "exams_rules_branch_id"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsRequiredExams = new ColumnDetails()
				{
					 Name="is_required_exams",
					 FullName= "exams_rules_is_required_exams"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails ExamsPerPeriod = new ColumnDetails()
				{
					 Name="exams_per_period",
					 FullName= "exams_rules_exams_per_period"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails ExamsPeriod = new ColumnDetails()
				{
					 Name="exams_period",
					 FullName= "exams_rules_exams_period"
				};
				public static string allColumnsAlias = "exams_rules.id as exams_rules_id, exams_rules.branch_id as exams_rules_branch_id, exams_rules.is_required_exams as exams_rules_is_required_exams, exams_rules.exams_per_period as exams_rules_exams_per_period, exams_rules.exams_period as exams_rules_exams_period";
				public static string UpdateTable = "Update exams_rules set branch_id = @branch_id, is_required_exams = @is_required_exams, exams_per_period = @exams_per_period, exams_period = @exams_period where id = @id";
				public static string Delete = "Delete from exams_rules where id = @id";
				public static string Select = "Select * from exams_rules where id = @id";
				public static string InsertTable = "Insert into exams_rules(branch_id, is_required_exams, exams_per_period, exams_period)Values(@branch_id, @is_required_exams, @exams_per_period, @exams_period)";
			}
			/// <summary>
			/// </summary>
			public static class AttendanceRules
			{
			public static string TableName  = "attendance_rules";
			public static string SelectAllTable  = "Select * from attendance_rules";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "attendance_rules_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "attendance_rules_branch_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails MaximumLateness = new ColumnDetails()
				{
					 Name="maximum_lateness",
					 FullName= "attendance_rules_maximum_lateness"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails MaximumAbsences = new ColumnDetails()
				{
					 Name="maximum_absences",
					 FullName= "attendance_rules_maximum_absences"
				};
				public static string allColumnsAlias = "attendance_rules.id as attendance_rules_id, attendance_rules.branch_id as attendance_rules_branch_id, attendance_rules.maximum_lateness as attendance_rules_maximum_lateness, attendance_rules.maximum_absences as attendance_rules_maximum_absences";
				public static string UpdateTable = "Update attendance_rules set branch_id = @branch_id, maximum_lateness = @maximum_lateness, maximum_absences = @maximum_absences where id = @id";
				public static string Delete = "Delete from attendance_rules where id = @id";
				public static string Select = "Select * from attendance_rules where id = @id";
				public static string InsertTable = "Insert into attendance_rules(branch_id, maximum_lateness, maximum_absences)Values(@branch_id, @maximum_lateness, @maximum_absences)";
			}
			/// <summary>
			/// </summary>
			public static class BranchStudyPath
			{
			public static string TableName  = "branch_study_path";
			public static string SelectAllTable  = "Select * from branch_study_path";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "branch_study_path_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "branch_study_path_branch_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StudyPathId = new ColumnDetails()
				{
					 Name="study_path_id",
					 FullName= "branch_study_path_study_path_id"
				};
				public static string allColumnsAlias = "branch_study_path.id as branch_study_path_id, branch_study_path.branch_id as branch_study_path_branch_id, branch_study_path.study_path_id as branch_study_path_study_path_id";
				public static string UpdateTable = "Update branch_study_path set branch_id = @branch_id, study_path_id = @study_path_id where id = @id";
				public static string Delete = "Delete from branch_study_path where id = @id";
				public static string Select = "Select * from branch_study_path where id = @id";
				public static string InsertTable = "Insert into branch_study_path(branch_id, study_path_id)Values(@branch_id, @study_path_id)";
			}
			/// <summary>
			/// </summary>
			public static class BranchStudents
			{
			public static string TableName  = "branch_students";
			public static string SelectAllTable  = "Select * from branch_students";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "branch_students_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StudentId = new ColumnDetails()
				{
					 Name="student_id",
					 FullName= "branch_students_student_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "branch_students_branch_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchStudyPathId = new ColumnDetails()
				{
					 Name="branch_study_path_id",
					 FullName= "branch_students_branch_study_path_id"
				};
			/// <summary>
			///Type: return date
			/// </summary>
				public static ColumnDetails EntryHebrewDate = new ColumnDetails()
				{
					 Name="entry_hebrew_date",
					 FullName= "branch_students_entry_hebrew_date"
				};
			/// <summary>
			///Type: return date
			/// </summary>
				public static ColumnDetails EntryGregorianDate = new ColumnDetails()
				{
					 Name="entry_gregorian_date",
					 FullName= "branch_students_entry_gregorian_date"
				};
			/// <summary>
			///Type: return date
			/// </summary>
				public static ColumnDetails ReleaseHebrewDate = new ColumnDetails()
				{
					 Name="release_hebrew_date",
					 FullName= "branch_students_release_hebrew_date"
				};
			/// <summary>
			///Type: return date
			/// </summary>
				public static ColumnDetails ReleaseGregorianDate = new ColumnDetails()
				{
					 Name="release_gregorian_date",
					 FullName= "branch_students_release_gregorian_date"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsActive = new ColumnDetails()
				{
					 Name="is_active",
					 FullName= "branch_students_is_active"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Status = new ColumnDetails()
				{
					 Name="status",
					 FullName= "branch_students_status"
				};               
                public static string allColumnsAlias = "branch_students.id as branch_students_id, branch_students.student_id as branch_students_student_id, branch_students.branch_id as branch_students_branch_id, branch_students.branch_study_path_id as branch_students_branch_study_path_id, branch_students.entry_hebrew_date as branch_students_entry_hebrew_date, branch_students.entry_gregorian_date as branch_students_entry_gregorian_date, branch_students.release_hebrew_date as branch_students_release_hebrew_date, branch_students.release_gregorian_date as branch_students_release_gregorian_date, branch_students.is_active as branch_students_is_active, branch_students.status as branch_students_status ";
				public static string UpdateTable = "Update branch_students set student_id = @student_id, branch_id = @branch_id, branch_study_path_id = @branch_study_path_id, entry_hebrew_date = @entry_hebrew_date, entry_gregorian_date = @entry_gregorian_date, release_hebrew_date = @release_hebrew_date, release_gregorian_date = @release_gregorian_date, is_active = @is_active, status = @status where id = @id";
				public static string Delete = "Delete from branch_students where id = @id";
				public static string Select = "Select * from branch_students where id = @id";
				public static string InsertTable = "Insert into branch_students(student_id, branch_id, branch_study_path_id, entry_hebrew_date, entry_gregorian_date, release_hebrew_date, release_gregorian_date, is_active, statusValues(@student_id, @branch_id, @branch_study_path_id, @entry_hebrew_date, @entry_gregorian_date, @release_hebrew_date, @release_gregorian_date, @is_active, @status)";
			}
			/// <summary>
			/// </summary>
			public static class BranchStaff
			{
			public static string TableName  = "branch_staff";
			public static string SelectAllTable  = "Select * from branch_staff";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BranchId = new ColumnDetails()
				{
					 Name="branch_id",
					 FullName= "branch_staff_branch_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails UserId = new ColumnDetails()
				{
					 Name="user_id",
					 FullName= "branch_staff_user_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails RoleId = new ColumnDetails()
				{
					 Name="role_id",
					 FullName= "branch_staff_role_id"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsContact = new ColumnDetails()
				{
					 Name="is_contact",
					 FullName= "branch_staff_is_contact"
				};
				public static string allColumnsAlias = "branch_staff.branch_id as branch_staff_branch_id, branch_staff.user_id as branch_staff_user_id, branch_staff.role_id as branch_staff_role_id, branch_staff.is_contact as branch_staff_is_contact";
				public static string UpdateTable = "Update branch_staff set branch_id = @branch_id, user_id = @user_id, role_id = @role_id, is_contact = @is_contact where branch_id = @branch_id";
				public static string Delete = "Delete from branch_staff where branch_id = @branch_id";
				public static string Select = "Select * from branch_staff where branch_id = @branch_id";
				public static string InsertTable = "Insert into branch_staff(branch_id, user_id, role_id, is_contact)Values(@branch_id, @user_id, @role_id, @is_contact)";
			}
			/// <summary>
			/// </summary>
			public static class Students
			{
			public static string TableName  = "students";
			public static string SelectAllTable  = "Select * from students";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "students_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails BankId = new ColumnDetails()
				{
					 Name="bank_id",
					 FullName= "students_bank_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails ChildrenNumber = new ColumnDetails()
				{
					 Name="children_number",
					 FullName= "students_children_number"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails MarriedChildrenNumber = new ColumnDetails()
				{
					 Name="married_children_number",
					 FullName= "students_married_children_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails PhoneNumber = new ColumnDetails()
				{
					 Name="phone_number",
					 FullName= "students_phone_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails CellphoneNumber = new ColumnDetails()
				{
					 Name="cellphone_number",
					 FullName= "students_cellphone_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails IdentityNumber = new ColumnDetails()
				{
					 Name="identity_number",
					 FullName= "students_identity_number"
				};
			/// <summary>
			///Type: return date
			/// </summary>
				public static ColumnDetails BornDate = new ColumnDetails()
				{
					 Name="born_date",
					 FullName= "students_born_date"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails AccountNumber = new ColumnDetails()
				{
					 Name="account_number",
					 FullName= "students_account_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails WifeName = new ColumnDetails()
				{
					 Name="wife_name",
					 FullName= "students_wife_name"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails JobWife = new ColumnDetails()
				{
					 Name="job_wife",
					 FullName= "students_job_wife"
				};
			/// <summary>
			///Type: return decimal
			/// </summary>
				public static ColumnDetails MonthlyIncome = new ColumnDetails()
				{
					 Name="monthly_income",
					 FullName= "students_monthly_income"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Image = new ColumnDetails()
				{
					 Name="image",
					 FullName= "students_image"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails IdCard = new ColumnDetails()
				{
					 Name="id_card",
					 FullName= "students_id_card"
				};
			/// <summary>
			///Type: return decimal
			/// </summary>
				public static ColumnDetails TravelExpenses = new ColumnDetails()
				{
					 Name="travel_expenses",
					 FullName= "students_travel_expenses"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails AddressId = new ColumnDetails()
				{
					 Name="address_id",
					 FullName= "students_address_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails FaxNumber = new ColumnDetails()
				{
					 Name="fax_number",
					 FullName= "students_fax_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails FirstName = new ColumnDetails()
				{
					 Name="first_name",
					 FullName= "students_first_name"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails LastName = new ColumnDetails()
				{
					 Name="last_name",
					 FullName= "students_last_name"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsActive = new ColumnDetails()
				{
					 Name="is_active",
					 FullName= "students_is_active"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails TravelExpensesCurrency = new ColumnDetails()
				{
					 Name="travel_expenses_currency",
					 FullName= "students_travel_expenses_currency"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails MonthlyIncomeCurrency = new ColumnDetails()
				{
					 Name="monthly_income_currency",
					 FullName= "students_monthly_income_currency"
				};              
                public static string allColumnsAlias = "students.id as students_id, students.bank_id as students_bank_id, students.children_number as students_children_number, students.married_children_number as students_married_children_number, students.phone_number as students_phone_number, students.cellphone_number as students_cellphone_number, students.identity_number as students_identity_number, students.born_date as students_born_date, students.account_number as students_account_number, students.wife_name as students_wife_name, students.job_wife as students_job_wife, students.monthly_income as students_monthly_income, students.image as students_image, students.id_card as students_id_card, students.travel_expenses as students_travel_expenses, students.address_id as students_address_id, students.fax_number as students_fax_number, students.first_name as students_first_name, students.last_name as students_last_name, students.is_active as students_is_active, students.travel_expenses_currency as students_travel_expenses_currency, students.monthly_income_currency as students_monthly_income_currency";
				public static string UpdateTable = "Update students set bank_id = @bank_id, children_number = @children_number, married_children_number = @married_children_number, phone_number = @phone_number, cellphone_number = @cellphone_number, identity_number = @identity_number, born_date = @born_date, account_number = @account_number, wife_name = @wife_name, job_wife = @job_wife, monthly_income = @monthly_income, image = @image, id_card = @id_card, travel_expenses = @travel_expenses, address_id = @address_id, fax_number = @fax_number, first_name = @first_name, last_name = @last_name, is_active = @is_active, travel_expenses_currency = @travel_expenses_currency, monthly_income_currency = @monthly_income_currency where id = @id";
				public static string Delete = "Delete from students where id = @id";
				public static string Select = "Select * from students where id = @id";
				public static string InsertTable = "Insert into students(bank_id, children_number, married_children_number, phone_number, cellphone_number, identity_number, born_date, account_number, wife_name, job_wife, monthly_income, image, id_card, travel_expenses, address_id, fax_number, first_name, last_name, is_active, travel_expenses_currency, monthly_income_currency)Values(@bank_id, @children_number, @married_children_number, @phone_number, @cellphone_number, @identity_number, @born_date, @account_number, @wife_name, @job_wife, @monthly_income, @image, @id_card, @travel_expenses, @address_id, @fax_number, @first_name, @last_name, @is_active, @travel_expenses_currency, @monthly_income_currency)";
			}
			/// <summary>
			/// </summary>
			public static class Branches
			{
			public static string TableName  = "branches";
			public static string SelectAllTable  = "Select * from branches";
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails Id = new ColumnDetails()
				{
					 Name="id",
					 FullName= "branches_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails TypeId = new ColumnDetails()
				{
					 Name="type_id",
					 FullName= "branches_type_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails HeadId = new ColumnDetails()
				{
					 Name="head_id",
					 FullName= "branches_head_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails AddressId = new ColumnDetails()
				{
					 Name="address_id",
					 FullName= "branches_address_id"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails InstitutionId = new ColumnDetails()
				{
					 Name="institution_id",
					 FullName= "branches_institution_id"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Name = new ColumnDetails()
				{
					 Name="name",
					 FullName= "branches_name"
				};
			/// <summary>
			///Type: return date
			/// </summary>
				public static ColumnDetails OpeningDate = new ColumnDetails()
				{
					 Name="opening_date",
					 FullName= "branches_opening_date"
				};
			/// <summary>
			///Type: return int
			/// </summary>
				public static ColumnDetails StudentsNumber = new ColumnDetails()
				{
					 Name="students_number",
					 FullName= "branches_students_number"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails StudySubjects = new ColumnDetails()
				{
					 Name="study_subjects",
					 FullName= "branches_study_subjects"
				};
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static ColumnDetails IsActive = new ColumnDetails()
				{
					 Name="is_active",
					 FullName= "branches_is_active"
				};
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static ColumnDetails Image = new ColumnDetails()
				{
					 Name="image",
					 FullName= "branches_image"
				};
               public static string allColumnsAlias = "branches.id as branches_id, branches.type_id as branches_type_id, branches.head_id as branches_head_id, branches.address_id as branches_address_id, branches.institution_id as branches_institution_id, branches.name as branches_name, branches.opening_date as branches_opening_date, branches.students_number as branches_students_number, branches.study_subjects as branches_study_subjects, branches.is_active as branches_is_active, branches.image as branches_image";
               // public static string allColumnsAlias = "branches.id as branches_id, branches.type_id as branches_type_id, branches.head_id as branches_head_id, branches.address_id as branches_address_id, branches.institution_id as branches_institution_id, branches.name as branches_name, branches.students_number as branches_students_number, branches.study_subjects as branches_study_subjects, branches.is_active as branches_is_active, branches.image as branches_image";

                public static string UpdateTable = "Update branches set type_id = @type_id, head_id = @head_id, address_id = @address_id, institution_id = @institution_id, name = @name, opening_date = @opening_date, students_number = @students_number, study_subjects = @study_subjects, is_active = @is_active, image = @image where id = @id";
				public static string Delete = "Delete from branches where id = @id";
				public static string Select = "Select * from branches where id = @id";
				public static string InsertTable = "Insert into branches(type_id, head_id, address_id, institution_id, name, opening_date, students_number, study_subjects, is_active, image)Values(@type_id, @head_id, @address_id, @institution_id, @name, @opening_date, @students_number, @study_subjects, @is_active, @image)";
			}

            public static class StudentPayment
            {
                public static string TableName = "student_payment";
                public static string SelectAllTable = "Select * from student_payment";
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails Id = new ColumnDetails()
                {
                    Name = "id",
                    FullName = "student_payment_id"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails studentId = new ColumnDetails()
                {
                    Name = "student_id",
                    FullName = "student_payment_student_id"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails Month = new ColumnDetails()
                {
                    Name = "month",
                    FullName = "student_payment_month"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails Year = new ColumnDetails()
                {
                    Name = "year",
                    FullName = "student_payment_year"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails PaymentSum = new ColumnDetails()
                {
                    Name = "payment_sum",
                    FullName = "student_payment_payment_sum"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails AttendanceSum = new ColumnDetails()
                {
                    Name = "attendance_sum",
                    FullName = "student_payment_attendance_sum"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails ExamsSum = new ColumnDetails()
                {
                    Name = "exams_sum",
                    FullName = "student_payment_exams_sum"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails StateBudgetSum = new ColumnDetails()
                {
                    Name = "state_budget_sum",
                    FullName = "student_payment_state_budget_sum"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails HealthSupportSum = new ColumnDetails()
                {
                    Name = "health_support_sum",
                    FullName = "student_payment_health_support_sum"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails DentalHealthSupportSum = new ColumnDetails()
                {
                    Name = "dental_health_support_sum",
                    FullName = "student_payment_dental_health_support_sum"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails FinancialSupportSum = new ColumnDetails()
                {
                    Name = "financial_support_sum",
                    FullName = "student_payment_financial_support_sum"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails LoansGivenSum = new ColumnDetails()
                {
                    Name = "loans_given_sum",
                    FullName = "student_payment_loans_given_sum"
                };
                /// <summary>
                ///Type: return int
                /// </summary>
                public static ColumnDetails LoansReturnSum = new ColumnDetails()
                {
                    Name = "loans_return_sum",
                    FullName = "student_payment_loans_return_sum"
                };
                public static string allColumnsAlias = "select StudentPayment.Id as student_payment_id,StudentPayment.StudentId as student_payment_student_id,StudentPayment.Month as  student_payment_month,StudentPayment.Year as student_payment_year,StudentPayment.PaymentSum as student_payment_payment_sum,StudentPayment.attendanceSum as student_payment_attendance_sum,StudentPayment.examsSum as student_payment_exams_sum,StudentPayment.StateBudgetSum as student_payment_state_budget_sum,StudentPayment.HealthSupportSum as student_payment_health_support_sum,StudentPayment.DentalHealthSupportSum as student_payment_dental_health_support_sum,StudentPayment.FinancialSupportSum as student_payment_financial_support_sum,StudentPayment.LoansGivenSum as student_payment_loans_given_sum,StudentPayment.LoansReturnSum as student_payment_loans_return_sum";
                public static string UpdateTable = "Update student_payment set student_id = @student_id, month = @month,year=@year,payment_sum=@payment_sum,attendance_sum=@attendance_sum,exams_sum=@exams_sum,state_budget_sum=@state_budget_sum,health_support_sum=@health_support_sum,dental_health_support_sum=@dental_health_support_sum,financial_support_sum=@financial_support_sum,loans_given_sum=@loans_given_sum,loans_return_sum=@loans_return_sum where id = @id";
                public static string Delete = "Delete from student_payment where id = @id";
                public static string Select = "Select * from student_payment where id = @id";
                public static string InsertTable = "Insert into student_payment(student_id, month, year, payment_sum, attendance_sum, exams_sum, state_budget_sum, health_support_sum, dental_health_support_sum, financial_support_sum, loans_given_sum, loans_return_sum) Values(@student_id, @month, @year, @payment_sum, @attendance_sum, @exams_sum, @state_budget_sum, @health_support_sum, @dental_health_support_sum, @financial_support_sum, @loans_given_sum, @loans_return_sum)";
            }
        }
		public static class StoredProcedures
		{
		}
		public static class Functions
		{
		}
		public static class Views
		{
		}
	}
}
