﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections;

//Prueba

namespace ServicioWEB
{
    class MongoConnect
    {
        public  static MongoClient _client;
    


        // public MongoDB.Driver.ConnectionMode connection;

        public MongoConnect()
        {

           
            _client = new MongoClient();

        }

        public ArrayList users = new ArrayList();

        public  void start()
        {
            //string conn = "mongodb://[aallanrd:abc1234@]localhost[:27017 ][/[local][?]]";
            // _client = new MongoClient(conn);
             OpenConnection();
        }

        //ABre una conexion y crea una base de datos :D
        public  string  OpenConnection()
        {

            var database = _client.GetDatabase("test");

            //MongoServer server = _client.GetServer();
            //MongoDatabase db = server.GetDatabase("MyDatabase");

            if (database != null)
            {
               
               return "Connected";
             
            }
            else
            {
                return "Cant Get Database";
            }


        }

      

        //Close connection
        public bool CloseConnection()
        {
            try
            {
              //  connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
