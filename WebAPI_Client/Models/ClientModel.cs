using System;
using System.Collections.Generic;
using WebAPI_Client.Util;
using Newtonsoft.Json;

namespace WebAPI_Client.Models
{
    public class ClientModel
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string sexo { get; set; }

        public List<ClientModel> ListAllClients(){


            List<ClientModel> clients = new List<ClientModel>();

            string jsonReturn = WebAPI.RequestGET("ListClients", "");

            clients = JsonConvert.DeserializeObject<List<ClientModel>>(jsonReturn);

            return clients;
        }
    }
}
