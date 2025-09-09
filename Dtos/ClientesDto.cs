using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaKaprielian.Dtos
{
    public class ClientesDto
    {

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(15, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombres { get; set; } = "";

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(10, ErrorMessage = "El apellido no puede superar los 100 caracteres")]
        public string Apellidos { get; set; } = "";

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El CUIT es obligatorio")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El CUIT debe tener 11 caracteres")]
        public string Cuit { get; set; } = "";

        [Required(ErrorMessage = "El domicilio es obligatorio")]
        [StringLength(45, ErrorMessage = "El domicilio no puede superar los 200 caracteres")]
        public string Domicilio { get; set; } = "";

        [Required(ErrorMessage = "El teléfono celular es obligatorio")]
        [Phone(ErrorMessage = "El teléfono celular no tiene un formato válido")]
        public string TelefonoCelular { get; set; } = "";

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        public string Email { get; set; } = "";
    }
}
