using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion
{
    class Docentes
    {
        int dni;
        string nombre;
        string apellido;
        string calle;
        int numero;
        int telefono;
        string email;
        int idbarrio;
        int tip_dni;
        int genero;
        int idcivil;
        int matricula;


        public string tostring()
        {
            return nombre + " " 
                 + apellido 
                 + " - " 
                 + "Mat:" 
                 + Convert.ToString(matricula)
               // + " - "
               //  + "DOC:"
               // + Convert.ToString(dni)
                 + " - " 
                 + "Tel:" 
                 + Convert.ToString(telefono);
        }


        public Docentes()
        {
            this.dni = 0;
            this.nombre = "";
            this.apellido = "";
            this.calle = "";
            this.numero = 0;
            this.telefono = 0;
            this.email = "";
            this.idbarrio = 0;
            this.tip_dni = 0;
            this.genero = 0;
            this.idcivil = 0;
            this.matricula = 0;
        }

        public Docentes(int dni, string nombre, string apellido, string calle, int numero, int telefono, string email, int idbarrio, int tip_dni, int genero, int idcivil, int matricula)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.calle = calle;
            this.numero = numero;
            this.telefono = telefono;
            this.email = email;
            this.idbarrio = idbarrio;
            this.tip_dni = tip_dni;
            this.genero = genero;
            this.idcivil = idcivil;
            this.matricula = matricula;
        }

        public int pDni { get => dni; set => dni = value; }
        public string pNombre { get => nombre; set => nombre = value; }
        public string pApellido { get => apellido; set => apellido = value; }
        public string pCalle { get => calle; set => calle = value; }
        public int pNumero { get => numero; set => numero = value; }
        public int pTelefono { get => telefono; set => telefono = value; }
        public string pEmail { get => email; set => email = value; }
        public int pIdbarrio { get => idbarrio; set => idbarrio = value; }
        public int pTip_dni { get => tip_dni; set => tip_dni = value; }
        public int pGenero { get => genero; set => genero = value; }
        public int pIdcivil { get => idcivil; set => idcivil = value; }
        public int pMatricula { get => matricula; set => matricula = value; }
    }
}
