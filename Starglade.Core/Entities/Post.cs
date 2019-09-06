using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

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



    }
}
