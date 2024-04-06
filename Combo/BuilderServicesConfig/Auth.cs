//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;

//using System.Text;

//namespace Combo.BuilderServicesConfig;

//public static class Auth
//{
//	public static void AddAuth(IServiceCollection services, )
//	{
//		services.AddAuthentication(options =>
//		{
//			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//			options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//		})
//		.AddJwtBearer(
//			options =>
//				options.TokenValidationParameters = new TokenValidationParameters
//				{
//					ValidateIssuerSigningKey = true,
//					IssuerSigningKey = new SymmetricSecurityKey(
//						Encoding.UTF8.GetBytes(applicationSettings.JWT.AccessSecret)
//					),
//					ValidateIssuer = true,
//					ValidIssuer = applicationSettings.JWT.ValidIssuer,
//					ValidateAudience = true,
//					ValidAudience = applicationSettings.JWT.ValidAudience,
//					ClockSkew = TimeSpan.FromSeconds(30)
//				}
//		)
//		.AddJwtBearer(
//			"Refresh",
//			options =>
//				options.TokenValidationParameters = new TokenValidationParameters
//				{
//					ValidateIssuerSigningKey = true,
//					IssuerSigningKey = new SymmetricSecurityKey(
//						Encoding.UTF8.GetBytes(applicationSettings.JWT.RefreshSecret)
//					),
//					ValidateIssuer = true,
//					ValidIssuer = applicationSettings.JWT.ValidIssuer,
//					ValidateAudience = true,
//					ValidAudience = applicationSettings.JWT.ValidAudience,
//					ClockSkew = TimeSpan.FromSeconds(30)
//				}
//		);
//	}
//}
