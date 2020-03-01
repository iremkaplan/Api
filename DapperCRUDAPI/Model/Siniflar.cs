using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUDAPI.Model
{
    public class Siniflar
    {
        [Key]
        public int Id { get; set; }
        public int  Class { get; set; }
        public string Lesson { get; set; }
    }
}
