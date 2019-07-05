namespace Seldat.AspNet.Identity
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
				public static string InsertTable = "Insert into roles(id, name)Values(@id, @name)";
			}
			/// <summary>
			/// </summary>
			public static class Users
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
				public static string InsertTable = "Insert into user_claims(id, user_id, claim_type, claim_value)Values(@id, @user_id, @claim_type, @claim_value)";
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
				public static string InsertTable = "Insert into user_roles(user_id, role_id)Values(@user_id, @role_id)";
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
				public static string InsertTable = "Insert into users(id, email, email_confirmed, password_hash, security_stamp, phone_number, phone_number_confirmed, two_factor_enabled, lockout_end_date_utc, lockout_enabled, access_failed_count, user_name, password_created, password_expired)Values(@id, @email, @email_confirmed, @password_hash, @security_stamp, @phone_number, @phone_number_confirmed, @two_factor_enabled, @lockout_end_date_utc, @lockout_enabled, @access_failed_count, @user_name, @password_created, @password_expired)";
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
