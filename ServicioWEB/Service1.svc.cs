
using Newtonsoft.Json;
using ServicioWEB.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace ServicioWEB
{
     
    public class Service1 : IService1
    {
        InterfaceDB dbx = new Multidatabase();

     

        public string getConnections(String dbType)
        {
            string connections = dbx.getConnections(dbType);
            return connections;
        }
    }
}
