
using Microsoft.EntityFrameworkCore;
using Model;


namespace Data
{
    public class PersonContext: DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options): base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Tasks> Task { get; set; }


    }
}
