using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(30, MinimumLength = 1)]
        public string Name { get; set; }

        public int Top { get; set; }
        public int Left { get; set; }

        public IEnumerable<PhotoAlbum> PhotoAlbums { get; set; }

        
        

        public City()
        {
            PhotoAlbums = new List<PhotoAlbum>();
        }
    }
}
