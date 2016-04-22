using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Breeze.Models;

namespace breeze.Migrations
{
    [DbContext(typeof(BreezeContext))]
    [Migration("20160422225448_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Breeze.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentDescription");

                    b.Property<int>("GameId");

                    b.Property<string>("UserName");

                    b.HasKey("CommentId");

                    b.HasAnnotation("Relational:TableName", "Comments");
                });

            modelBuilder.Entity("Breeze.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("GameId");

                    b.HasAnnotation("Relational:TableName", "Games");
                });

            modelBuilder.Entity("Breeze.Models.Comment", b =>
                {
                    b.HasOne("Breeze.Models.Game")
                        .WithMany()
                        .HasForeignKey("GameId");
                });
        }
    }
}
