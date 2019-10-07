﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starglade.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Starglade.Web.Controllers.Api
{
    
    public class PostController : StargladeController
    {
        IPostService postService;

        public PostController(IPostService postService)
        {
            
            this.postService = postService;
        }

        public IActionResult Get()
        {
            return null;
        }
    }
}