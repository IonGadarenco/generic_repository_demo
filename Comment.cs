using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_repository_pattern_demo
{
    internal class Comment : Entity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
