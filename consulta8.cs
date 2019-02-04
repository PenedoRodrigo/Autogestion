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
    public partial class consulta8 : Form
    {

        AccesoDatos ad = new AccesoDatos(@"Data Source=(local);Initial Catalog=Autogestion9;Integrated Security=True");
        const int tam = 30;
        Docentes[] vi = new Docentes[tam];
        public consulta8()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string consultaSQL = "select * from vista8";
            dataGridView1.DataSource = ad.consultadb2(consultaSQL);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 pri = new Form1();
            pri.Show();
            Close();
        }

        private void consulta8_Load(object sender, EventArgs e)
        {

        }
    }
}
