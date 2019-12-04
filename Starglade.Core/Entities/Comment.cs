using System.ComponentModel.DataAnnotations;

namespace Starglade.Core.Entities
{
    public class Comment : StargladeEntity
    {
        public int CommentId { get; set; }

        [Required]
        [StringLength(100)]
        public string CommentBy { get; set; }

        public string CommentByEmail { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
