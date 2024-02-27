using System;
using System.Collections.Generic;
using Data.Configuration;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TestTaskWebAPI;

public partial class MtsbaseContext : DbContext
{
    private readonly SqlliteOptions _dbOptions;
    public MtsbaseContext()
    {
    }

    public MtsbaseContext(IOptions<SqlliteOptions> options)
        : base()
    {
        _dbOptions = options.Value;
    }

    public virtual DbSet<LocationEntity> Locations { get; set; }

    public virtual DbSet<NodeEntity> Nodes { get; set; }

    public virtual DbSet<PassportEntity> Passports { get; set; }

    public virtual DbSet<PassportParamEntity> PassportParams { get; set; }

    public virtual DbSet<Data.Entities.ThreadEntity> Threads { get; set; }

    public virtual DbSet<UnitEntity> Units { get; set; }

    public virtual DbSet<UnitTypeEntity> UnitTypes { get; set; }

    public virtual DbSet<UnitsRelationEntity> UnitsRelations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        optionsBuilder.UseSqlite(_dbOptions.ConnectionString);
    }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocationEntity>(entity =>
        {
            entity.ToTable("locations");

            entity.HasIndex(e => e.NodeId, "locations_node_id_index");

            entity.HasIndex(e => e.TmBeg, "locations_tm_beg_index");

            entity.HasIndex(e => e.UnitId, "locations_unit_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NodeId).HasColumnName("node_id");
            entity.Property(e => e.TmBeg).HasColumnName("tm_beg");
            entity.Property(e => e.TmEnd).HasColumnName("tm_end");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");

            entity.HasOne(d => d.Node).WithMany(p => p.Locations).HasForeignKey(d => d.NodeId);

            entity.HasOne(d => d.Unit).WithMany(p => p.Locations).HasForeignKey(d => d.UnitId);
        });

        modelBuilder.Entity<NodeEntity>(entity =>
        {
            entity.ToTable("nodes");

            entity.HasIndex(e => e.NodeCode, "IX_nodes_node_code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BeginDate).HasColumnName("begin_date");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.NodeCode).HasColumnName("node_code");
            entity.Property(e => e.ThreadId).HasColumnName("thread_id");

            entity.HasOne(d => d.Thread).WithMany(p => p.Nodes)
                .HasForeignKey(d => d.ThreadId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PassportEntity>(entity =>
        {
            entity.ToTable("passport");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ParamDate).HasColumnName("param_date");
            entity.Property(e => e.ParamId).HasColumnName("param_id");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.ValueD).HasColumnName("value_d");
            entity.Property(e => e.ValueJ).HasColumnName("value_j");
            entity.Property(e => e.ValueN).HasColumnName("value_n");
            entity.Property(e => e.ValueS).HasColumnName("value_s");
        });

        modelBuilder.Entity<PassportParamEntity>(entity =>
        {
            entity.ToTable("passport_param");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ParamName).HasColumnName("param_name");
            entity.Property(e => e.UnitTypeId).HasColumnName("unit_type_id");

            entity.HasOne(d => d.UnitType).WithMany(p => p.PassportParams)
                .HasForeignKey(d => d.UnitTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Data.Entities.ThreadEntity>(entity =>
        {
            entity.ToTable("threads");

            entity.HasIndex(e => e.ThreadName, "IX_threads_thread_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ThreadName).HasColumnName("thread_name");
            entity.Property(e => e.ThreadNum).HasColumnName("thread_num");
        });

        modelBuilder.Entity<UnitEntity>(entity =>
        {
            entity.ToTable("units");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateReg).HasColumnName("date_reg");
            entity.Property(e => e.IngotId).HasColumnName("ingot_id");
            entity.Property(e => e.UnitTypeId).HasColumnName("unit_type_id");

            entity.HasOne(d => d.UnitType).WithMany(p => p.Units)
                .HasForeignKey(d => d.UnitTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<UnitTypeEntity>(entity =>
        {
            entity.ToTable("unit_types");

            entity.HasIndex(e => e.TypeName, "IX_unit_types_type_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeName).HasColumnName("type_name");
        });

        modelBuilder.Entity<UnitsRelationEntity>(entity =>
        {
            entity.ToTable("units_relations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateReg).HasColumnName("date_reg");
            entity.Property(e => e.UnitIdChild).HasColumnName("unit_id_child");
            entity.Property(e => e.UnitIdParent).HasColumnName("unit_id_parent");

            entity.HasOne(d => d.UnitIdChildNavigation).WithMany(p => p.UnitsRelationUnitIdChildNavigations).HasForeignKey(d => d.UnitIdChild);

            entity.HasOne(d => d.UnitIdParentNavigation).WithMany(p => p.UnitsRelationUnitIdParentNavigations)
                .HasForeignKey(d => d.UnitIdParent)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties()
                                    .Where(_ => _.PropertyType == typeof(DateTime) || _.PropertyType == typeof(DateTime?));

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name).Property(property.Name)
                        .HasConversion<DateTime>();
                }
            }
        }

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
