﻿using ForAfterwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Greeting> greetings { get; set; }
        public IEnumerable<ProgressBar> progressBars { get; set; }
    }
}
