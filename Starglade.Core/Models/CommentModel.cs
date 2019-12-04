using System;
using System.Collections.Generic;
using System.Text;

namespace Starglade.Core.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }


        public string CommentBy { get; set; }

        public string CommentByEmail { get; set; }

        public string Text { get; set; }
    }
}
