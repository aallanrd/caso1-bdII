using Modelo.ServicioWEB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioWEB.Controladores
{
    public class aSQLController 
    {

        SQLConnect conexion;
        public aSQLController()
        {
            conexion = new SQLConnect("root", "Ard2592allan", "DESKTOP-3ALTQEK", 1433, "master");
        }
        public aSQLController(string uid, string pass, string server, int port, string database)
        {
            conexion = new SQLConnect( uid,  pass,  server,  port,  database);
        }

        internal string check()
        {
            
            try
            {
                if (conexion.OpenConnection().Equals("Connected"))
                {
                    return "Conectado al pool conexiones SQL";
                }
                else
                {
                    return "Cant- connect";
                }
            }
            catch(Exception e)
            {
                return "Cant- connect";
            }
        }
    }
}