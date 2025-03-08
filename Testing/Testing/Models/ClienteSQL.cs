using System.ComponentModel.DataAnnotations;

namespace Testing.Models
{
    public class ClienteSQL
    {
        public int Codigo { get; set; }

        [Required]
        [StringLength(10)]

        public string Cedula { get; set; }

        [Required]
        [StringLength(10)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(50)]

        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public DateTime FechaNacimiento { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public Boolean Estado { get; set; }
    }
}
