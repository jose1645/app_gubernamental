using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using sombrero.objetos;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace sombrero.services
{
    public class obtenerbacheservice : obtenerbaches
    {
        private string urlapi = "https://7xdnrs0gj2.execute-api.us-east-1.amazonaws.com/obtenerbaches";
        public async Task<List<bache>> obtener()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(urlapi);
            var responsebody = await response.Content.ReadAsStringAsync();
            JsonNode nodos = JsonNode.Parse(responsebody);
            JsonNode results = nodos["Items"];
            var bache = JsonSerializer.Deserialize<List<bache>>(results.ToString());
            return bache;
        }
    }
}
