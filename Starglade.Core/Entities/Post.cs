using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starglade.Core.Entities
{
    public class Post:StargladeEntity
    {
        public int PostId { get; set; }

        [StringLength(250)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishedOn { get; set; }

        public IList<Comment> Comments { get; set; }

        public IList<PostCategory> Categories { get; set; }

        public IList<PostTag> Tags { get; set; }

        [NotMapped]
        public int TotalComments { get; set; }

    }
}
