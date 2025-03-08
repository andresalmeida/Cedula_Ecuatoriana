// PRIMERA VERSIÓN

//namespace Testing.Validations
//{
//    public static class CedulaGenerator
//    {
//        public static string GenerarCedulaValida(int codigoProvincia)
//        {
//            Random random = new Random();
//            string cedula = codigoProvincia.ToString("D2");

//            for (int i = 2; i < 9; i++)
//            {
//                cedula += random.Next(0, 10).ToString();
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
//            cedula += digitoVerificador.ToString();

//            return cedula;
//        }
//    }
//}

// SEGUNDA VERSIÓN

using System;
using System.Text;

namespace Testing.Validations
{
    public static class CedulaGenerator
    {
        private static readonly Random random = new Random(); // Instancia única de Random

        public static string GenerarCedulaValida(int codigoProvincia)
        {
            // Validar que el código de provincia sea válido
            if ((codigoProvincia < 1 || codigoProvincia > 24) && codigoProvincia != 30)
            {
                throw new ArgumentException("El código de provincia no es válido.");
            }

            StringBuilder cedula = new StringBuilder(codigoProvincia.ToString("D2"));

            // Generar los siguientes 7 dígitos aleatorios
            for (int i = 2; i < 9; i++)
            {
                cedula.Append(random.Next(0, 10));
            }

            // Cálculo del dígito verificador
            int suma = 0;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };

            for (int i = 0; i < 9; i++)
            {
                int digito = int.Parse(cedula[i].ToString()) * coeficientes[i];
                if (digito > 9) digito -= 9;
                suma += digito;
            }

            int digitoVerificador = (10 - (suma % 10)) % 10;
            cedula.Append(digitoVerificador);

            return cedula.ToString();
        }
    }
}
