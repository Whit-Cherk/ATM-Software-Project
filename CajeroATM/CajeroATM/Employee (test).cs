using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroATM
{
    internal class Employee__test_
    {
        //Atributos
        private string name;
        private string apellido;
        private int id;
        private double salarioPorHora;
        private double salarioBruto;
        private double horasTrabajadas;
        Random randomId = new Random();
        

        //Metodos getters y setters
        /*public string getName()
        {
            return name;
        }
        public void setName(string theName)
        {
            name = theName;
        }

        static void Main(string[] args)
        {
        
        }
        */

        //propiedades para controlas los accesos desde fuera de la clase
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public int Id
        {
            get { return id; }
        }
        public double SalarioPorHora
        {
            get { return salarioPorHora; }
            set
            {
                if (value >= 18)
                {
                    salarioPorHora = value;
                }
                else
                {
                    Console.WriteLine("Error en el salario ingresado");
                }
            }
        }


        //Constructores
        //Metodo que se llama autamaticamente cada vez que se cree un objeto
        public Employee__test_()
        {
            string elNombre;
            string elApellido;
            int elID;
            double elSalarioPorHora;

            Console.WriteLine("Introduzca el nombre del empleado");
            elNombre = Console.ReadLine();
            Console.WriteLine("Introduzca el apellido del empleado");
            elApellido = Console.ReadLine();
            Console.WriteLine("Introduzca el salario por hora");
            elSalarioPorHora = double.Parse(Console.ReadLine());
            elID = randomId.Next(10000, 99999);

            //Inicializar los atributos
            this.name = elNombre;
            this.apellido = elApellido;
            this.id = elID;
            this.SalarioPorHora = elSalarioPorHora;
        }

        //Metodos personalizados
        public  void RecibirHorasTrabajadas()
        {
            double horasTrabajadas;
            Console.WriteLine($"Introduzca las horas trabajadas para el empleado {this.name}");
            horasTrabajadas = double.Parse(Console.ReadLine());
            this.horasTrabajadas = horasTrabajadas;

        }
        public void CalcularSalarioBruto()
        {
            this.salarioBruto = this.horasTrabajadas * this.salarioPorHora;
        }
        public void MostrarDatos()
        {
            Console.WriteLine($"Empleado {this.name} {this.apellido}\n " +
                              $"Id: {this.id}\n" +
                              $"Salario por hora: {this.salarioPorHora}\n" +
                              $"Horas trabajadas: {this.horasTrabajadas}\n" +
                              $"Salario bruto: {this.salarioBruto}");
        }
    }
}
