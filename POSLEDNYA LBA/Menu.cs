using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSLEDNYA_LBA;
using POSLEDNYA_LBA.MatrixElements;

namespace POSLEDNYA_LBA
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teleport teleport = new Teleport(8,8);
            Field field = new Field();
            field.Searialize();
            field = field.BuildField(teleport, "Field.json");
            MainForm mainForm = new MainForm(field, this);
            mainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
