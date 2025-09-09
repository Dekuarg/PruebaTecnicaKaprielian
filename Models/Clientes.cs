namespace PruebaTecnicaKaprielian.Models
{
    public class Clientes
    {
        public virtual int Id { get; set; }

        public virtual string Nombres { get; set; } = "";

        public virtual string Apellidos { get; set; } = "";

        public virtual DateTime FechaNacimiento { get; set; } 

        public virtual string Cuit { get; set; } = "";

        public virtual string Domicilio { get; set; } = "";

        public virtual string TelefonoCelular { get; set; } = "";

        public virtual string Email { get; set; } = "";
    }
}
