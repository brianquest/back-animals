﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace animals.Models;

public partial class animalsContext : DbContext
{
    public animalsContext(DbContextOptions<animalsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Specie> Species { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK__Animal__A21A730761AC2CCC");

            entity.ToTable("Animal");

            entity.Property(e => e.AnimalId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AnimalLocomotion)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AnimalName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Specie).WithMany(p => p.Animals)
                .HasForeignKey(d => d.SpecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Animal__SpecieId__49C3F6B7");
        });

        modelBuilder.Entity<Specie>(entity =>
        {
            entity.HasKey(e => e.SpecieId).HasName("PK__Specie__6B45E1D0D838F5C8");

            entity.ToTable("Specie");

            entity.Property(e => e.SpecieId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Detail)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NameGroup)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}