//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;
//namespace Testing.Models
//{
//    public class ClientePostgreSQL
//    {
//        public int Codigo { get; set; }
//        [Required]
//        [StringLength(10)]
//        public string Cedula { get; set; }
//        [Required]
//        [StringLength(10)]
//        public string Apellidos { get; set; }
//        [Required]
//        [StringLength(100)]
//        public string Nombres { get; set; }
//        [Required]
//        [StringLength(100)]
//        public DateTime FechaNacimiento { get; set; }
//        public string Mail { get; set; }
//        public string Telefono { get; set; }
//        public string Direccion { get; set; }
//        public Boolean Estado { get; set; }
//    }
//}

// CÓDIGO QUE SI FUNCIONA EN 4K NO MOVIBLE

//using System;
//using System.ComponentModel.DataAnnotations;

//namespace Testing.Models
//{
//    public class ClientePostgreSQL
//    {
//        [Key]
//        public int Codigo { get; set; }

//        [Required(ErrorMessage = "La cédula es obligatoria")]
//        [StringLength(10, ErrorMessage = "La cédula debe tener 10 caracteres")]
//        public string Cedula { get; set; }

//        [Required(ErrorMessage = "Los apellidos son obligatorios")]
//        [StringLength(50, ErrorMessage = "Los apellidos no pueden exceder los 50 caracteres")]
//        public string Apellidos { get; set; }

//        [StringLength(50, ErrorMessage = "Los nombres no pueden exceder los 50 caracteres")]
//        public string Nombres { get; set; }

//        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
//        [DataType(DataType.Date)]
//        public DateTime FechaNacimiento { get; set; }

//        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
//        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
//        [StringLength(50, ErrorMessage = "El correo electrónico no puede exceder los 50 caracteres")]
//        public string Mail { get; set; }

//        [Required(ErrorMessage = "El teléfono es obligatorio")]
//        [StringLength(10, ErrorMessage = "El teléfono debe tener 10 caracteres")]
//        public string Telefono { get; set; }

//        [StringLength(50, ErrorMessage = "La dirección no puede exceder los 50 caracteres")]
//        public string Direccion { get; set; }

//        public bool Estado { get; set; }
//    }
//}

// CODIGO QUE CREAMOS PARA LA CLASE DIO MIO POR FAVOR QUE FUNCIONE

using System;
using System.ComponentModel.DataAnnotations;
using Testing.Validations;

namespace Testing.Models
{
    public class ClientePostgreSQL
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria")]
        [StringLength(10, ErrorMessage = "La cédula debe tener 10 caracteres")]
        [CedulaEcuatoriana] // Añadiremos este atributo personalizado
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una provincia")]
        public Provincia ProvinciaSeleccionada { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(50, ErrorMessage = "Los apellidos no pueden exceder los 50 caracteres")]
        public string Apellidos { get; set; }

        [StringLength(50, ErrorMessage = "Los nombres no pueden exceder los 50 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        [StringLength(50, ErrorMessage = "El correo electrónico no puede exceder los 50 caracteres")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(10, ErrorMessage = "El teléfono debe tener 10 caracteres")]
        public string Telefono { get; set; }

        [StringLength(50, ErrorMessage = "La dirección no puede exceder los 50 caracteres")]
        public string Direccion { get; set; }

        public bool Estado { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El saldo no puede ser negativo")]
        public decimal Saldo { get; set; }
    }
}