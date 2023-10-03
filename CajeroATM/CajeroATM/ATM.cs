using EjemploATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroATM
{
    public class CajeroATM
    {
        //Atributos
        private bool usuarioAutenticado = false;
        private int numCuentaActual; // user's account number
        private Pantalla pantalla; // reference to ATM's screen
        private Teclado teclado; // reference to ATM's keypad
        private DispensadorEfectivo dispensadorEfectivo; // ref to ATM's cash dispenser
        private RanuraDeposito ranuraDeposito; // reference to ATM's deposit slot
        private BaseDatosBanco baseDatosBanco; // ref to account info database

        //Metodo MAIN
        public static void Main(string[] args)
        {
            CajeroATM cajeroATM = new CajeroATM();

            cajeroATM.Ejecutar();
        }
        
        //Menu de opciones
        private enum MenuOpciones
        {
            SOLICITUD_SALDO = 1,
            RETIRO = 2,
            DEPOSITO = 3,
            TERMINAR_SESION = 4
        }

        //constructor
        public CajeroATM()
        {
            usuarioAutenticado = false; // user is not authenticated to start
            numCuentaActual = 0; // no current account number to start
            pantalla = new Pantalla(); // create screen
            teclado = new Teclado(); // create keypad
            dispensadorEfectivo = new DispensadorEfectivo(); // create cash dispenser
            ranuraDeposito = new RanuraDeposito(); // create deposit slot
            baseDatosBanco = new BaseDatosBanco(); // create account info database
        }

        //Metodo Ejecutar
        public void Ejecutar()
        {
            //inicio de sesion
            while (true) //loop infinito
            {
                while (!usuarioAutenticado) //Loop mientras no se este autenticado
                {
                    pantalla.MostrarLineaMensaje("\nBienvenido");
                    AutenticarUsuario();
                }
                RealizarTransaccion();
                usuarioAutenticado = false;
                numCuentaActual = 0;
                pantalla.MostrarLineaMensaje("\nPase buen día!");
            }
        }

        //Metodo AutenticarUsuario
        private void AutenticarUsuario()
        {
            //Solicitar el numero de cuenta
            pantalla.MostrarLineaMensaje("Ingrese su numero de cuenta: ");
            int numeroCuenta = teclado.ObtenerEntrada();

            //Solicitar contraseña de la cuenta
            pantalla.MostrarLineaMensaje("Ingrese el NIP de su cuenta: ");
            int NIP = teclado.ObtenerEntrada();

            //Verificar credenciales
            usuarioAutenticado = baseDatosBanco.AutenticarUsuario(numeroCuenta, NIP);

            //Condicional  si las credenciales son correctas
            if (usuarioAutenticado) numCuentaActual = numeroCuenta;
            else pantalla.MostrarLineaMensaje("Numero de cuenta o NIP incorrecto. Intente de nuevo");
        }

        //Imprimir el menu y ejecutar una transaccion
        private void RealizarTransaccion()
        {
            Transaccion transaccionActual;
            bool sesionTerminada = false; // El usuario no ha seleccionado salir

            //mientras el usuario no ha salido
            while (!sesionTerminada)
            {
                //Mostrar menu principal
                int opcionSeleccionada = MostrarMenu();

                //Condicional para realizar la accion dependiendo de la opcion escogida
                switch ((MenuOpciones) opcionSeleccionada)
                {
                    case MenuOpciones.SOLICITUD_SALDO:
                    case MenuOpciones.RETIRO:
                    case MenuOpciones.DEPOSITO:
                        transaccionActual = crearTransaccion(opcionSeleccionada);
                        transaccionActual.Ejecutar(); //Ejecutar transaccion
                        break;
                    case MenuOpciones.TERMINAR_SESION:
                        sesionTerminada = true;
                        break;
                    default: //Opcion escogida no existe
                        pantalla.MostrarLineaMensaje("\nSu opcion no es valida. Intente de nuevo.");
                        break;
                }
            }
        }

        //Menu principal
        private int MostrarMenu()
        {
            pantalla.MostrarLineaMensaje("\nMenu Principal:");
            pantalla.MostrarLineaMensaje("1 - Ver saldo");
            pantalla.MostrarLineaMensaje("2 - Retirar efectivo");
            pantalla.MostrarLineaMensaje("3 - Depositar efectivo");
            pantalla.MostrarLineaMensaje("4 - Terminar sesión");
            pantalla.MostrarMensaje("Escoja una opcion: ");
            return teclado.ObtenerEntrada();

        }

        //Referencia al objeto correspondiente dentro de la clase abstracta Transacciones
        private Transaccion crearTransaccion(int tipoTransaccion)
        {
            Transaccion temp = null; // Referencia nula. Se modificara mas adelante

            //Condicional que determine el tipo de transaccion
            switch (tipoTransaccion)
            {
                case 1:
                    temp = new SolicitudSaldo(numCuentaActual, pantalla, baseDatosBanco);
                    break;
                case 2:
                    temp = new Retiro(numCuentaActual, pantalla, baseDatosBanco, teclado, dispensadorEfectivo);
                    break;
                case 3:
                    temp = new Deposito(numCuentaActual, pantalla, baseDatosBanco, teclado, ranuraDeposito);
                    break;
            }
            return temp;
        }

        
    }

    
}