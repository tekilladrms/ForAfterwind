using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Domain
{
    public class Musician
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Skills { get; set; }

        public List<SocialLink> SocialLinks { get; set; }


    }
}
