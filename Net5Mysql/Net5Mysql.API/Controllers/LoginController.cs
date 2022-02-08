using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Net5Mysql.API.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Net5Mysql.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ContextCarrito _context;
        private readonly IConfiguration _configuration;

        public LoginController(ContextCarrito context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<Usuario>> Login(Models.Login dataLogin)
        {
            var user = await _context.Usuarios.Where(data => data.estado == "A"
                                                    && data.correo.Equals(dataLogin.username)
                                                    && data.clave.Equals(dataLogin.password))
                                                    .Include(rol=> rol.Rol)
                                                    .FirstOrDefaultAsync();

            if (user != null)
            {
                return Ok(new {
                    token = generarTokenJWT(user),
                    UsuarioId = user.UsuarioId,
                    UsuarioEmail = user.correo,
                    UsuarioPerson = $"{user.nombres} {user.apellidos}",
                    Perfil = user.Rol.descripcion
                });
            }
            else
            {
                return Unauthorized();
            }
        }

        private object generarTokenJWT(Models.Usuario dataUsuario)
        {
            //Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                   Encoding.UTF8.GetBytes(_configuration["JWT:Clave"])
               );
            var _sigingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );

            var _Header = new JwtHeader(_sigingCredentials);

            //Claims
            var _claims = new[] {
                    new Claim(JwtRegisteredClaimNames.NameId, dataUsuario.UsuarioId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, dataUsuario.correo.ToString()),
                    new Claim("nombre", dataUsuario.nombres.ToString()),
                    new Claim("apellido", dataUsuario.apellidos.ToString()),
            };

            //Payload

            var _Payload = new JwtPayload(
                   issuer: _configuration["JWT:Dominio"],
                   audience: _configuration["JWT:AppApi"],
                   claims: _claims,
                   notBefore: DateTime.UtcNow,
                   expires: DateTime.UtcNow.AddMinutes(1)
               );

            //Token

            var _token = new JwtSecurityToken(_Header, _Payload);

            return new JwtSecurityTokenHandler().WriteToken(_token);


        }


    }
}
