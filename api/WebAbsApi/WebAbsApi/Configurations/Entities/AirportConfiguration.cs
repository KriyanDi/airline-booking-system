﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAbsApi.Data;

namespace WebAbsApi.Configurations.Entities
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder
                .HasIndex(e => e.Name)
                .IsUnique(true);

            builder.HasData(
                new Airport
                {
                    Id = 1,
                    Name = "AAY"
                },
                new Airport
                {
                    Id = 2,
                    Name = "ABA"
                },
                new Airport
                {
                    Id = 3,
                    Name = "MAC"
                },
                new Airport
                {
                    Id = 4,
                    Name = "FSD"
                },
                new Airport
                {
                    Id = 5,
                    Name = "ZAG"
                });
        }
    }
}
