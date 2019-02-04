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
    public partial class consulta4 : Form
    {

        AccesoDatos ad = new AccesoDatos(@"Data Source=(local);Initial Catalog=Autogestion9;Integrated Security=True");
        const int tam = 30;
        Docentes[] vi = new Docentes[tam];
        public consulta4()
        {
            InitializeComponent();
        }

        private void btnConsulta4_Click(object sender, EventArgs e)
        {

            if (vacio() == true)
            {

                string consultaSQL = "exec c4 " + txtAño.Text + ",'" + txtCon4.Text + "%'";
                dataGridView1.DataSource = ad.consultadb2(consultaSQL);
            }
            else
                MessageBox.Show("complete campo");
        }

        private void consulta4_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 pri = new Form1();
            pri.Show();
            Close();
        }


        private bool vacio()
        {
           
            int contador = 0;

           
            if (txtAño.Text == "")
            {
                contador++;
            }

            
            if (contador > 0)
            {
                if (contador < 1)
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

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("solo se permiten numeros");
            }
        }

        private void txtCon4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCon4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("solo se permiten letras");
            }
        }
    }
}
