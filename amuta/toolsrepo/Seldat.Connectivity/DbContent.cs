namespace Seldat.Connectivity
{
	public static class DbContent
	{
		public static class Tables
		{
			/// <summary>
			/// </summary>
			public static class roles
			{
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static string Id = "Id";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static string Name = "Name";
			}
			/// <summary>
			/// </summary>
			public static class userclaims
			{
			/// <summary>
			///Type: return int
			/// </summary>
				public static string Id = "Id";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static string UserId = "UserId";
			/// <summary>
			///Type: return longtext
			/// </summary>
				public static string ClaimType = "ClaimType";
			/// <summary>
			///Type: return longtext
			/// </summary>
				public static string ClaimValue = "ClaimValue";
			}
			/// <summary>
			/// </summary>
			public static class userlogins
			{
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static string LoginProvider = "LoginProvider";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static string ProviderKey = "ProviderKey";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static string UserId = "UserId";
			}
			/// <summary>
			/// </summary>
			public static class userroles
			{
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static string UserId = "UserId";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static string RoleId = "RoleId";
			}
			/// <summary>
			/// </summary>
			public static class users
			{
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static string Id = "Id";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static string Email = "Email";
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static string EmailConfirmed = "EmailConfirmed";
			/// <summary>
			///Type: return longtext
			/// </summary>
				public static string PasswordHash = "PasswordHash";
			/// <summary>
			///Type: return longtext
			/// </summary>
				public static string SecurityStamp = "SecurityStamp";
			/// <summary>
			///Type: return longtext
			/// </summary>
				public static string PhoneNumber = "PhoneNumber";
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static string PhoneNumberConfirmed = "PhoneNumberConfirmed";
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static string TwoFactorEnabled = "TwoFactorEnabled";
			/// <summary>
			///Type: return datetime
			/// </summary>
				public static string LockoutEndDateUtc = "LockoutEndDateUtc";
			/// <summary>
			///Type: return tinyint
			/// </summary>
				public static string LockoutEnabled = "LockoutEnabled";
			/// <summary>
			///Type: return int
			/// </summary>
				public static string AccessFailedCount = "AccessFailedCount";
			/// <summary>
			///Type: return varchar
			/// </summary>
				public static string UserName = "UserName";
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
