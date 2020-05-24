using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityAppBackend.Models
{
    public class Donate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string ImgPath { get; set; }
    }
}
