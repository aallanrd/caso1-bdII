using Modelo.ServicioWEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioWEB.Controladores;
using System.Collections;
using Newtonsoft.Json;

namespace ServicioWEB
{
    class Multidatabase : InterfaceDB
    {

        aSQLController controlSQL = new aSQLController();
        aMYSQLController controlMYSQL = new aMYSQLController();
        aMongoController controlMongo = new aMongoController();
        
        public string getConnections(String dbType) 
        {
            
                switch (dbType)
                {
                    case "MySQL": return controlMYSQL.check();
                    case "Mongo": return controlMongo.check();
                    case "SQL": return controlSQL.check();
                    default: return "Cant Check";
                }
               
          
           
        }

     
    }
}
