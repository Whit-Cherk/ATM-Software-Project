using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploATM
{
    // Teclado.cs
    // Representa el teclado del ATM.

    public class Teclado
    {
        // devuelve un valor entero introducido por el usuario
        public int ObtenerEntrada()
        {
            return Convert.ToInt32(Console.ReadLine());
        } // fin del método Obtener
    }
}
