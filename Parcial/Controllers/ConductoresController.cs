using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductoresController : ControllerBase
    {

        private static List<Conductor> list = new List<Conductor>()
        {

            new() {Id = 1, Nombre = "Sergio", Apellido = "Cantillo", Licencia = "12364844", FechaNacimiento = "1998/12/26" , idvehiculo = "sin vehiculo"}

        };

        private static int idActual = 1;
        public static List<Conductor> List { get => list; set => list = value; }

        [HttpGet]
        public ActionResult<List<Conductor>> Get()
        {
            return List;
        }

        [HttpPost]
        public ActionResult<Conductor> Post([FromBody] Conductor conductor)
        {
            conductor.Id = Asignar();
            List.Add(conductor);
            return Ok(conductor);
        }

        private static int Asignar()
        {
            return ++idActual;
        }
    }


}
