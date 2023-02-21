using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VPKS.DbEntities;

public partial class FoodDelieveryContext : DbContext
{
    public FoodDelieveryContext()
    {
    }

    public FoodDelieveryContext(DbContextOptions<FoodDelieveryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\S.Vlasova\\Documents\\Учеба\\FoodDelievery.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.Property(e => e.IdFood).HasColumnName("Id_Food");
            entity.Property(e => e.IdOrder).HasColumnName("Id_Order");
            entity.Property(e => e.Quantity).HasDefaultValueSql("1");

            entity.HasOne(d => d.IdFoodNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.IdFood)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.Adress).HasColumnType("NVARCHAR(1000)");
            entity.Property(e => e.PhoneNumber).HasColumnType("NVARCHAR(11)");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.Property(e => e.Name).HasColumnType("NVARCHAR(50)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.Adress).HasColumnType("NVARCHAR(100)");
            entity.Property(e => e.Date).HasColumnType("DATETIME");
            entity.Property(e => e.IdClient).HasColumnName("Id_Client");
            entity.Property(e => e.State).HasColumnType("NVARCHAR(100)");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasColumnType("NVARCHAR(50)");
            entity.Property(e => e.Login).HasColumnType("NVARCHAR(20)");
            entity.Property(e => e.Password).HasColumnType("NVARCHAR(20)");
            entity.Property(e => e.PermissionLevel).HasColumnType("NVARCHAR(50)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
