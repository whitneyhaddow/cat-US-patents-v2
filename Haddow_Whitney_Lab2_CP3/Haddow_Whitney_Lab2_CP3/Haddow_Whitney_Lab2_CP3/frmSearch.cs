using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//This form allows user to search for a patent based on it's key (Patent Number)
namespace Haddow_Whitney_Lab2_CP3
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private string searchString = ""; //string to pass search input to main form

        public string GetSearchString()
        {
            this.ShowDialog(); //open this form
            return searchString;
        }

        //Get key that was typed and close this form
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidSearch())
            {
                searchString = txtNumber.Text; 
                this.Close();
            }
        }

        private bool IsValidSearch()
        {
            return Validator.IsPresent(txtNumber) &&
                   Validator.IsInt32(txtNumber) &&
                   Validator.IsValidLength(txtNumber, 7, "digits");
        }

        //Cancel out of this form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    } //END CLASS
}
