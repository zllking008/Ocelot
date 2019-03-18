using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GoodsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoodsApi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get () {
            return new string[] { "value1 from GoodsApi", "value2 from GoodsApi" };

        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            // var itm=new Goods{
            //     Id=id,
            //     Content=$"{id}关联的商品"

            // };
            (int Id, string Content) itm = (id, $"{id}关联的商品");
            HttpClient client=new HttpClient();
            Task<string> t = client.GetAsync($"http://localhost:50002/api/{id}/android/10/10000").Result.Content.ReadAsStringAsync();
            if(t.Status== TaskStatus.RanToCompletion)
            {
                return t.Result;
            }
            return JsonConvert.SerializeObject (itm);
        }
    }
}