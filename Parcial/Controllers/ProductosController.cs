using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Parcial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private static List<Producto> list = new List<Producto>()
        {

            new() { Descripcion = "Cuadernos", Marca = "Norma", Categoria = "Cuadernos", Estado = "Dispobible" },

        };

        private static int codigoActual = 1;
        public static List<Producto> List { get => list; set => list = value; }

        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            return List;
        }

        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto producto)
        {
            producto.Codigo = AsignarCodigo();
            List.Add(producto);
            return Ok(producto);
        }


        private static int AsignarCodigo()
        {
            return ++codigoActual;
        }
    }


}
