using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPediaDataAccessLibrary.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool Recommend { get; set; }
        public int MovieId { get; set; }
        public Movie Movie{ get; set; }
    }
}
