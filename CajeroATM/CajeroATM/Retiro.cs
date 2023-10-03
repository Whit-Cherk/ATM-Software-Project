using CajeroATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploATM
{
    // Retiro.cs
    // La clase Retiro representa una transacción de retiro del ATM.
    public class Retiro : Transaccion
    {
        private decimal monto; // monto a retirar
        private Teclado teclado; // referencia a Teclado
        private DispensadorEfectivo dispensadorEfectivo; // referencia al dispensador de efectivo

        // constante que corresponde a la opción de menú para cancelar
        private const int CANCELO = 6;

        // constructor de cinco parámetros
        public Retiro(int numeroCuentaUsuario, Pantalla pantallaATM,
        BaseDatosBanco baseDatosBancoATM, Teclado tecladoATM,
        DispensadorEfectivo dispensadorEfectivoATM)
        : base(numeroCuentaUsuario, pantallaATM, baseDatosBancoATM)
        {
            // inicializa las referencias a teclado y al dispensador de efectivo
            teclado = tecladoATM;
            dispensadorEfectivo = dispensadorEfectivoATM;
        } // fin del constructor

        // realiza una transacción, redefine el método abstracto de Transaccion
        public override void Ejecutar()
        {
            bool efectivoDispensado = false; // el efectivo no se ha dispensado aún

            // la transacción no se ha cancelado aún
            bool transaccionCancelada = false;

            // itera hasta que se dispense efectivo o el usuario cancele
            do
            {
                // obtiene el monto de retiro elegido por el usuario
                int seleccion = MostrarMenuDeMontos();

                // comprueba si el usuario eligió un monto de retiro o canceló
                if (seleccion != CANCELO)
                {
                    // establece monto al monto seleccionado en dólares
                    monto = seleccion;

                    // obtiene el saldo disponible de la cuenta involucrada
                    decimal saldoDisponible =
                    BaseDatos.ObtenerSaldoDisponible(NumeroCuenta);
                    // comprueba si el usuario tiene suficiente dinero en la cuenta
                    if (monto <= saldoDisponible)
                    {
                        // comprueba si el dispensador de efectivo tiene suficiente dinero
                        if (dispensadorEfectivo.HaySuficienteEfectivoDisponible(monto))
                        {
                            // carga a la cuenta para reflejar el retiro
                            BaseDatos.Cargar(NumeroCuenta, monto);

                            dispensadorEfectivo.DispensarEfectivo(monto); // dispensa efectivo
                            efectivoDispensado = true; // se dispensó el efectivo

                            // instruye al usuario para que tome el efectivo
                            PantallaUsuario.MostrarLineaMensaje(
                            "\nPor favor tome su efectivo del dispensador.");
                        } // fin del if más interno
                        else // el dispensador no tiene suficiente efectivo
                            PantallaUsuario.MostrarLineaMensaje(
                            "\nNo hay suficiente efectivo disponible en el ATM." +
                            "\n\nPor favor elija un monto más pequeño.");
                    } // fin del if intermedio
                    else // no hay suficiente dinero disponible en la cuenta del usuario
                        PantallaUsuario.MostrarLineaMensaje(
                        "\nNo hay suficiente efectivo disponible en su cuenta." +
                        "\n\nPor favor elija un monto más pequeño.");
                } // fin del if más externo
                else
                {
                    PantallaUsuario.MostrarLineaMensaje("\nCancelando la transacción...");
                    transaccionCancelada = true; // el usuario canceló la transacción
                } // fin del else
            } while ((!efectivoDispensado) && (!transaccionCancelada));
        } // fin del método Ejecutar

        // muestra un menú de montos para retirar y la opción para cancelar;
        // devuelve el monto elegido o 6 si el usuario elije cancelar
        private int MostrarMenuDeMontos()
        {
            int eleccionUsuario = 0; // variable para almacenar el valor devuelto

            // arreglo de montos que corresponden a los números del menú
            int[] montos = { 0, 20, 40, 60, 100, 200 };

            // itera mientras no se haya realizado una selección válida
            while (eleccionUsuario == 0)
            {
                // muestra el menú
                PantallaUsuario.MostrarLineaMensaje("\nOpciones de retiro:");
                PantallaUsuario.MostrarLineaMensaje("1 - $20");
                PantallaUsuario.MostrarLineaMensaje("2 - $40");
                PantallaUsuario.MostrarLineaMensaje("3 - $60");
                PantallaUsuario.MostrarLineaMensaje("4 - $100");
                PantallaUsuario.MostrarLineaMensaje("5 - $200");
                PantallaUsuario.MostrarLineaMensaje("6 - Cancelar transacción");
                PantallaUsuario.MostrarMensaje(
                "\nElija una opción de retiro (1-6): ");

                // obtiene la entrada del usuario a través del teclado
                int entrada = teclado.ObtenerEntrada();

                // determina cómo proceder con base en el valor de entrada
                switch (entrada)
                {
                    // si el usuario eligió un monto de retiro (es decir, la opción
                    // 1, 2, 3, 4 o 5), devuelve el monto correspondiente
                    // del arreglo montos
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        eleccionUsuario = montos[entrada]; // guarda la elección del usuario
                        break;
                    case CANCELO: // el usuario eligió cancelar
                        eleccionUsuario = CANCELO; // guarda la elección del usuario
                        break;
                    default:
                        PantallaUsuario.MostrarLineaMensaje(
                        "\nSelección inválida. Intente de nuevo.");
                        break;
                } // fin de switch
            } // fin de while

            return eleccionUsuario;
        } // fin del método MostrarMenuDeMontos
    } // fin de la clase Retiro
}
