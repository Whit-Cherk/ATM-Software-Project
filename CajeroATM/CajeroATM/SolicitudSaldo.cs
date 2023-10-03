using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploATM
{
    // SolicitudSaldo.cs
    // Representa una transacción de solicitud de saldo en el ATM
    public class SolicitudSaldo : Transaccion
    {
        // el constructor de tres parámetros inicializa las variables de la clase base
        public SolicitudSaldo(int numeroCuentaUsuario,
        Pantalla pantallaATM, BaseDatosBanco baseDatosBancoATM)
        : base(numeroCuentaUsuario, pantallaATM, baseDatosBancoATM) { }

        // realiza una transacción; redefine el método abstracto de Transaccion
        public override void Ejecutar()
        {
            // obtiene el saldo disponible para la Cuenta del usuario actual
            decimal saldoDisponible =
            BaseDatos.ObtenerSaldoDisponible(NumeroCuenta);

            // obtiene el saldo total para la Cuenta del usuario actual
            decimal saldoTotal = BaseDatos.ObtenerSaldoTotal(NumeroCuenta);

            // muestra la información del saldo en la pantalla
            PantallaUsuario.MostrarLineaMensaje("\nInformación del saldo:");
            PantallaUsuario.MostrarMensaje(" - Saldo disponible: ");
            PantallaUsuario.MostrarMontoEnDolares(saldoDisponible);
            PantallaUsuario.MostrarMensaje("\n - Saldo total: ");
            PantallaUsuario.MostrarMontoEnDolares(saldoTotal);
            PantallaUsuario.MostrarLineaMensaje("");
        } // fin del método Ejecutar
    } // fin de la clase SolicitudSaldo
}
