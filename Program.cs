using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examen_I_Progra_II.Program;

namespace Examen_I_Progra_II
{
    internal class Program

    {
        private static void Main(string[] args);

        public class Menu
        {
            private List<Empleado> empleados = new List<Empleado>();

            // Método para mostrar el menú
            public void MostrarMenu()
            {
                int opcion;
                do
                {
                    Console.WriteLine("\nSistema de Gestión de Empleados");
                    Console.WriteLine("1. Agregar Empleado");
                    Console.WriteLine("2. Consultar Empleados");
                    Console.WriteLine("3. Modificar Empleado");
                    Console.WriteLine("4. Borrar Empleado");
                    Console.WriteLine("5. Inicializar Arreglos");
                    Console.WriteLine("6. Generar Reportes");
                    Console.WriteLine("7. Salir");
                    Console.Write("Seleccione una opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            AgregarEmpleado();
                            break;
                        case 2:
                            ConsultarEmpleados();
                            break;
                        case 3:
                            ModificarEmpleado();
                            break;
                        case 4:
                            BorrarEmpleado();
                            break;
                        case 5:
                            InicializarArreglos();
                            break;
                        case 6:
                            MostrarSubmenuReportes();
                            break;
                        case 7:
                            Console.WriteLine("Saliendo del sistema...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                } while (opcion != 7);
            }

            // Método para agregar un empleado
            private void AgregarEmpleado()
            {
                Console.Write("Ingrese la cédula del empleado: ");
                string cedula = Console.ReadLine();
                Console.Write("Ingrese el nombre del empleado: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese la dirección del empleado: ");
                string direccion = Console.ReadLine();
                Console.Write("Ingrese el teléfono del empleado: ");
                string telefono = Console.ReadLine();
                Console.Write("Ingrese el salario del empleado: ");
                decimal salario = Convert.ToDecimal(Console.ReadLine());

                Empleado nuevoEmpleado = new Empleado(cedula, nombre, direccion, telefono, salario);
                empleados.Add(nuevoEmpleado);
                Console.WriteLine("Empleado agregado exitosamente.");
            }

            // Método para consultar empleados
            private void ConsultarEmpleados()
            {
                Console.WriteLine("\nLista de Empleados:");
                foreach (Empleado empleado in empleados)
                {
                    Console.WriteLine(empleado);
                }
            }

            // Método para modificar un empleado
            private void ModificarEmpleado()
            {
                Console.Write("Ingrese la cédula del empleado a modificar: ");
                string cedula = Console.ReadLine();
                Empleado empleadoAModificar = empleados.Find(e => e.Cedula == cedula);

                if (empleadoAModificar != null)
                {
                    Console.Write("Ingrese el nuevo nombre del empleado (deje en blanco para no modificar): ");
                    string nuevoNombre = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoNombre))
                    {
                        empleadoAModificar.Nombre = nuevoNombre;
                    }

                    Console.Write("Ingrese la nueva dirección del empleado (deje en blanco para no modificar): ");
                    string nuevaDireccion = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevaDireccion))
                    {
                        empleadoAModificar.Direccion = nuevaDireccion;
                    }

                    Console.Write("Ingrese el nuevo teléfono del empleado (deje en blanco para no modificar): ");
                    string nuevoTelefono = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoTelefono))
                    {
                        empleadoAModificar.Telefono = nuevoTelefono;
                    }

                    Console.Write("Ingrese el nuevo salario del empleado (deje en blanco para no modificar): ");
                    string nuevoSalarioStr = Console.ReadLine();
                    if (decimal.TryParse(nuevoSalarioStr, out decimal nuevoSalario))
                    {
                        empleadoAModificar.Salario = nuevoSalario;
                    }

                    Console.WriteLine("Empleado modificado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Empleado no encontrado.");
                }
            }

            // Método para borrar un empleado
            private void BorrarEmpleado()
            {
                Console.Write("Ingrese la cédula del empleado a borrar: ");
                string cedula = Console.ReadLine();
                Empleado empleadoABorrar = empleados.Find(e => e.Cedula == cedula);

                if (empleadoABorrar != null)
                {
                    empleados.Remove(empleadoABorrar);
                    Console.WriteLine("Empleado borrado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Empleado no encontrado.");
                }
            }

            // Método para inicializar arreglos
            private void InicializarArreglos()
            {
                empleados = new List<Empleado>();
                Console.WriteLine("Arreglos inicializados.");
            }

            // Método para mostrar el submenú de reportes
            private void MostrarSubmenuReportes()
            {
                int opcion;
                do
                {
                    Console.WriteLine("\nSubmenú de Reportes");
                    Console.WriteLine("1. Listar empleados ordenados por nombre");
                    Console.WriteLine("2. Calcular y mostrar el promedio de los salarios");
                    Console.WriteLine("3. Volver al menú principal");
                    Console.Write("Seleccione una opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            ListarEmpleadosOrdenadosPorNombre();
                            break;
                        case 2:
                            CalcularPromedioSalarios();
                            break;
                        case 3:
                            Console.WriteLine("Volviendo al menú principal...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                } while (opcion != 3);
            }

            // Método para listar empleados ordenados por nombre
            private void ListarEmpleadosOrdenadosPorNombre()
            {
                var empleadosOrdenados = empleados.OrderBy(e => e.Nombre).ToList();
                Console.WriteLine("\nEmpleados ordenados por nombre:");
                foreach (Empleado empleado in empleadosOrdenados)
                {
                    Console.WriteLine(empleado);
                }
            }

            // Método para calcular y mostrar el promedio de los salarios
            private void CalcularPromedioSalarios()
            {
                if (empleados.Count > 0)
                {
                    decimal promedioSalarios = empleados.Average(e => e.Salario);
                    Console.WriteLine($"\nEl promedio de los salarios es: {promedioSalarios:C}");
                }
                else
                {
                    Console.WriteLine("No hay empleados registrados para calcular el promedio de salarios.");
                }
            }
        }

        class Programa
        {
            static void Main(string[] args)
            {
                Menu menu = new Menu();
                menu.MostrarMenu();
            }
        }

        internal class Empleado
        {
            private string cedula;
            private string nombre;
            private string direccion;
            private string telefono;
            private decimal salario;

            public Empleado(string cedula, string nombre, string direccion, string telefono, decimal salario)
            {
                this.cedula=cedula;
                this.nombre=nombre;
                this.direccion=direccion;
                this.telefono=telefono;
                this.salario=salario;
            }

            public decimal Salario { get; internal set; }
            public object Nombre { get; internal set; }
            public string Cedula { get; internal set; }
            public string Telefono { get; internal set; }
            public string Direccion { get; internal set; }
        }
    }
}
