using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForAfterwind.Models
{
    public class Musician
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Photo { get; set; }

        public ICollection<SocialLink> SocialLinks { get; set; }
        public ICollection<Skill> Skills { get; set; }

        public Musician()
        {
            SocialLinks = new List<SocialLink>();
            Skills = new List<Skill>();
        }


    }
}
