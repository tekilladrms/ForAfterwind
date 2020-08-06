using ForAfterwind.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.ViewModels
{
    public class EditPhotoAlbumViewModel
    {
        public PhotoAlbum PhotoAlbum { get; set; }

        public string PathToCover { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }

        
    }
}
