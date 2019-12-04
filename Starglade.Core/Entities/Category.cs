using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Starglade.Core.Entities
{
    public class Category : StargladeEntity
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public IList<PostCategory> Posts { get; set; }
    }
}
