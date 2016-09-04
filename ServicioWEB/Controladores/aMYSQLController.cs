using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioWEB.Controladores;
using Modelo.ServicioWEB;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using Newtonsoft.Json;

namespace ServicioWEB.Controladores
{
    public class aMYSQLController
    {
        MYSQLDBConnect conexion = new MYSQLDBConnect("root", "Ard2592allan", "localhost", 3306, "sakila");

        //Chequear que existe una conexion posible de mariaDB con el modelo del parámetro.
        public string check()
        {

           
            if (conexion.OpenConnection().Equals("Connected"))
            {
                /* mariaDB.Insert(db);
                string Query = "select * from sakila";
                MySqlCommand cmd = new MySqlCommand(Query, conexion.connection);
                cmd.ExecuteNonQuery();*/
                return "Conectado a MySQL ";
            }
            else
            {
                return "Cant connect";
            }


        }

    }

}