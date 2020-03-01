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
    public class DerslerController : ControllerBase
    {
        private readonly DersIslemleri DersIslemleri;

        public DerslerController()
        {
            DersIslemleri = new DersIslemleri();
        }

        [HttpGet]
        public IEnumerable<Dersler> GetAll()
        {
            return DersIslemleri.GetAll();
        }
        [HttpPost]
        public void Post([FromBody]Dersler less)
        {
            if (ModelState.IsValid)
                DersIslemleri.Add(less);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Dersler less)
        {
            less.Id = id;
            if (ModelState.IsValid)
                DersIslemleri.Update(less);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            DersIslemleri.Delete(id);
        }
    }
}
