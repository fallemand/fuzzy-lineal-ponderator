using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Variable
    {
        public int idVariable { get; set; }
        public int idProyecto { get; set; }
        public string nombre { get; set; }
        public string abreviacion { get; set; }
        public string color { get; set; }
        public decimal a { get; set; }
        public decimal b { get; set; }
        public decimal c { get; set; }
    }
}
