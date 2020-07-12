using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ForAfterwind.Domain
{
    public class Post
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public byte[] Cover { get; set; }
        public byte[] CoverThumbnail { get; set; }
        public string CoverMimeType { get; set; }

        public Post()
        {
            Tags = new List<Tag>();
        }
    }
    
}
