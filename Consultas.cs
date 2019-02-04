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

    public partial class Consultas : Form
    {
        AccesoDatos ad = new AccesoDatos(@"Data Source=EZE-PC\SQLEXPRESS;Initial Catalog=Autogestion9;Integrated Security=True");
         int contador =0;
        public Consultas()
        {
            InitializeComponent();
        }

        private void btnCon1_Click(object sender, EventArgs e)
        {
            lblConsulta.Text = "Consultas : Se quiere mostrar la nota promedio y su nombre. Mostrar estos datos solo para los casos en que su promedio de notas sea inferior al importe promedio del alumno";
            
           string consultaSQL = "select * from pa_libro_autor "; //hacer una consulta mas compleja.
            dataGridView1.DataSource = ad.consultadb2(consultaSQL);
            lblParametro1.Text = "Poner un Nombre";
            contador = 1;

        }

        private void btnagregartado_Click(object sender, EventArgs e)
        {
            if (contador==1)
            {
                string consultaSQL = " exec pa_libros_autor " + textBox1.Text; //hacer una consulta mas compleja.
                dataGridView1.DataSource = ad.consultadb2(consultaSQL);
            }

        }

        private void btnCon2_Click(object sender, EventArgs e)
        {

            lblConsulta.Text = "Consulta : Se desea contar la cantidad de alumnos con nota menor a 4. Rotule la lista con el nombre APLAZADOS y que comienzan con la letra “M” y que el teléfono sea conocido";
            string consultaSQL = "select * from pa_libro_autor "; //hacer una consulta mas compleja.
            dataGridView1.DataSource = ad.consultadb2(consultaSQL);
            lblParametro1.Text = "Poner un Nombre";
            contador = 2;
        }

        private void Consultas_Load(object sender, EventArgs e)
        {

        }
    }
}
