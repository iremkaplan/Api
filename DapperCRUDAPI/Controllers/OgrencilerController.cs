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
    public class OgrencilerController : ControllerBase
    {
        private readonly OgrenciIslemleri ogrencilerIslemleri;

        public OgrencilerController()
        {
            ogrencilerIslemleri = new OgrenciIslemleri();
        }

        [HttpGet]
        public IEnumerable<Ogrenciler> GetAll()
        {
            return ogrencilerIslemleri.GetAll();
        }
        [HttpPost]
        public void Post([FromBody]Ogrenciler stu)
        {
            if (ModelState.IsValid)
                ogrencilerIslemleri.Add(stu);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Ogrenciler stu)
        {
            stu.Id = id;
            if (ModelState.IsValid)
                ogrencilerIslemleri.Update(stu);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            ogrencilerIslemleri.Delete(id);
        }
    }
}