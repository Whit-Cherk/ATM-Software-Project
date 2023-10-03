using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploATM
{
    // Pantalla.cs
    // Representa la pantalla del ATM.

    public class Pantalla
    {
        // muestra un mensaje sin un retorno de carro al final
        public void MostrarMensaje(string mensaje)
        {
            Console.Write(mensaje);
        } // fin del método MostrarMensaje

        // muestra un mensaje con un retorno de carro al final
        public void MostrarLineaMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        } // fin del método MostrarLineaMensaje

        // muestra un monto en dólares
        public void MostrarMontoEnDolares(decimal monto)
        {
            Console.Write("{0:C}", monto);
        } // fin del método MostrarMontoEnDolares
    } // fin de la clase Pantalla
}
