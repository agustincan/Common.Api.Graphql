using Common.Api.Graphql.Persistence.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Common.Api.Graphql.Persistence
{
    internal class CorrectiveActionConfiguration
    {
        private IEnumerable<CorrectiveAction> GetActions()
        {
            var actions = new string[] { "Vallas", "Reja Especial", "Reposición", "Sin faltante en la red pluvial",
                "Obra", };
            var result = new List<CorrectiveAction>();
            for (int i = 1; i < actions.Length; i++)
            {
                result.Add(new CorrectiveAction() { Id = i, Description = actions[i] });
            }
            return result;
        }
        public CorrectiveActionConfiguration(EntityTypeBuilder<CorrectiveAction> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasIndex(x => x.Description).IsUnique();
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(200);

            entityBuilder.HasData(GetActions());
        }
    }
}
