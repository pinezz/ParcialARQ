using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private static List<Vehiculo> list = new List<Vehiculo>()
        {

            new() {Id = 1  , Marca = "Toyota", Placa = "H54125", Modelo = 2021 , idConducor = "Sin conductor" },

        };

        private static int idActual = 1;
        public static List<Vehiculo> List { get => list; set => list = value; }

        [HttpGet]
        public ActionResult<List<Vehiculo>> Get()
        {
            return List;
        }

        [HttpGet("{id}")]
        public ActionResult<Vehiculo> Get(int id)
        {

            Vehiculo vehiculoEncontrado = List.Find(x => x.Id == id);

            if (vehiculoEncontrado is not null)
            {

                return Ok(vehiculoEncontrado);

            }

            return NotFound();
        }



        [HttpPost]
        public ActionResult<Vehiculo> Post([FromBody] Vehiculo vehiculo)
        {
            vehiculo.Id = Asignar();
            List.Add(vehiculo);
            return Ok(vehiculo);
        }

        private static int Asignar()
        {
            return ++idActual;
        }

    }
}
