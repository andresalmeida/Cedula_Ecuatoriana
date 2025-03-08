# Validación y Generación de Cédula Ecuatoriana

Este proyecto contiene una implementación en C# para validar y generar cédulas ecuatorianas, siguiendo el algoritmo oficial del Registro Civil de Ecuador.

---

## 📌 Características

- Validación de cédula ecuatoriana con los criterios establecidos.
- Generación de cédulas aleatorias válidas basadas en un código de provincia específico.
- Implementado como atributo de validación para integrarse fácilmente en proyectos ASP.NET.

---

## 📂 Estructura del Proyecto

```bash
📁 MiProyecto
│── 📁 Data
│── 📁 Models
│── 📁 Controllers
│── 📁 Validations
│     ├── CedulaEcuatorianaAttribute.cs  # Algoritmo de validación de cédula
│     ├── CedulaEcuatorianaGenerator.cs  # Algoritmo de generación de cédula
│── 📁 Views
│── README.md
```

---

## 🚀 Uso

### ✅ Validar una Cédula

El archivo `CedulaEcuatorianaAttribute.cs` permite validar si una cédula ecuatoriana es correcta:

```bash
using System.ComponentModel.DataAnnotations;

public class CedulaEcuatorianaAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
        {
            return ValidationResult.Success;
        }

        string cedula = value.ToString();
        if (cedula.Length != 10)
        {
            return new ValidationResult("La cédula debe tener 10 dígitos.");
        }

        int provincia = int.Parse(cedula.Substring(0, 2));
        if (provincia < 1 || provincia > 24)
        {
            return new ValidationResult("El código de provincia no es válido.");
        }

        int suma = 0;
        for (int i = 0; i < 9; i++)
        {
            int digito = int.Parse(cedula[i].ToString());
            if (i % 2 == 0)
            {
                digito *= 2;
                if (digito > 9) digito -= 9;
            }
            suma += digito;
        }

        int digitoVerificador = (10 - (suma % 10)) % 10;
        if (digitoVerificador != int.Parse(cedula[9].ToString()))
        {
            return new ValidationResult("La cédula no es válida.");
        }

        return ValidationResult.Success;
    }
}
```

---

### 🔢 Generar una Cédula Válida

El archivo `CedulaEcuatorianaGenerator.cs` permite generar una cédula aleatoria válida para una provincia específica:

```bash
using System;
using System.Text;

public static class CedulaGenerator
{
    private static readonly Random random = new Random();

    public static string GenerarCedulaValida(int codigoProvincia)
    {
        if ((codigoProvincia < 1 || codigoProvincia > 24) && codigoProvincia != 30)
        {
            throw new ArgumentException("El código de provincia no es válido.");
        }

        StringBuilder cedula = new StringBuilder(codigoProvincia.ToString("D2"));
        for (int i = 2; i < 9; i++)
        {
            cedula.Append(random.Next(0, 10));
        }

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
```

---

### 📌 Ejemplo de Uso

```bash
// Validación de cédula en un modelo
public class Usuario
{
    [CedulaEcuatoriana]
    public string Cedula { get; set; }
}

// Generación de una cédula válida
string cedulaGenerada = CedulaGenerator.GenerarCedulaValida(17);
Console.WriteLine("Cédula generada: " + cedulaGenerada);
```

---

## 📜 Licencia

Este proyecto es de código abierto y se distribuye bajo la Licencia MIT.
