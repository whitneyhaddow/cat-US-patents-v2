using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//This form allows user to update a record
namespace Haddow_Whitney_Lab2_CP3
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }

        public Patent updatePatent { get; set; }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            txtNumber.Text = updatePatent.Number.ToString();
            txtAppNumber.Text = updatePatent.AppNumber;
            txtDescription.Text = updatePatent.Description;
            txtFilingDate.Text = updatePatent.FilingDate.ToString("yyyy-MM-dd");
            txtInventor.Text = updatePatent.Inventor;
            txtInventor2.Text = updatePatent.Inventor2;

            txtNumber.Focus();
        }

        public Patent GetUpdatedPatent()
        {
            this.ShowDialog(); //open this form
            return updatePatent;
        }

        public int GetNewKey()
        {
            int key = updatePatent.Number;
            return key;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                updatePatent = new Patent(
                    Convert.ToInt32(txtNumber.Text),
                    txtAppNumber.Text,
                    txtDescription.Text,
                    DateTime.Parse(txtFilingDate.Text),
                    txtInventor.Text,
                    txtInventor2.Text);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

    } //END CLASS
}
