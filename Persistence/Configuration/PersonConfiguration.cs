using Common.Api.Graphql.Persistence.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Common.Api.Graphql.Persistence
{
    internal class PersonConfiguration
    {
        private IEnumerable<Person> GetPersons()
        {
            var result = new List<Person>();
            
            for (int i = 1; i < 5; i++)
            {
                result.Add(new Person() { Id = i, Name = $"Person {i}" });
            }
            return result;
        }
        public PersonConfiguration(EntityTypeBuilder<Person> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasIndex(x => x.Name);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            // relations
            entityBuilder.HasMany(x => x.Adresses)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);

            entityBuilder.HasData(GetPersons());
        }
    }
}
