using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programacion
{
    public partial class consulta2 : Form
    {

        AccesoDatos ad = new AccesoDatos(@"Data Source=(local);Initial Catalog=Autogestion9;Integrated Security=True");
        const int tam = 30;
        Docentes[] vi = new Docentes[tam];

        public consulta2()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 pri = new Form1();
            pri.Show();
            Close();
        }

        private void consulta2_Load(object sender, EventArgs e)
        {

        }

        private void btnConsulta1_Click(object sender, EventArgs e)
        {
        
            string consultaSQL = "exec c2 '" + txtCon2.Text + "%'";
            dataGridView1.DataSource = ad.consultadb2(consultaSQL);
            
        }

        private void txtCon2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("solo se permiten letras");
            }
        }
    }
}
