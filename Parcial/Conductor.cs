namespace Parcial
{
    public class Conductor
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Licencia { get; set; }
        public required string FechaNacimiento { get; set; }
        public string idvehiculo { get; set; }
    }
}
