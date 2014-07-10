using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proyecto
    {
        public int idProyecto { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
        public List<Criterio> listaCriterios { get; set; }
        public List<Variable> listaVariables { get; set; }
        public List<Alternativa> listaAlternativas { get; set; }
    }
}
