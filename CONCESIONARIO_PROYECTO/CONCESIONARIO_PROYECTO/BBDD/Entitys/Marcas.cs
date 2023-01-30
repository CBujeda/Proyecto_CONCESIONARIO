using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CONCESIONARIO_PROYECTO.BBDD.Entitys
{
    public class Marcas
    {

        public int id_marcas { get; set; }
        public String nombre { get; set; }
        public String pais { get; set; }
        public DateTime anno_creacion { get; set; }

        public List<Modelos> modelos { get; set; }
    }
}