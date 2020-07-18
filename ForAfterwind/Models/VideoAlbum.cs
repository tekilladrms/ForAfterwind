using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Models
{
    public class VideoAlbum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathToCover { get; set; }
        public string Description { get; set; }

        public ICollection<Video> Videos { get; set; }


        public VideoAlbum()
        {
            Videos = new List<Video>();
        }
    }
}
