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
    public partial class btnHabilitar : Form
    {
        AccesoDatos ad = new AccesoDatos(@"Data Source=(local);Initial Catalog=Autogestion9;Integrated Security=True");
        const int tam = 30;
        Docentes[] vi = new Docentes[tam];
        public btnHabilitar()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 pri = new Form1();
            pri.Show();
            this.Close();
        }

        private void Baja_Load(object sender, EventArgs e)
        {

            desabilitar();

            cargarlista("docentes");
            cargarcombo(cbobarrio, "Barrios");
            cargarcombo(cbotipo_dni, "tipo_dni");
            cargarcombo(cbogenero, "generos");
            cargarcombo(cbocivil, "estado_civil");
        }
        private void cargarcombo(ComboBox cbobodega, string nombretabla)
        {
            DataTable vin = ad.consultartabla(nombretabla);
            cbobodega.DataSource = vin;
            cbobodega.ValueMember = vin.Columns[0].ColumnName;
            cbobodega.DisplayMember = vin.Columns[1].ColumnName;
            cbobodega.SelectedIndex = -1;

        }

        private void cargarlista(string nombretabla)
        {

            int c = 0;
            ad.leertabla(nombretabla);
            while (ad.Lector.Read())
            {
                vi[c] = new Docentes();

                if (!ad.Lector.IsDBNull(0))
                {
                    vi[c].pMatricula = ad.Lector.GetInt32(0);


                    if (!ad.Lector.IsDBNull(1))
                        vi[c].pNombre = ad.Lector.GetString(1);
                    if (!ad.Lector.IsDBNull(2))
                        vi[c].pApellido = ad.Lector.GetString(2);
                    if (!ad.Lector.IsDBNull(3))
                        vi[c].pDni = ad.Lector.GetInt32(3);
                    if (!ad.Lector.IsDBNull(4))
                        vi[c].pCalle = ad.Lector.GetString(4);
                    if (!ad.Lector.IsDBNull(5))
                        vi[c].pNumero = ad.Lector.GetInt32(5);
                    if (!ad.Lector.IsDBNull(6))
                        vi[c].pTelefono = ad.Lector.GetInt32(6);

                    if (!ad.Lector.IsDBNull(7))
                        vi[c].pEmail = ad.Lector.GetString(7);
                    if (!ad.Lector.IsDBNull(8))
                        vi[c].pIdbarrio = ad.Lector.GetInt32(8);
                    if (!ad.Lector.IsDBNull(9))
                        vi[c].pTip_dni = ad.Lector.GetInt32(9);
                    if (!ad.Lector.IsDBNull(10))
                        vi[c].pGenero = ad.Lector.GetInt32(10);
                    if (!ad.Lector.IsDBNull(11))
                        vi[c].pIdcivil = ad.Lector.GetInt32(11);
                    c++;
                }

            }

            ad.Lector.Close();
            ad.desconectar();
            listBox1.Items.Clear();
            for (int i = 0; i < c; i++)
            {
                listBox1.Items.Add(vi[i].tostring());
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarcampo(listBox1.SelectedIndex);
        }



        private void btnBaja_Click(object sender, EventArgs e)
        {
          //  string sql = "Delete from docentes where dni = " + vi[listBox1.SelectedIndex].pDni;
          //  ad.actualizarbd(sql);
          //  cargarlista("docentes");
          //  MessageBox.Show("Borrado con exito");

            if (MessageBox.Show("Esta seguro de Borrar esta Persona"
                                 , "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) 
            
            {
                string sql = "Delete from docentes where dni = " + vi[listBox1.SelectedIndex].pDni;
                ad.actualizarbd(sql);
                cargarlista("docentes");
                MessageBox.Show("Borrado con exito");
            }
        }

        private void actualizarcampo(int posicion)
        {
            txtmatricula.Text = Convert.ToString(vi[posicion].pMatricula);
            txtnombre.Text = vi[posicion].pNombre;
            txtapellido.Text = vi[posicion].pApellido;
            txtdni.Text = Convert.ToString(vi[posicion].pDni);
            txtcalle.Text = vi[posicion].pCalle;
            txtnumero.Text = Convert.ToString(vi[posicion].pNumero);
            txttelefono.Text = Convert.ToString(vi[posicion].pTelefono);
            txtemail.Text = vi[posicion].pEmail;
            cbobarrio.SelectedValue = vi[posicion].pIdbarrio;
            cbotipo_dni.SelectedValue = vi[posicion].pTip_dni;
            cbogenero.SelectedValue = vi[posicion].pGenero;
            cbocivil.SelectedValue = vi[posicion].pIdcivil;
           // cbobarrio.SelectedValue =Convert.ToString(vi[posicion].pIdbarrio);
           // cbotipo_dni.SelectedValue = Convert.ToString(vi[posicion].pTip_dni);
           // cbogenero.SelectedValue = Convert.ToString(vi[posicion].pGenero);
           // cbocivil.SelectedValue = Convert.ToString(vi[posicion].pIdcivil);

        }

        private void habilitar()
        {
            txtapellido.Enabled = true;
            txtcalle.Enabled = true;
            txtdni.Enabled = true;
            txtemail.Enabled = true;
            txtmatricula.Enabled = true;
            txtnombre.Enabled = true;
            txtnumero.Enabled = true;
            txttelefono.Enabled = true;
            cbobarrio.Enabled = true;
            cbocivil.Enabled = true;
            cbogenero.Enabled = true;
            cbotipo_dni.Enabled = true;
        }

        private void desabilitar()
        {
            txtapellido.Enabled = false;
            txtcalle.Enabled = false;
            txtdni.Enabled = false;
            txtemail.Enabled = false;
            txtmatricula.Enabled = false;
            txtnombre.Enabled = false;
            txtnumero.Enabled = false;
            txttelefono.Enabled = false;
            cbobarrio.Enabled = false;
            cbocivil.Enabled = false;
            cbogenero.Enabled = false;
            cbotipo_dni.Enabled = false;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            habilitar();
        }
    }
}
