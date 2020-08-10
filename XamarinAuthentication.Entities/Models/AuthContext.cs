namespace XamarinAuthentication.Entities.Models {
      using System;
      using System.Data.Entity;
      using System.ComponentModel.DataAnnotations.Schema;
      using System.Linq;

      public partial class AuthContext : DbContext {
            public AuthContext()
                : base("name=AuthContext") {
            }

            public virtual DbSet<Note> Notes { get; set; }
            public virtual DbSet<User> Users { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder) {
                  modelBuilder.Entity<Note>()
                      .Property(e => e.Title)
                      .IsUnicode(false);

                  modelBuilder.Entity<Note>()
                      .Property(e => e.Description)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.FullName)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.Email)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.Password)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .HasMany(e => e.Notes)
                      .WithRequired(e => e.User)
                      .WillCascadeOnDelete(false);
            }

            protected override void Dispose(bool disposing) {
                  base.Dispose(disposing);
            }
      }
}
