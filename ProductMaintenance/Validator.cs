using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductMaintenance
{
    public class Validator
    {
        private static string title;

        public static string Title {get; set;}

        //method to check if the input is provided
        public static bool isPresent(TextBox textBox)
        {
            if (textBox.Text == String.Empty)
            {
                Title = " Entry Error";
                Title = textBox.Tag + Title;
                MessageBox.Show(textBox.Tag + " is a required field...cannot be blank",
                    Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                return false;
            }
            return true;

        }


    }
}
