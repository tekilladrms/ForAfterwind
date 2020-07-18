﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Models
{
    public class PostCover
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public byte[] Content { get; set; }
        public string MimeType { get; set; }
    }
}
