using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haddow_Whitney_Lab2_CP3
{
    class Validator
    {
        private static string title = "Entry Error";

        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + " is a required field.", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsInt32(TextBox textBox)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsDateTime(TextBox textBox)
        {
            DateTime date;
            if (DateTime.TryParse(textBox.Text, out date))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + "must be a date.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsValidLength(TextBox textBox, int length, string type) //type is digits or characters
        {
            string s = textBox.Text;
            if (s.Length != 7)
            {
                MessageBox.Show(textBox.Tag + " must have " + length.ToString()
                    + " " + type +".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

    } //END CLASS
}
