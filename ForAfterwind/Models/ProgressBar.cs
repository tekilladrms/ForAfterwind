using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Models
{
    public class ProgressBar
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string Color { get; set; }

        
        public ICollection<AlbumStage> albumStages { get; set; }

        public ProgressBar()
        {
            albumStages = new List<AlbumStage>();
        }
    }
}
