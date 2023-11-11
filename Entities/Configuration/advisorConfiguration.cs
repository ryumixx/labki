using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class advisorConfiguration : IEntityTypeConfiguration<advisor>
    {
        public void Configure(EntityTypeBuilder<advisor> builder)
        {
            builder.HasData
            (
            new advisor
            {
                Id = new Guid("c9d4c053-49b6-430c-bc78-2d54a9991870"),
                Name = "Danila",
                Address = "Saransk, Michurini",
                PhoneNumber = "85884234355",
                Number = "1"
            },
            new advisor
            {
                Id = new Guid("3d490a70-94ce-4d45-9494-5248280c2ce3"),
                Name = "Arseniy",
                Address = "Saransk, Sovetskay",
                PhoneNumber = "82325235576",
                Number = "2"
            }
            );
        }
    }
}
