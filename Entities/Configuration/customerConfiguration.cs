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
    public class customerConfiguration : IEntityTypeConfiguration<customer>
    {
        public void Configure(EntityTypeBuilder<customer> builder)
        {
            builder.HasData
            (
            new customer
            {
                Id = new Guid("c2d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Vadim",
                Address = "Romodanovo, Saxar ",
                Country = "Russia",
                PhoneNumber = "89033258885"
            },
            new customer
            {
                Id = new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "Makson",
                Address = "Romodanovo, Saxar ",
                Country = "Russia",
                PhoneNumber = "890332347347"
            }
            ); ;
        }
    }
}
