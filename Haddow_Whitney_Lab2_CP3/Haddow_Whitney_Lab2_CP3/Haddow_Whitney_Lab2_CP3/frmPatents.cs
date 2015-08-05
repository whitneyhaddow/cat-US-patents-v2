using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//This form displays list of patent objects and allows the user to search for patents by their key (Patent Number).
//Receives search data from search form and patent objects from the Add New form.
namespace Haddow_Whitney_Lab2_CP3
{
    public partial class frmPatents : Form
    {
        public frmPatents()
        {
            InitializeComponent();
        }

        private SortedList<int, Patent> patents = new SortedList<int, Patent>();
        
        private void frmPatents_Load(object sender, EventArgs e)
        {
            //add columns to listview     
            lvPatents.Columns.Add("Patent Number", 90, HorizontalAlignment.Left);
            lvPatents.Columns.Add("Application Number", 110, HorizontalAlignment.Left);
            lvPatents.Columns.Add("Description", 180, HorizontalAlignment.Left);
            lvPatents.Columns.Add("Filing Date", 75, HorizontalAlignment.Left);
            lvPatents.Columns.Add("Inventor", 120, HorizontalAlignment.Left);
            lvPatents.Columns.Add("Inventor 2", 120, HorizontalAlignment.Left);

            patents = PatentDB.GetPatents(); //read XML file for patent data
            FillPatentListView();
            btnEdit.Enabled = false;
        }

        //############### ADDING ###############
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNew newPatentForm = new frmAddNew(); 
            Patent patent = newPatentForm.GetNewPatent();
            if (patent != null) 
            {
                int key = newPatentForm.GetNewKey();
                patents.Add(key, patent); 
                PatentDB.SavePatents(patents); 
                FillPatentListView();
            }
            btnEdit.Enabled = false;
        } //END ADD CLICK


        //############### SEARCHING ###############
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch searchForm = new frmSearch(); 
            string searchString = searchForm.GetSearchString();
            int searchKey = 0;

            if (Int32.TryParse(searchString, out searchKey)) //if there was input in the search form
            {
                if (patents.ContainsKey(searchKey))
                {
                    //get select patent using the key
                    Patent searchPatent = patents[searchKey];

                    lvPatents.Items.Clear(); //clear listview

                    AddSearchPatentToListView(searchPatent);
                }
                else
                {
                    DialogResult result = MessageBox.Show("No records exist for that patent. \nPress 'OK' to add a record.",
                            "No Record Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.OK)
                    {
                        frmAddNew newPatentForm = new frmAddNew(); 
                        newPatentForm.SearchKey = searchKey;
                        Patent patent = newPatentForm.GetNewPatent();

                        if (patent != null) 
                        {
                            int key = newPatentForm.GetNewKey();
                            patents.Add(key, patent); 
                            PatentDB.SavePatents(patents); 
                            FillPatentListView();
                        }
                    }
                }
                btnEdit.Enabled = false;
            }
        } //END SEARCH CLICK

        

        //############### EDITING ###############
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmUpdate updateForm = new frmUpdate(); 

            //find key of selected item
            ListViewItem selected = lvPatents.FocusedItem;
            int key = Convert.ToInt32(selected.Text);

            //get patent with that key
            Patent p = patents[key];

            //pass patent object to update form
            updateForm.updatePatent = p;

            //get new patent object
            Patent patent = updateForm.GetUpdatedPatent();

            //delete old patent record
            patents.Remove(key);

            //save object to list and to xml, load that record in listview
            if (patent != null)
            {
                int newKey = updateForm.GetNewKey();
                patents.Add(newKey, patent); 
                PatentDB.SavePatents(patents); 
                FillPatentListView();
            }

            btnEdit.Enabled = false;
        } //END EDIT


        //############### ADDITIONAL METHODS ###############
        
        //Fill list view with data from XML file
        private void FillPatentListView()
        {
            lvPatents.Items.Clear();
            if (patents.Count > 0)
            {
                Patent p; //next patent  
                IList<Patent> patentValues = patents.Values;

                for (int i = 0; i < patentValues.Count; i++)
                {
                    p = patentValues[i]; //take the next patent
                    //add data to listView
                    lvPatents.Items.Add(p.Number.ToString());
                    lvPatents.Items[i].SubItems.Add(p.AppNumber);
                    lvPatents.Items[i].SubItems.Add(p.Description);
                    lvPatents.Items[i].SubItems.Add(p.FilingDate.ToString("yyyy-MM-dd"));
                    lvPatents.Items[i].SubItems.Add(p.Inventor);
                    if (p.Inventor2 != "")
                        lvPatents.Items[i].SubItems.Add(p.Inventor2);
                    else
                        lvPatents.Items[i].SubItems.Add("N/A");
                }
            }
            else
            {
                MessageBox.Show("There are no patent records yet. Please add new patent information.", "No Records");
            }
        }

        //Displays search result in listview
        private void AddSearchPatentToListView(Patent p)
        {
            ListViewItem item = new ListViewItem();
            item.Text = p.Number.ToString();
            item.SubItems.Add(p.AppNumber);
            item.SubItems.Add(p.Description);
            item.SubItems.Add(p.FilingDate.ToString("yyyy-MM-dd"));
            item.SubItems.Add(p.Inventor);
            if (p.Inventor2 != "")
                item.SubItems.Add(p.Inventor2);
            else
                item.SubItems.Add("N/A");
            lvPatents.Items.Add(item);
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            FillPatentListView();
            btnEdit.Enabled = false; //disable edit button
        }

        //enable edit button when item is selected
        private void lvPatents_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btnEdit.Enabled = true;
        }

        //close application
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
       
    } //END CLASS
}
