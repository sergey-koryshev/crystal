using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crystal
{
    public partial class AddingPage : Form
    {
        int SelectedBook { get; set; }

        public AddingPage()
        {
            InitializeComponent();
        }

        public AddingPage(int _selectedBook)
        {
            SelectedBook = _selectedBook;
            InitializeComponent();
        }

        private void btnAddPluginTable_Click(object sender, EventArgs e)
        {
            SelectingPlugin addTablePlugin = new SelectingPlugin("Table");
            addTablePlugin.ShowDialog();
            if (addTablePlugin.Result != "")
            {
                txtTablePlugin.Text = addTablePlugin.Result;
            }
            addTablePlugin.Dispose();
        }

        private void btnAddStoreMethodPlugins_Click(object sender, EventArgs e)
        {
            SelectingPlugin addTablePlugin = new SelectingPlugin("StoreMethod");
            addTablePlugin.ShowDialog();
            if (addTablePlugin.Result != "")
            {
                txtStoreMethodPlugin.Text = addTablePlugin.Result;
            }
            addTablePlugin.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string[] tablePlugin = txtTablePlugin.Text.Split(new char[] { ';' }, 2);
            string[] storeMethodPlugin = txtStoreMethodPlugin.Text.Split(new char[] { ';' }, 2);
            Program.book.AddPage(txtName.Text, cbxIsLinked.Checked, txtOriginalTablePath.Text, txtNewTablePath.Text, "", "", tablePlugin[0], tablePlugin[1], storeMethodPlugin[0], storeMethodPlugin[1]);
            this.Close();
        }

        private void btnAddOriginalTable_Click(object sender, EventArgs e)
        {
            openTable.ShowDialog();

            txtOriginalTablePath.Text = openTable.FileName;
        }

        private void btnNewTablePath_Click(object sender, EventArgs e)
        {
            openTable.ShowDialog();

            txtNewTablePath.Text = openTable.FileName;
        }
    }
}
