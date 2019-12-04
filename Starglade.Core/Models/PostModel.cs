using Starglade.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starglade.Core.Models
{
    public class PostModel
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedOn { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; }

        public IEnumerable<TagModel> Tags { get; set; }

        public int TotalComments { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
