using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StajBasvuru2.Models
{
    public partial class INTERNContext : DbContext
    {
        public INTERNContext()
        {
        }

        public INTERNContext(DbContextOptions<INTERNContext> options)
            : base(options)
        {
        }
        public DbSet<BasvuruKisisel> BasvuruKisisels { get; set; } = null!;

        
        //public virtual DbSet<BasvuruKisisel> BasvuruKisisels { get; set; } = null!;
        public virtual DbSet<BasvuruOkul> BasvuruOkuls { get; set; } = null!;
        public virtual DbSet<BasvuruReferans> BasvuruReferans { get; set; } = null!;
        public virtual DbSet<BasvuruStajbilgi> BasvuruStajbilgis { get; set; } = null!;
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=dindapptr126-31.ptg.local;Database=INTERN;User Id=usr_intern;Password=%i1V@2E97Q49;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<BasvuruKisisel>(entity =>
            {
                entity.HasKey(e => e.Tcno);

                entity.ToTable("basvuru_kisisel");

                entity.Property(e => e.Tcno)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("tcno");

                entity.Property(e => e.Adsoyad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adsoyad");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Telno)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("telno");
            });

            modelBuilder.Entity<BasvuruOkul>(entity =>
            {
                entity.HasKey(e => e.Tcno);

                entity.ToTable("basvuru_okul");

                entity.Property(e => e.Tcno)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("tcno");

                entity.Property(e => e.Bolum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bolum");

                entity.Property(e => e.Notsistem)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("notsistem");

                entity.Property(e => e.Okulad)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("okulad");

                entity.Property(e => e.Okultur)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("okultur");

                entity.Property(e => e.Ortalama)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("ortalama");

                entity.Property(e => e.Sınıf)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TcnoNavigation)
                    .WithOne(p => p.BasvuruOkul)
                    .HasForeignKey<BasvuruOkul>(d => d.Tcno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_basvuru_okul_basvuru_kisisel");
            });

            modelBuilder.Entity<BasvuruReferans>(entity =>
            {
                entity.HasKey(e => e.Tcno);

                entity.ToTable("basvuru_referans");

                entity.Property(e => e.Tcno)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("tcno");

                entity.Property(e => e.Calisanakraba).HasColumnName("calisanakraba");

                entity.Property(e => e.Ekstrabilgi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ekstrabilgi");

                entity.Property(e => e.Referansadsoyad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("referansadsoyad");

                entity.Property(e => e.Referansbolum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("referansbolum");

                entity.Property(e => e.Referansemail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("referansemail");

                entity.Property(e => e.Referanstelefon)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("referanstelefon");

                entity.Property(e => e.Yakinlikderecesi)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("yakinlikderecesi");

                entity.HasOne(d => d.TcnoNavigation)
                    .WithOne(p => p.BasvuruReferan)
                    .HasForeignKey<BasvuruReferans>(d => d.Tcno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_basvuru_referans_basvuru_kisisel");
            });

            modelBuilder.Entity<BasvuruStajbilgi>(entity =>
            {
                entity.HasKey(e => e.Tcno);

                entity.ToTable("basvuru_stajbilgi");

                entity.Property(e => e.Tcno)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("tcno");

                entity.Property(e => e.Stajdonem)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("stajdonem");

                entity.Property(e => e.Stajsure).HasColumnName("stajsure");

                entity.Property(e => e.Stajsuretipi)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("stajsuretipi");

                entity.Property(e => e.Stajtur)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("stajtur");

                entity.Property(e => e.Stajyaptimi).HasColumnName("stajyaptimi");

                entity.Property(e => e.Zorunlustaj).HasColumnName("zorunlustaj");

                entity.HasOne(d => d.TcnoNavigation)
                    .WithOne(p => p.BasvuruStajbilgi)
                    .HasForeignKey<BasvuruStajbilgi>(d => d.Tcno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_basvuru_stajbilgi_basvuru_kisisel");
            });
        }

            

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
