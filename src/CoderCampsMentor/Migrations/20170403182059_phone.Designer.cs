using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoderCampsMentor.Data;

namespace CoderCampsMentor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170403182059_phone")]
    partial class phone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoderCampsMentor.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Bio");

                    b.Property<string>("Birthday");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("Experience");

                    b.Property<string>("FirstName");

                    b.Property<string>("GithubLink");

                    b.Property<string>("LastName");

                    b.Property<string>("Location");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Occupation");

                    b.Property<string>("PasswordHash");

                    b.Property<int>("Phone");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Picture");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CoderCampsMentor.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CoderCampsMentor.Models.Comm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommType");

                    b.Property<DateTime>("DateSent");

                    b.Property<bool>("HasBeenViewed");

                    b.Property<int?>("InboxId");

                    b.Property<string>("Msg");

                    b.Property<string>("RecId");

                    b.Property<string>("ReceivingUserId");

                    b.Property<string>("SendingUserId");

                    b.Property<string>("Status");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("InboxId");

                    b.HasIndex("ReceivingUserId");

                    b.HasIndex("SendingUserId");

                    b.ToTable("Comms");
                });

            modelBuilder.Entity("CoderCampsMentor.Models.Inbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateSent");

                    b.Property<bool>("HasBeenViewed");

                    b.Property<string>("Msg");

                    b.Property<string>("RecId");

                    b.Property<string>("ReceivingUserId");

                    b.Property<string>("SendingUserId");

                    b.Property<string>("Subject");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ReceivingUserId");

                    b.HasIndex("SendingUserId");

                    b.ToTable("Inboxes");
                });

            modelBuilder.Entity("CoderCampsMentor.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("SubCategoryName");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("CoderCampsMentor.Models.UserCategory", b =>
                {
                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ApplicationUserId", "CategoryId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CategoryId");

                    b.ToTable("UserCategories");
                });

            modelBuilder.Entity("CoderCampsMentor.Models.UserSubCategory", b =>
                {
                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("SubCategoryId");

                    b.HasKey("ApplicationUserId", "SubCategoryId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("UserSubCategories");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CoderCampsMentor.Models.Comm", b =>
                {
                    b.HasOne("CoderCampsMentor.Models.Inbox")
                        .WithMany("Comms")
                        .HasForeignKey("InboxId");

                    b.HasOne("CoderCampsMentor.Models.ApplicationUser", "ReceivingUser")
                        .WithMany()
                        .HasForeignKey("ReceivingUserId");

                    b.HasOne("CoderCampsMentor.Models.ApplicationUser", "SendingUser")
                        .WithMany()
                        .HasForeignKey("SendingUserId");
                });

            modelBuilder.Entity("CoderCampsMentor.Models.Inbox", b =>
                {
                    b.HasOne("CoderCampsMentor.Models.ApplicationUser", "ReceivingUser")
                        .WithMany()
                        .HasForeignKey("ReceivingUserId");

                    b.HasOne("CoderCampsMentor.Models.ApplicationUser", "SendingUser")
                        .WithMany()
                        .HasForeignKey("SendingUserId");
                });

            modelBuilder.Entity("CoderCampsMentor.Models.SubCategory", b =>
                {
                    b.HasOne("CoderCampsMentor.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("CoderCampsMentor.Models.UserCategory", b =>
                {
                    b.HasOne("CoderCampsMentor.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserCategory")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoderCampsMentor.Models.Category", "Category")
                        .WithMany("UserCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoderCampsMentor.Models.UserSubCategory", b =>
                {
                    b.HasOne("CoderCampsMentor.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserSubCategories")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoderCampsMentor.Models.SubCategory", "SubCategory")
                        .WithMany("UserSubCategories")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CoderCampsMentor.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CoderCampsMentor.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoderCampsMentor.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
