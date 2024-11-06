namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using System.Security.Claims;
    
    using Datos;
    using Entidades;

    [Route("api/auth")]
    [ApiController]
    public class AutenticacionControlador : ControllerBase
    {
        private readonly UniversidadContext _context;
        private readonly IConfiguration _configuration;

        public AutenticacionControlador(UniversidadContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var usuarioEncontrado = await _context.Usuarios
                    .Include(u => u.Persona)
                    .FirstOrDefaultAsync(u => u.Nombre_usuario == loginRequest.Username && u.Clave == loginRequest.Password);

                if (usuarioEncontrado != null)
                {
                    var token = GenerateRandomToken(usuarioEncontrado);
                    return Ok(new { token });
                }
                else
                {
                    return BadRequest(new { message = "Usuario y/o contraseña incorrectos" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { message = "Error de conexión!" });
            }
        }

        private string GenerateRandomToken(Usuario usuarioEncontrado)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("nombre_usuario", usuarioEncontrado.Nombre_usuario),
                    new Claim("rol", usuarioEncontrado.Rol.ToString()),
                    new Claim("id_persona", usuarioEncontrado.Persona?.Id_persona.ToString() ?? "0")
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}