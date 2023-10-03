using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploATM
{
    // Transaccion.cs
    // La clase base abstracta Transaccion representa una transacción en el ATM.
    public abstract class Transaccion
    {
        private int numeroCuenta; // cuenta involucrada en la transacción
        private Pantalla pantallaUsuario; // referencia a la pantalla del ATM
        private BaseDatosBanco baseDatos; // referencia a la base de datos de información de cuentas

        // constructor de tres parámetros invocado por las clases derivadas
        public Transaccion(int cuentaUsuario, Pantalla laPantalla,
        BaseDatosBanco laBaseDatos)
        {
            numeroCuenta = cuentaUsuario;
            pantallaUsuario = laPantalla;
            baseDatos = laBaseDatos;
        } // fin del constructor

        // propiedad de sólo lectura que obtiene el número de cuenta
        public int NumeroCuenta
        {
            get
            {
                return numeroCuenta;
            } // fin de get
        } // fin de la propiedad NumeroCuenta

        // propiedad de sólo lectura que obtiene la referencia a la pantalla
        public Pantalla PantallaUsuario
        {
            get
            {
                return pantallaUsuario;
            } // fin de get
        } // fin de la propiedad PantallaUsuario

        // propiedad de sólo lectura que obtiene la referencia a la baseDatos del banco
        public BaseDatosBanco BaseDatos
        {
            get
            {
                return baseDatos;
            } // fin de get
        } // fin de la propiedad BaseDatos

        // realiza la transacción (cada clase derivada lo redefine)
        public abstract void Ejecutar(); // no hay implementación aquí
    } // fin de la clase Transaccion
}
