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
    public partial class Modificar : Form
    {
        AccesoDatos ad = new AccesoDatos(@"Data Source=(local);Initial Catalog=Autogestion9;Integrated Security=True");
        const int tam = 30;
        Docentes[] vi = new Docentes[tam];
        public Modificar()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 pri = new Form1();
            pri.Show();
            this.Close();
        }

        private void Modificar_Load(object sender, EventArgs e)
        {

            desabilitar();

            txtdni.Enabled = false;
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

        }

        private void btnModi_Click(object sender, EventArgs e)
        {


            if (vacio() == true)
            {


                string consulta = "";
                Docentes v = new Docentes();
                v.pMatricula = Convert.ToInt32(txtmatricula.Text);
                v.pNombre = txtnombre.Text;
                v.pApellido = txtapellido.Text;
                v.pDni = Convert.ToInt32(txtdni.Text);
                v.pCalle = txtcalle.Text;
                v.pNumero = Convert.ToInt32(txtnumero.Text);
                v.pTelefono = Convert.ToInt32(txttelefono.Text);
                v.pEmail = txtemail.Text;
                v.pIdbarrio = Convert.ToInt32(cbobarrio.SelectedValue);
                v.pTip_dni = Convert.ToInt32(cbotipo_dni.SelectedValue);
                v.pGenero = Convert.ToInt32(cbogenero.SelectedValue);
                v.pIdcivil = Convert.ToInt32(cbocivil.SelectedValue);

                consulta = "Update docentes set  nombre= '" + v.pNombre +
                                           "' , " + " apellido= '" + v.pApellido +
                                           "' , " + " calle= '" + v.pCalle +
                                           " ', " + " numero= " + v.pNumero +
                                           " , " + " telefono= " + v.pTelefono +
                                           " , " + " email= '" + v.pEmail +
                                           "', " + " id_barrio= " + v.pIdbarrio +
                                           " , " + " id_tipo_dni= " + v.pTip_dni +
                                           " , " + " id_genero= " + v.pGenero +
                                           " , " + " id_estado_civil= " + v.pIdcivil + "" +
                                           " where dni= " + v.pDni + "and " + " id_matricula= " + v.pMatricula;


                ad.actualizarbd(consulta);
                cargarlista("docentes");
                desabilitar();
                MessageBox.Show("docente modificado con exito");
            }
            else
            {
                MessageBox.Show("Complete Campo");
            }
        }

        private void habilitar()
        {
            btnHabilitar.Enabled = false;
            btnModi.Enabled = true;
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
            btnHabilitar.Enabled = true;
            btnModi.Enabled = false;
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

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            habilitar();
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("solo se permiten letras");
            }

        }

        private void txtmatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("solo se permiten Numeros");
            }
        }

        private bool vacio()
        {

            int contador = 0;

            if (txtapellido.Text == "")
            {
                contador++;
            }
            if (txtcalle.Text == "")
            {
                contador++;
            }
            if (txtdni.Text == "")
            {
                contador++;
            }
            if (txtemail.Text == "")
            {
                contador++;
            }
            if (txtmatricula.Text == "")
            {
                contador++;
            }
            if (txtnombre.Text == "")
            {
                contador++;
            }
            if (txtnumero.Text == "")
            {
                contador++;
            }
            if (txttelefono.Text == "")
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
    }
}
