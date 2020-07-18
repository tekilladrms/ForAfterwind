using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Models
{
    public class Photo
    {
        [Required]
        public int Id { get; set; }

        public string PathToPhoto { get; set; }

        public int? PhotoAlbumId { get; set; }

        public PhotoAlbum PhotoAlbum { get; set; }
    }
}
