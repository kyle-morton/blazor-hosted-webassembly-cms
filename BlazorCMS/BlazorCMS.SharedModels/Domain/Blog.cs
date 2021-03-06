﻿using System.Collections.Generic;

namespace BlazorCMS.Shared.Domain
{
    public class Blog : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<BlogPost> BlogPosts { get; set; }
    }
}
