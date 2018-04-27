using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GummiBear.Models;

namespace GummiBear.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20180427180206_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5");

            modelBuilder.Entity("GummiBear.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ReviewId");

                    b.HasKey("ItemId");

                    b.HasIndex("ReviewId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("GummiBear.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("content");

                    b.Property<string>("rating");

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GummiBear.Models.Item", b =>
                {
                    b.HasOne("GummiBear.Models.Review", "Review")
                        .WithMany("Items")
                        .HasForeignKey("ReviewId");
                });
        }
    }
}
