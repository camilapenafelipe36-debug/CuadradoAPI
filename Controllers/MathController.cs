using Microsoft.AspNetCore.Mvc;

namespace CuadradoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet("square/{number}")]
        public IActionResult Square(int number)
        {
            if (number < 0)
            {
                return BadRequest(new
                {
                    mensaje = "El número no puede ser negativo."
                });
            }

            int resultado = number * number;

            return Ok(new
            {
                numero = number,
                cuadrado = resultado
            });
        }
    }
}
