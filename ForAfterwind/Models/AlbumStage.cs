using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Models
{
    public class AlbumStage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, 100, ErrorMessage = "Количество процентов может быть от 0 до 100")]
        public int Progress { get; set; }

        public int? ProgressBarId { get; set; }

    }
}
