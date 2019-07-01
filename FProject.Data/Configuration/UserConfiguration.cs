using FProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Configuration
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void ConfigureSpecific(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
        }
    }
}
