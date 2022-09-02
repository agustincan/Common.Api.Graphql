using Common.Api.Graphql.Persistence.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Common.Api.Graphql.Persistence
{
    internal class AddressConfiguration
    {
        private IEnumerable<Address> GetAddresses()
        {
            var result = new List<Address>();
            
            for (int i = 1; i < 5; i++)
            {
                result.Add(new Address() { Id = i, Name = $"Address {i}" });
            }
            return result;
        }
        public AddressConfiguration(EntityTypeBuilder<Address> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasIndex(x => x.Name);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            entityBuilder.Property(x => x.ZipCode).HasMaxLength(20);
            //relations
            entityBuilder.HasOne(e => e.Person)
                .WithMany(e => e.Adresses)
                .HasForeignKey(e => e.PersonId);


            entityBuilder.HasData(GetAddresses());
        }
    }
}
