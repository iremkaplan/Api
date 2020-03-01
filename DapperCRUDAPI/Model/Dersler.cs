using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUDAPI.Model
{
    public class Dersler
    {
        [Key]
        public int Id { get; set; }
        public int  Class { get; set; }
        public string LessonName { get; set; }
    }
}
