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
    public partial class Mostrar : Form
    {
        AccesoDatos ad = new AccesoDatos(@"Data Source=(local);Initial Catalog=Autogestion9;Integrated Security=True");
        string consultaSQL = "";
                      
        public Mostrar()
        {
            InitializeComponent();
        }

        private void Mostrar_Load(object sender, EventArgs e)
        {

        }

        private void btnconsultatodo_Click(object sender, EventArgs e)
        {
            //string consultaSQL;
            consultaSQL ="select * from  docentes "; //hacer una consulta mas compleja.
            dataGridView1.DataSource = ad.consultadb2(consultaSQL);
            
        }

        private void cmdcriterio_Click(object sender, EventArgs e)
        {
           //string consultaSQL;
            if (btnMasculino.Checked)
                consultaSQL = "select * from docentes where id_genero = 1";
            else
                consultaSQL = "select * from docentes where id_genero = 2";

            if (!string.IsNullOrEmpty(txtLetra.Text))
                consultaSQL += " and nombre like '%" + txtLetra.Text + "%'";

            dataGridView1.DataSource = ad.consultadb2(consultaSQL);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataSet dsImp;      // DataSet para generar XML y guardar datos a mostrar 
            dsImp = new DataSet();

            if (string.IsNullOrEmpty(consultaSQL))
                MessageBox.Show("No hay datos para mostrar en el reporte.");
            else
                dsImp.Tables.Add(ad.consultadb2(consultaSQL));
               //dsImp.WriteXml(@"C:\xml\docentes.xml", XmlWriteMode.WriteSchema);

            // Asignar datos de la consulta al reporte
            rptDocentes objRpt;                     // Reporte
            objRpt = new rptDocentes();           
            objRpt.SetDataSource(dsImp);

            // Vista previa del reporte
            frmVistaReportes rpt;                   // Formulario para vista previa 
            rpt = new frmVistaReportes();
            rpt.crystalReportViewer1.ReportSource = objRpt;
            rpt.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 pri = new Form1();
            pri.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtLetra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("solo se permiten letras");
            }
        }
    }
}
