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
    public partial class consulta7 : Form
    {
        AccesoDatos ad = new AccesoDatos(@"Data Source=(local);Initial Catalog=Autogestion9;Integrated Security=True");
        const int tam = 30;
        Docentes[] vi = new Docentes[tam];
        public consulta7()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 pri = new Form1();
            pri.Show();
            Close(); 
        }

        private void btnConsulta4_Click(object sender, EventArgs e)
        {
            string consultaSQL = "exec c7 '"+txtLetra.Text +"%'";
            dataGridView1.DataSource = ad.consultadb2(consultaSQL);

            
        }

        private void txtLetra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("solo se permiten letras");
            }
        }

        private void consulta7_Load(object sender, EventArgs e)
        {

        }
    }
}
