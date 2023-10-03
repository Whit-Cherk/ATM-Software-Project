using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploATM
{
    // DispensadorEfectivo.cs
    // Representa el dispensador de efectivo del ATM.
    public class DispensadorEfectivo
    {
        // el número inicial predeterminado de billetes en el dispensador de efectivo
        private const int CUENTA_INICIAL = 500;
        private int cuentaBilletes; // número restante de billetes de $20

        // constructor sin parámetros que inicializa cuentaBilletes con CUENTA_INICIAL
        public DispensadorEfectivo()
        {
            cuentaBilletes = CUENTA_INICIAL; // establece cuentaBilletes a CUENTA_INICIAL
        } // fin del constructor

        // simula dispensar el monto especificado de efectivo
        public void DispensarEfectivo(decimal monto)
        {
            // número requerido de billetes de $20
            int billetesRequeridos = ((int)monto) / 20;
            cuentaBilletes -= billetesRequeridos;
        } // fin del método DispensarEfectivo

        // indica si el dispensador de efectivo puede dispensar el monto deseado
        public bool HaySuficienteEfectivoDisponible(decimal monto)
        {
            // número requerido de billetes de $20
            int billetesRequeridos = ((int)monto) / 20;

            // devuelve si hay suficientes billetes disponibles
            return (cuentaBilletes >= billetesRequeridos);
        } // fin del método HaySuficienteEfectivoDisponible
    } // fin de la clase DispensadorEfectivo
}
