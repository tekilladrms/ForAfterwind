using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Domain
{
    public class Video
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        public string PathToVideo { get; set; }
        public int? ReleaseId { get; set; }
        public Release Release { get; set; }
        public int? VideoAlbumId { get; set; }
        public VideoAlbum VideoAlbum { get; set; }

    }
}
