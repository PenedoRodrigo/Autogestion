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
    public partial class consulta5 : Form
    {
        AccesoDatos ad = new AccesoDatos(@"Data Source=(local);Initial Catalog=Autogestion9;Integrated Security=True");
        const int tam = 30;
        Docentes[] vi = new Docentes[tam];

        public consulta5()
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
            if (vacio() == true)
            {
                string consultaSQL = "exec c5 " + txtNcurso.Text + "," + txtNmateria.Text;
                dataGridView1.DataSource = ad.consultadb2(consultaSQL);
            }
            else
                MessageBox.Show("complete campo");
        }

        private void consulta5_Load(object sender, EventArgs e)
        {

        }

        private bool vacio()
        {

            int contador = 0;

            if (txtNcurso.Text == "")
            {
                contador++;
            }
            if (txtNmateria.Text == "")
            {
                contador++;
            }
            if (contador > 0)
            {
                if (contador < 8)
                {
                    return false;

                }

                return false;

            }
            else
            {
                return true;

            }
        }

        private void txtNmateria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("solo se permiten numeros");
            }
        }

        private void txtNcurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("solo se permiten numeros");
            }
        }
    }

}
