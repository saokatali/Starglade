using System;
using System.Collections.Generic;
using System.Text;

namespace Starglade.Mobile.Models
{
    public class Post
    {
        public int PostId { get; set; }
       
        public string Title { get; set; }
  
        public string Content { get; set; }

        public DateTime PublishedOn { get; set; }

        public int TotalComments { get; set; }
    }
}
