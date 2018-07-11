﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.AppLogic.DTO.Post
{
    public class PostInsDTO
    {
        public string Content { get; set; }

        public int Rating { get; set; }

        public int Views { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

    }
}
