using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CONCESIONARIO_PROYECTO.BBDD.Entitys
{
    public class Vehiculos
    {
        public int id_vehiculo { get; set; }
        public int nombre { get; set; }
        public int tipo { get; set; }
        public Modelos id_modelo { get; set; }
    }
}