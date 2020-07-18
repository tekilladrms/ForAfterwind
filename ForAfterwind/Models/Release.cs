using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Models
{
    public class Release
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathToCover { get; set; }

        public ICollection<Song> Songs { get; set; }


        public Release()
        {
            Songs = new List<Song>();
        }
    }
    
}
