using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Models
{
    public class Song
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        public string PathToSong { get; set; }
        public TypesOfReleases? Type { get; set; }

        
        public int? ReleaseId { get; set; }
        public Release Release { get; set; }

    }
}
