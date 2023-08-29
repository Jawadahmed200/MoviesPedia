using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPediaDataAccessLibrary.Entities.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150);
            //var scienceFiction = new Genre() { Id = 5, Name = "Science Fiction" };
            //var animation = new Genre() { Id = 6, Name = "Animation" };

            //builder.HasData(scienceFiction, animation);
            builder.HasIndex(x=>x.Name).IsUnique();
        }
    }
}
