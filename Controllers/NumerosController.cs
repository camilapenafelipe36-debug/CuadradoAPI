using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CuadradoAPI.Models;

namespace CuadradoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumerosController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NumerosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Numeros
        [HttpGet]
        public async Task<IActionResult> GetNumeros()
        {
            try
            {
                string? connectionString = _configuration.GetConnectionString("DefaultConnection");

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    return StatusCode(500, new
                    {
                        error = "No se encontró la cadena de conexión."
                    });
                }

                using var connection = new SqlConnection(connectionString);

                string sql = "SELECT Id, Numero AS Valor, Cuadrado FROM Numeros";

                var numeros = await connection.QueryAsync<Numero>(sql);

                return Ok(numeros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = ex.Message,
                    detalle = ex.InnerException?.Message
                });
            }
        }

        // POST: api/Numeros
        [HttpPost]
        public async Task<IActionResult> GuardarNumero([FromBody] Numero numero)
        {
            try
            {
                string? connectionString = _configuration.GetConnectionString("DefaultConnection");

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    return StatusCode(500, new
                    {
                        error = "No se encontró la cadena de conexión."
                    });
                }

                using var connection = new SqlConnection(connectionString);

                // Calcular el cuadrado
                numero.Cuadrado = numero.Valor * numero.Valor;

                string sql = @"
                    INSERT INTO Numeros (Numero, Cuadrado)
                    VALUES (@Valor, @Cuadrado);

                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int id = await connection.ExecuteScalarAsync<int>(sql, numero);

                numero.Id = id;

                return Ok(new
                {
                    mensaje = "Número guardado correctamente",
                    datos = numero
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = ex.Message,
                    detalle = ex.InnerException?.Message
                });
            }
        }
    }
}