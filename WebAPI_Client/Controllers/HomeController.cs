using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Client.Models;
using Newtonsoft.Json;
using WebAPI_Client.Util;

namespace WebAPI_Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(ClientModel client)
        {

            //ClientModel client;

            //client = Model == null ? new ClientModel() : Model;

            ViewBag.ListAllClients = client.ListAllClients();

            return View(client);
        }

        public IActionResult AddClient(ClientModel client){

            string jsonData = JsonConvert.SerializeObject(client);
            //WebAPI.RequestPOST("AddClient",jsonData);
            WebAPI.RequestAll("AddClient", jsonData,"", EMethod.Post);

            return RedirectToAction("Index", "Home");
        }


        public IActionResult UpdateClient(ClientModel client)
        {

            string jsonData = JsonConvert.SerializeObject(client);
            WebAPI.RequestAll("update", jsonData, client.id.ToString(),EMethod.Put);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult SelectClient(ClientModel client)
        {

            string json = WebAPI.RequestGET("client", client.id.ToString());

            ClientModel clientModel = JsonConvert.DeserializeObject<ClientModel>(json);

            return RedirectToAction("Index", clientModel);
        }

        public IActionResult DeleteClient(ClientModel client)
        {

            WebAPI.RequestAll("delete", "",client.id.ToString(),EMethod.Delete);

            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
