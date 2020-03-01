using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperCRUDAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinifController : ControllerBase
    {
        private readonly SinifIslemleri SinifIslemleri;

        public SinifController()
        {
            SinifIslemleri = new SinifIslemleri();
        }

        [HttpGet]
        public IEnumerable<Siniflar> GetAll()
        {
            return SinifIslemleri.GetAll();
        }
        [HttpPost]
        public void Post([FromBody]Siniflar clss)
        {
            if (ModelState.IsValid)
                SinifIslemleri.Add(clss);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Siniflar clss)
        {
            clss.Id = id;
            if (ModelState.IsValid)
                SinifIslemleri.Update(clss);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            SinifIslemleri.Delete(id);
        }
    }
}
