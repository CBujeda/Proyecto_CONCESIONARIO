using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using System.Web;
using System.Configuration;
using System.Data;
using NUnit.Framework;
using CONCESIONARIO_PROYECTO.BBDD.Entitys;
using LinqToDB.Configuration;

namespace CONCESIONARIO_PROYECTO.BBDD
{


    public class ConcesionarioRepository
    {



        public void CreateBBDD([Values(
               ProviderName.MySqlConnector
        )] String configString)
        {
            // Obtenemos la conexion a la base de datos
            String strConexion = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;

            using (var db = new DataConnection(strConexion))
            {
                try
                {
                    db.DropTable<Marcas>();
                }
                catch
                {
                }
                db.CreateTable<Marcas>();
            }
        }

    }


}