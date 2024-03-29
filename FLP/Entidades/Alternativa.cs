﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alternativa
    {
        public int idAlternativa { get; set; }
        public int idProyecto { get; set; }
        public string nombre { get; set; }
        public string abreviacion { get; set; }
        public string color { get; set; }
        public List<DetalleAlternativa> listaDetallesAlternativa { get; set; }
        public Resultado resultado { get; set; }
    }
}
