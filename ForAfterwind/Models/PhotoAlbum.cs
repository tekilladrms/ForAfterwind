using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Models
{
    public class PhotoAlbum
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PathToPhotoAlbum { get; set; }
        public string PathToCover { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public bool IsOnMap { get; set; }

        public PhotoAlbum()
        {
            Photos = new List<Photo>();
        }
    }
}
