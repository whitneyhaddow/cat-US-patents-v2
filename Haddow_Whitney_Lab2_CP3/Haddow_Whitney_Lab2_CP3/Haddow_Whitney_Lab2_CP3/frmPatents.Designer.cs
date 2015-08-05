namespace Haddow_Whitney_Lab2_CP3
{
    partial class frmPatents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvPatents = new System.Windows.Forms.ListView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(579, 333);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(133, 34);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(162, 333);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 34);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Add New...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvPatents
            // 
            this.lvPatents.FullRowSelect = true;
            this.lvPatents.HideSelection = false;
            this.lvPatents.Location = new System.Drawing.Point(12, 10);
            this.lvPatents.Name = "lvPatents";
            this.lvPatents.Size = new System.Drawing.Size(700, 307);
            this.lvPatents.TabIndex = 3;
            this.lvPatents.UseCompatibleStateImageBehavior = false;
            this.lvPatents.View = System.Windows.Forms.View.Details;
            this.lvPatents.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvPatents_ItemSelectionChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(23, 333);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(133, 34);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "&Search Patents...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(301, 333);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(133, 34);
            this.btnFill.TabIndex = 7;
            this.btnFill.Text = "&View All...";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(440, 333);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(133, 34);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "&Edit Record...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmPatents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 379);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvPatents);
            this.Name = "frmPatents";
            this.Text = "US Cat Patents";
            this.Load += new System.EventHandler(this.frmPatents_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvPatents;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnEdit;
    }
}

