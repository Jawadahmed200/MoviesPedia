using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPediaDataAccessLibrary.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
