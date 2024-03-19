namespace Parcial
{
    public class Pedido
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int [] ListaProductos { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
        public string EstadoPedido { get; set; }

        public int idvehiculo { get; set; }

        public int idconductor { get; set; }




    }
}
