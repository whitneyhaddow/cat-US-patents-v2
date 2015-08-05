using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//This form allows user to input data for a patent, then turns it into a Patent object and allows object to be passed to another form
namespace Haddow_Whitney_Lab2_CP3
{
    public partial class frmAddNew : Form
    {
        public frmAddNew()
        {
            InitializeComponent();
        }

        private Patent patent = null;

        public int SearchKey { get; set; }

        private void frmAddNew_Load(object sender, EventArgs e)
        {
            if (SearchKey != 0) //if a key was searched prior to opening this form
                txtNumber.Text = SearchKey.ToString();
        }

        public Patent GetNewPatent()
        {
            this.ShowDialog(); //open this form
            return patent;
        }

        public int GetNewKey()
        {
            int key = patent.Number;
            return key;
        }

        //test if all inputs contain valid data
        private bool IsValidData()
        {
            return Validator.IsPresent(txtNumber) &&
                   Validator.IsInt32(txtNumber) &&
                   Validator.IsValidLength(txtNumber, 7, "digits") &&
                   Validator.IsPresent(txtAppNumber) &&
                   Validator.IsPresent(txtDescription) &&
                   Validator.IsPresent(txtFilingDate) &&
                   Validator.IsDateTime(txtFilingDate) &&
                   Validator.IsPresent(txtInventor);
        }

        //save all info as new patent object
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                patent = new Patent(
                    Convert.ToInt32(txtNumber.Text),
                    txtAppNumber.Text,
                    txtDescription.Text,
                    DateTime.Parse(txtFilingDate.Text),
                    txtInventor.Text,
                    txtInventor2.Text);
                this.Close();
            }
        }
        
        //close this form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

              
    } //END CLASS
}
