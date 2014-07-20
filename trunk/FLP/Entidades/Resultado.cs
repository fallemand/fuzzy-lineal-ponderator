using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Resultado
    {
        public decimal a { get; set; }
        public decimal b { get; set; }
        public decimal c { get; set; }

        public decimal obtenerAenFormaTriangularLR()
        {
            return (b - a);
        }

        public decimal obtenerCenFormaTriangularLR()
        {
            return (c - b);
        }

        public decimal obtenerCentroGravedad()
        {
            decimal cdg = ((3 * b - obtenerAenFormaTriangularLR() + obtenerCenFormaTriangularLR()) / 3);
            return (Math.Truncate(1000 * cdg) / 1000);
        }
    }
}
