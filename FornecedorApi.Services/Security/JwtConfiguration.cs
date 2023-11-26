using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FornecedorApi.Services.Security
{
    public class JwtConfiguration
    {
        /// <summary>
        /// Chave secreta para criptografar/descriptografar os tokens
        /// Essa chave deverá ser a mesma utilizada na API de Usuários
        /// </summary>
        private static string SecretKey = @"70BADF66-3A09-4C9F-832A-F56DFC7398B9";

        /// <summary>
        /// Método para configurar o tipo de autenticação do projeto API
        /// de forma a utilizar o framework JWT
        /// </summary>
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
