// PRIMERA VERSIÓN

//using System.ComponentModel.DataAnnotations;

//namespace Testing.Validations
//{
//    public class CedulaEcuatorianaAttribute : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            if (value == null || string.IsNullOrEmpty(value.ToString()))
//            {
//                return ValidationResult.Success;
//            }

//            string cedula = value.ToString();
//            if (cedula.Length != 10)
//            {
//                return new ValidationResult("La cédula debe tener 10 dígitos.");
//            }

//            int provincia = int.Parse(cedula.Substring(0, 2));
//            if (provincia < 1 || provincia > 24)
//            {
//                return new ValidationResult("El código de provincia no es válido.");
//            }

//            int suma = 0;
//            for (int i = 0; i < 9; i++)
//            {
//                int digito = int.Parse(cedula[i].ToString());
//                if (i % 2 == 0)
//                {
//                    digito *= 2;
//                    if (digito > 9) digito -= 9;
//                }
//                suma += digito;
//            }

//            int digitoVerificador = (10 - (suma % 10)) % 10;
//            if (digitoVerificador != int.Parse(cedula[9].ToString()))
//            {
//                return new ValidationResult("La cédula no es válida.");
//            }

//            return ValidationResult.Success;
//        }
//    }
//}

// SEGUNDA VERSIÓN

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Testing.Validations
{
    public class CedulaEcuatorianaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string cedula = value.ToString();

            // Validar que tenga 10 dígitos y que sean solo números
            if (cedula.Length != 10 || !cedula.All(char.IsDigit))
            {
                return new ValidationResult("La cédula debe contener exactamente 10 dígitos numéricos.");
            }

            // Obtener el código de provincia
            if (!int.TryParse(cedula.Substring(0, 2), out int provincia) ||
                (provincia < 1 || (provincia > 24 && provincia != 30)))
            {
                return new ValidationResult("El código de provincia no es válido.");
            }

            // Validación del dígito verificador
            int suma = 0;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };

            for (int i = 0; i < 9; i++)
            {
                int digito = int.Parse(cedula[i].ToString()) * coeficientes[i];
                if (digito > 9) digito -= 9;
                suma += digito;
            }

            int digitoVerificadorCalculado = (10 - (suma % 10)) % 10;
            int digitoVerificadorCedula = int.Parse(cedula[9].ToString());

            if (digitoVerificadorCalculado != digitoVerificadorCedula)
            {
                return new ValidationResult("La cédula no es válida.");
            }

            return ValidationResult.Success;
        }
    }
}
