using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Domain
{
    public class SocialLink
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }


        public int? MusicianId { get; set; }
        public Musician Musician { get; set; }
    }
}
