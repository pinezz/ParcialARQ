using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private static List<Pedido> list = new List<Pedido>()
        {

            new() {Id = 1  , Descripcion = "10 Cuadernos, 5 cajas de lapiz", ListaProductos = [1,2], DireccionOrigen = "Calle 12a sur" , DireccionDestino = "caller 120 a norte", EstadoPedido="Registrado" , idconductor = 0, idvehiculo = 0}

        };

        private static int idActual = 1;
        public static List<Pedido> List { get => list; set => list = value; }

        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            return List;
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(int id)
        {

            Pedido pedidoEncontrado = List.Find(x => x.Id == id);

            if (pedidoEncontrado is not null)
            {

                return Ok(pedidoEncontrado);

            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] Pedido pedido)
        {
            pedido.Id = Asignar();
            List.Add(pedido);
            return Ok(pedido);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pedido pedido)
        {
            Pedido pedidoEncontrado = List.Find(x => x.Id == id);

            if (pedidoEncontrado is not null)
            {

                pedidoEncontrado.Descripcion = pedido.Descripcion;
                pedidoEncontrado.ListaProductos = pedido.ListaProductos;
                pedidoEncontrado.idconductor = pedido.idconductor;
                pedidoEncontrado.idvehiculo = pedido.idvehiculo;


                return Ok($"Pedido {id} actualizado correctamente");
            }



            return NotFound("No se encontró el elemento a actualizar");
        }

        [HttpPatch ("{id}")]
        public ActionResult Patch(int id, [FromBody] Pedido pedido)
        {
            Pedido pedidoEncontrado = List.Find(x => x.Id == id);

            if (pedidoEncontrado is not null)
            {


                pedidoEncontrado.EstadoPedido = pedido.EstadoPedido;
                

                return Ok($"Pedido {id} actualizado correctamente");
            }



            return NotFound("No se encontró el elemento a actualizar");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Pedido pedidoEncontrado = List.Find(x => x.Id == id);

            if (pedidoEncontrado is not null)
            {
                List.Remove(pedidoEncontrado);
                return Ok($"Pedido {id} borrado");

            }

            return NotFound("No se encontró el elemento a borrar");

        }

        private static int Asignar()
        {
            return ++idActual;
        }

    }
}

