using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CONCESIONARIO_PROYECTO.BBDD.Entitys
{
    public class Modelos
    {
        public int id_modelo { get; set; }
        public int modelo { get; set; }
        public int motor { get; set; }
        public Marcas id_marca { get; set; }
        public List<Vehiculos> vehiculos { get; set; }
    }
}