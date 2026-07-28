using System;
using System.Collections.Generic;
using System.Linq;

namespace FundamentosNET
{
    // 1. MODELO DE DATOS: Estructura de una Oferta de Empleo
    public class OfertaLaboral
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Tecnologia { get; set; } = string.Empty;
        public double SalarioUSD { get; set; }
        public bool EsRemoto { get; set; }

        public void MostrarDetalle()
        {
            string modalidad = EsRemoto ? "Remoto 🌐" : "Presencial 🏢";
            Console.WriteLine($"[{Id}] {Titulo} | Tech: {Tecnologia} | Mod: {modalidad} | USD ${SalarioUSD}");
        }
    }
               
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sistema de Gestión de Empleos IT - .NET 8";

            // 2. CREACIÓN DE DATOS (Lista de Objetos)
            List<OfertaLaboral> empleos = new List<OfertaLaboral>
            {
                new OfertaLaboral { Id = 1, Titulo = "Backend Developer", Tecnologia = "C# / .NET", SalarioUSD = 2800, EsRemoto = true },
                new OfertaLaboral { Id = 2, Titulo = "Full Stack Engineer", Tecnologia = "React + Python", SalarioUSD = 3200, EsRemoto = true },
                new OfertaLaboral { Id = 3, Titulo = "Analista de Sistemas", Tecnologia = "SQL + Power BI", SalarioUSD = 2200, EsRemoto = false },
                new OfertaLaboral { Id = 4, Titulo = "Junior C# Developer", Tecnologia = "C# / ASP.NET", SalarioUSD = 1800, EsRemoto = false }
            };

            bool ejecutando = true;

            // 3. BUCLE PRINCIPAL DEL SISTEMA
            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine("   SISTEMA DE BÚSQUEDA Y FILTRADO DE EMPLEOS    ");
                Console.WriteLine("================================================");
                Console.WriteLine("1. Ver todas las ofertas");
                Console.WriteLine("2. Filtrar ofertas en C# / .NET");
                Console.WriteLine("3. Filtrar trabajos 100% Remotos");
                Console.WriteLine("4. Agregar nueva oferta");
                Console.WriteLine("5. Salir");
                Console.Write("\nSelecciona una opción (1-5): ");

                string opcion = Console.ReadLine();

                Console.WriteLine("\n------------------------------------------------");

                // 4. MANEJO DE OPCIONES CON SWITCH
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("--- TODAS LAS OFERTAS REGISTRADAS ---");
                        empleos.ForEach(e => e.MostrarDetalle());
                        break;

                    case "2":
                        Console.WriteLine("--- OFERTAS PARA C# / .NET (Consulta LINQ) ---");
                        // LINQ: Filtrado declarativo (similar a SQL)
                        var ofertasNet = empleos.Where(e => e.Tecnologia.Contains("C#")).ToList();
                        ofertasNet.ForEach(e => e.MostrarDetalle());
                        break;

                    case "3":
                        Console.WriteLine("--- OFERTAS REMOTAS ---");
                        var remotas = empleos.Where(e => e.EsRemoto).ToList();
                        remotas.ForEach(e => e.MostrarDetalle());
                        break;

                    case "4":
                        AgregarOferta(empleos);
                        break;

                    case "5":
                        ejecutando = false;
                        Console.WriteLine("Cerrando la aplicación... ¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("❌ Opción inválida. Intenta nuevamente.");
                        break;
                }

                if (ejecutando)
                {
                    Console.WriteLine("\nPresiona ENTER para volver al menú...");
                    Console.ReadLine();
                }
            }
        }

        // 5. MÉTODOS AUXILIARES Y CONTROL DE ERRORES (Try-Catch)
        static void AgregarOferta(List<OfertaLaboral> lista)
        {
            Console.WriteLine("--- REGISTRAR NUEVA OFERTA ---");
            try
            {
                Console.Write("Título del puesto: ");
                string titulo = Console.ReadLine();

                Console.Write("Tecnología principal: ");
                string tech = Console.ReadLine();

                Console.Write("Salario estimado (USD): ");
                double salario = double.Parse(Console.ReadLine());

                Console.Write("¿Es remoto? (s/n): ");
                bool esRemoto = Console.ReadLine().ToLower() == "s";

                int nuevoId = lista.Count + 1;

                // Crear y agregar el objeto a la lista
                lista.Add(new OfertaLaboral
                {
                    Id = nuevoId,
                    Titulo = titulo,
                    Tecnologia = tech,
                    SalarioUSD = salario,
                    EsRemoto = esRemoto
                });

                Console.WriteLine("\n✅ ¡Oferta agregada exitosamente!");
            }
            catch (FormatException)
            {
                Console.WriteLine("\n❌ Error: Debes ingresar un número válido en el salario.");
            }
        }
    }
}