using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace testASP.Models;

public partial class PubContext : DbContext
{
    public PubContext()
    {
    }

    public PubContext(DbContextOptions<PubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer1> Beer1s { get; set; }

    public virtual DbSet<Brand1> Brand1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-FBNDVCI\\SQLEXPRESS; Database=Pub; Trusted_Connection=True; Encrypt=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer1>(entity =>
        {
            entity.HasKey(e => e.BeerId);

            entity.ToTable("Beer1");

            entity.Property(e => e.BeerId).ValueGeneratedNever();

            entity.HasOne(d => d.Brand).WithMany(p => p.Beer1s)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Beer1_Brand1");
        });

        modelBuilder.Entity<Brand1>(entity =>
        {
            entity.HasKey(e => e.BrandId);

            entity.ToTable("Brand1");

            entity.Property(e => e.BrandId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
