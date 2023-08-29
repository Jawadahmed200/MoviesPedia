using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPediaDataAccessLibrary.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Fortune { get; set; }
        public DateTime DateOfBirth { get; set; }
        public HashSet<MovieActor> MoviesActors { get; set; } = new HashSet<MovieActor>();
    }
}
