using Common.Api.Graphql.Persistence.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Common.Api.Graphql.Persistence
{
    internal class PreventiveActionConfiguration
    {
        private IEnumerable<PreventiveAction> GetActions()
        {
            var actions = new string[] { 
                "Vallas",
                "Reporte",
                "Tapa Cemento",
                "Aviso",
                "Sin Peligro",
                "Peligroso",
                "Sin Faltante",
                "Tacos",
                "Limpieza",
                "No Existe Sumidero",
                "Reposición"
            };
            var result = new List<PreventiveAction>();
            for (int i = 1; i < actions.Length; i++)
            {
                result.Add(new PreventiveAction() { Id = i, Description = actions[i] });
            }
            return result;
        }
        public PreventiveActionConfiguration(EntityTypeBuilder<PreventiveAction> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasIndex(x => x.Description).IsUnique();
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(200);

            entityBuilder.HasData(GetActions());
        }
    }
}
