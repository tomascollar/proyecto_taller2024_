using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProyectoTaller2
{
    internal class Validar
    {
        public static bool soloNumeros(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else
            {
                e.Handled = true;
                return false;
            }
        }

        public static bool txtVacios(TextBox ptxt)
        {
            if (ptxt.Text == string.Empty)
            {
                // ptxt.Focus();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool soloLetras(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else
            {
                e.Handled = true;
                return false;
            }
        }

        public static bool validarEmail(string email)
        {

            //definimos la expresion regular con la cual vamos a validar el email
            string patron = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";

            //utiizamos la funcion regex.ismatch para comparar el string ingresado con el patron
            return Regex.IsMatch(email, patron);
        }
    }
}
