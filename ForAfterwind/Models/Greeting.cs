using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Models
{
    public class Greeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public byte[] Cover { get; set; }
        public bool IsActive { get; set; }
    }
}
