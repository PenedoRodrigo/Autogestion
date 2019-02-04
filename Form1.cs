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
    public partial class Form1 : Form
    {
        
        
       

        public Form1()
        {
            InitializeComponent();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alta al = new Alta();
            al.Show();
            this.Hide();
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnHabilitar ba = new btnHabilitar();
            ba.Show();
            this.Hide();
        }

        private void modificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificar mo = new Modificar();
            mo.Show();
            this.Hide();
        }

        private void infoDocenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Mostrar mo = new Mostrar();
            mo.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();   
        }

        private void consultasSqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Consultas mo = new Consultas();
           // mo.Show();
           // this.Hide();
        }

        private void consulta1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta1 mo = new consulta1();
            mo.Show();
            this.Hide();
        }

        private void consulta2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta2 mo = new consulta2();
            mo.Show();
            this.Hide();
        }

        private void consulta3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta3 mo = new consulta3();
            mo.Show();
            this.Hide();
        }

        private void consulta4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta4 mo = new consulta4();
            mo.Show();
            this.Hide();
        }

        private void consulta5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta5 mo = new consulta5();
            mo.Show();
            this.Hide();
        }

        private void consulta6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta6 mo = new consulta6();
            mo.Show();
            this.Hide();
        }

        private void consulta7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta7 mo = new consulta7();
            mo.Show();
            this.Hide();
        }

        private void consulta8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta8 mo = new consulta8();
            mo.Show();
            this.Hide();
        }
    }
}
