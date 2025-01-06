﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using clientprefs.Database;

#nullable disable

namespace clientprefs.Migrations.SqliteMigrations
{
    [DbContext(typeof(SqliteContext))]
    partial class SqliteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("clientprefs.Database.Table.Cookie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("cookie", (string)null);
                });

            modelBuilder.Entity("clientprefs.Database.Table.UserCookie", b =>
                {
                    b.Property<ulong>("accountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("account_id");

                    b.Property<int>("cookieId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("cookie_id");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("accountId");

                    b.HasIndex("cookieId");

                    b.ToTable("user_cookie", (string)null);
                });

            modelBuilder.Entity("clientprefs.Database.Table.UserCookie", b =>
                {
                    b.HasOne("clientprefs.Database.Table.Cookie", "Cookie")
                        .WithMany()
                        .HasForeignKey("cookieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cookie");
                });
#pragma warning restore 612, 618
        }
    }
}