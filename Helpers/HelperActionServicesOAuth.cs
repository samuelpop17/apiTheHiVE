using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiProyectoConjuntoAWSRedSocial.Helpers
{
    public class HelperActionServicesOAuth
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }

        public HelperActionServicesOAuth(string secretKey, string audience, string issuer)
        {
            this.Issuer = issuer;
            this.Audience = audience;
            this.SecretKey = secretKey;
        }

        // Método para generar la clave de seguridad a partir del SecretKey
        public SymmetricSecurityKey GetKeyToken()
        {
            byte[] data = Encoding.UTF8.GetBytes(this.SecretKey);
            return new SymmetricSecurityKey(data);
        }

        // Método para configurar las opciones de JwtBearer
        public Action<JwtBearerOptions> GetJwtBearerOptions()
        {
            return options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,                    
                    ValidIssuer = this.Issuer,
                    ValidAudience = this.Audience,
                    IssuerSigningKey = this.GetKeyToken(),                    
                };
            };
        }

        // Método para configurar el esquema de autenticación
        public Action<AuthenticationOptions> GetAuthenticateSchema()
        {
            return options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            };
        }
    }
}
