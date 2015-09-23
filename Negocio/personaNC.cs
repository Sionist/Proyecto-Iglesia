using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Windows.Controls;
using Entidades;


namespace Negocio
{
    public class personaNC
    {
        public List<personaDTO> traerTodos() {
            personaDAL personaDAL = new personaDAL();
            return personaDAL.traerTodo();                     
        }

        public void nuevo(persona persona) {
            personaDAL personaDAL = new personaDAL();
            personaDAL.insertar(persona);
        }
    }
}
