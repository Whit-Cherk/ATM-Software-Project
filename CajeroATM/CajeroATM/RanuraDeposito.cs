using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploATM
{
    // RanuraDeposito.cs
    // Representa la ranura de depósito del ATM.
    public class RanuraDeposito
    {
        // indica si se recibió el sobre (siempre devuelve verdadero, ya que
        // ésta es sólo una simulación de software de una ranura de depósito real)
        public bool SeRecibioSobreDeposito()
        {
            return true; // El sobre fue recibido
        } // fin del método SeRecibioSobreDeposito
    } // fin de la clase RanuraDeposito
}
