using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleAlternativa
    {
        public Criterio criterio { get; set; }
        public Variable variable { get; set; }
        public DetalleAlternativa()
        {
            criterio = new Criterio();
            variable = new Variable();
        }
    }
}
