using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TaskManagementAPI.Controllers
{
    /// <summary>
    /// Jwt Token Controller.
    /// </summary>
    [Route("authtoken")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class AuthTokenController : ControllerBase
    {
        /// <summary>
        /// Get Random token.
        /// </summary>
        /// <returns> OauthToken. </returns>
        [HttpPost]
        public IActionResult GetRandomToken()
        {
            if (this.Request.Headers["authorization"].Count > 0)
            {
                var headers = this.Request.Headers["authorization"];
                byte[] data = Convert.FromBase64String(headers[0].Replace("Basic ", string.Empty));
                string base64Decoded = Encoding.ASCII.GetString(data);
                var arr = base64Decoded.Split(":");
                if (arr.Length > 1 && arr[1] == AppData.Jwt.ClientSecret && arr[0] == AppData.Jwt.ClientId)
                {
                    var oauthToken = this.GenerateToken();
                    return this.Ok(oauthToken);
                }
                else
                {
                    return this.Unauthorized("Invalid Client id or secret");
                }
            }
            else if (this.Request.Form["client_secret"] == AppData.Jwt.ClientSecret &&
                this.Request.Form["client_id"] == AppData.Jwt.ClientId)
            {
                var oauthToken = this.GenerateToken();
                return this.Ok(oauthToken);
            }
            else
            {
                return this.Unauthorized("Invalid Client id or secret");
            }
        }

        private OauthToken GenerateToken()
        {
            var key = Encoding.ASCII.GetBytes(AppData.Jwt.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, "taskmanagementteam@gmail.com"),
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(AppData.Jwt.ExpirationInMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(createToken);
            return new OauthToken() { access_token = token, expires_in = 3600, token_type = "Bearer", scope = "readAccess writeAcess" };

            // return new OauthToken() { AccessToken = token, ExpiresIn = 3600, TokenType = "Bearer", Scope = "readAccess writeAcess" };
        }
    }
}
