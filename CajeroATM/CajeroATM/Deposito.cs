using CajeroATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploATM
{
    // Deposito.cs
    // Representa una transacción de depósito en el ATM.
    public class Deposito : Transaccion
    {
        private decimal monto; // monto a depositar
        private Teclado teclado; // referencia al Teclado
        private RanuraDeposito ranuraDeposito; // referencia a la ranura de depósito

        // constante que representa la opción de cancelar
        private const int CANCELO = 0;

        // constructor de cinco parámetros que inicializa las variables de instancia de la clase
        public Deposito(int numeroCuentaUsuario, Pantalla pantallaATM,
        BaseDatosBanco baseDatosBancoATM, Teclado tecladoATM,
        RanuraDeposito ranuraDepositoATM)
        : base(numeroCuentaUsuario, pantallaATM, baseDatosBancoATM)
        {
            // inicializa las referencias al teclado y a la ranura de depósito
            teclado = tecladoATM;
            ranuraDeposito = ranuraDepositoATM;
        } // fin del constructor de cinco parámetros

        // realiza una transacción; redefine el método abstracto de Transaccion
        public override void Ejecutar()
        {
            monto = PedirMontoADepositar(); // obtiene el monto a depositar del usuario

            // comprueba si el usuario introdujo un monto a depositar, o si canceló
            if (monto != CANCELO)
            {
                // solicita un sobre de depósito que contenga el monto especificado
                PantallaUsuario.MostrarMensaje(
                "\nIntroduzca un sobre de depósito que contenga ");
                PantallaUsuario.MostrarMontoEnDolares(monto);
                PantallaUsuario.MostrarLineaMensaje(" en la ranura para depósitos.");

                // obtiene el sobre de depósito
                bool sobreRecibido = ranuraDeposito.SeRecibioSobreDeposito();

                // comprueba si se recibió el sobre de depósito
                if (sobreRecibido)
                {
                    PantallaUsuario.MostrarLineaMensaje(
                    "\nSe recibió su sobre.\n" +
                    "El dinero que acaba de depositar no estará disponible " +
                    "sino hasta que \nverifiquemos el monto del efectivo " +
                    "dentro del sobre, y que se haya verificado cualquier cheque incluido.");

                    // abona a la cuenta para reflejar el depósito
                    BaseDatos.Abonar(NumeroCuenta, monto);
                } // fin de if interno
                else
                    PantallaUsuario.MostrarLineaMensaje(
                    "\nNo insertó un sobre, por lo que el ATM ha " +
                    "cancelado su transacción.");
            } // fin de if externo
            else
                PantallaUsuario.MostrarLineaMensaje("\nCancelando la transacción...");
        } // fin del método Ejecutar

        // pide al usuario que introduzca un monto de depósito para abonarlo a la cuenta
        private decimal PedirMontoADepositar()
        {
            // muestra el indicador y recibe la entrada
            PantallaUsuario.MostrarMensaje(
            "\nIntroduzca un monto a depositar en CENTAVOS (o 0 para cancelar): ");
            int entrada = teclado.ObtenerEntrada();

            // comprueba si el usuario canceló o introdujo un un monto válido
            if (entrada == CANCELO)
                return CANCELO;
            else
                return entrada / 100.00M;
        } // fin del método PedirMontoADepositar
    } // fin de la clase Deposito

}
