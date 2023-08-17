using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RepositoryDesignPattren.Models;

public partial class SampdbContext : DbContext
{
    public SampdbContext()
    {
    }

    public SampdbContext(DbContextOptions<SampdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; } 

    public virtual DbSet<CustomerProfile> CustomerProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=sampdb;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true; MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("id");
            
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
          
        });

        modelBuilder.Entity<CustomerProfile>(entity =>
        {
            entity.ToTable("Customer_Profile");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sex");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerProfiles)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customer___Custo__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
