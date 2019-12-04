using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Starglade.Core.Entities
{
    public class Tag : StargladeEntity
    {
        public int TagId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public IList<Post> Posts { get; set; }

    }
}
