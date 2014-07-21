using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Criterio
    {
        public int idCriterio { get; set; }
        public int idProyecto { get; set; }
        public string nombre { get; set; }
        public string abreviacion { get; set; }
        public int peso { get; set; }
        public string color { get; set; }
        public bool esTipoMax { get; set; }

        public string getTipo()
        {
            if (esTipoMax)
                return "Max";
            return "Min";
        }
    }
}
