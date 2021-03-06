// <auto-generated />
using FastTypingApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FastTypingApi.Migrations
{
    [DbContext(typeof(TextDbContext))]
    [Migration("20220121132433_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("FastTypingApi.Entities.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Mistakes")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("TextId")
                        .HasColumnType("integer");

                    b.Property<int>("Time")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TextId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("FastTypingApi.Entities.Text", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("language")
                        .HasColumnType("text");

                    b.Property<string>("lenght")
                        .HasColumnType("text");

                    b.Property<string>("text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("FastTypingApi.Entities.Score", b =>
                {
                    b.HasOne("FastTypingApi.Entities.Text", "Text")
                        .WithMany("Score")
                        .HasForeignKey("TextId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Text");
                });

            modelBuilder.Entity("FastTypingApi.Entities.Text", b =>
                {
                    b.Navigation("Score");
                });
#pragma warning restore 612, 618
        }
    }
}
