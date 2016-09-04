using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioWEB.Controladores;
using Modelo.ServicioWEB;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ServicioWEB.Controladores
{
    public class aMongoController
    {
         MongoConnect conexion;

        public aMongoController()
        {
            conexion = new MongoConnect();
            
        } 
       
        public string check()
        {
            try
            {
                // var connectionString = "mongodb://"+model.username+":"+model.pass+"@"+model.server+"/"+model.alias;

                MongoClient mongoClient = new MongoClient();

                var database = mongoClient.GetDatabase("allan");
                var collection = database.GetCollection<BsonDocument>("statistics");
                var json = mongoClient.Cluster.Description.State.ToString();
             
                if(json == "Connected")
                {
                    return "Conectado al Pull de Mongo";
                }else
                {
                    return json;
                }
                
            }
            catch(Exception e){
                return "No pude conectarme a Mongo";
            }
        }
    }



}