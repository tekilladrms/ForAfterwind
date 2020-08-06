using ForAfterwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.ViewModels
{
    public class PhotoMapViewModel
    {
        public IEnumerable<City> Cities { get; set; }

        public IEnumerable<PhotoAlbum> PhotoAlbums { get; set; }
    }
}
