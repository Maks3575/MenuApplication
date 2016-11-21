using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MenuApplication.DataAccess.DB;

namespace MenuApplication
{
    public partial class AddIngredientDialog : Form
    {
        public AddIngredientDialog()
        {
            InitializeComponent();
        }

        private void AddIngredientDialog_Load(object sender, EventArgs e)
        {
            DirectoryController DC = new DirectoryController();
            TypeIngredientsBindingSource.DataSource = DC.TypeIngredientFetch();

        }

        private void dtpRecord_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btOK_Click(object sender, EventArgs e)
        {
            
        }
    }
}
