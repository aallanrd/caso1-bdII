using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using WebApp.ServiceReference1;
using WebApp.Models;
using System.Threading;
using System.Collections;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
   

    public class AppController : Controller
    {


        // CLiente del Servicio Web 
        static Service1Client client = new Service1Client();

        // Index : Retorna vista de seleccion de funciónes.
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        //Llamada en el boton
        public ActionResult HttpVerConexiones(string db_type)
        {

           
            Thread newThread = new Thread(HilosLlamadaDB);
            newThread.Start(db_type);
           
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(list);

            return RedirectToAction("VerConexiones", new { x = json });   
        }
        // GET:     
        public ActionResult VerConexiones(string x)
        {
            ViewBag.lista = x;
            return View();
        }

        static ArrayList list;

        //Metodo principal de llamada a la base de datos
        public static void HilosLlamadaDB(object x)
        {
            list = new ArrayList();
            try
            {
                
                WaitHandle[] waitHandles = new WaitHandle[64];
                string resultado;
                for (int i = 0; i <=10; i++)
                { 
                    var handle = new EventWaitHandle(false, EventResetMode.ManualReset);
                    var thread = new Thread(() =>
                    {
                        //Thread.Sleep(i  * 1000);
                        resultado = client.getConnections(x.ToString());
                        list.Add(resultado);
                        handle.Set();
                    });
                    waitHandles[i] = handle;
                    thread.Start();
                }
             

            }

            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort Exception");
            }
            finally
            {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }
        }





    }
}
