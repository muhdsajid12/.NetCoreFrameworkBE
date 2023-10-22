using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public partial class YamurDbContext : DbContext
{
    public YamurDbContext()
    {
    }

    public YamurDbContext(DbContextOptions<YamurDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DtCommand> DtCommands { get; set; }

    public virtual DbSet<DtCommandGroup> DtCommandGroups { get; set; }

    public virtual DbSet<DtMessage> DtMessages { get; set; }

    public virtual DbSet<DtUser> DtUsers { get; set; }

    public virtual DbSet<DtUserContact> DtUserContacts { get; set; }

    /// <summary>
    /// PMC command to override db (update): Scaffold-DbContext 'Data Source=LAPTOP-2UUI3IBH\SQLEXPRESS;Initial Catalog=YamurDB;User Id=sa;Password=P@ssw0rd;TrustServerCertificate=True' Microsoft.EntityFrameworkCore.SqlServer -f
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-2UUI3IBH\\SQLEXPRESS;Initial Catalog=YamurDB;User Id=sa;Password=P@ssw0rd;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DtCommand>(entity =>
        {
            entity.HasKey(e => e.CommandId);

            entity.ToTable("DT_Command");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DtCommandGroup>(entity =>
        {
            entity.HasKey(e => e.CommandGroupId);

            entity.ToTable("DT_CommandGroup");

            entity.Property(e => e.CreateadDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DtMessage>(entity =>
        {
            entity.HasKey(e => e.CommandId);

            entity.ToTable("DT_Message");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IntervalTime).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DtUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("DT_User");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Deleted)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DtUserContact>(entity =>
        {
            entity.HasKey(e => e.UserContactId);

            entity.ToTable("DT_UserContact");

            entity.Property(e => e.ContactNo).HasMaxLength(250);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
