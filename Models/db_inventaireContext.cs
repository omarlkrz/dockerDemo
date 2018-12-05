using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi10.Models
{
    public partial class db_inventaireContext : DbContext
    {
        public db_inventaireContext()
        {
        }

        public db_inventaireContext(DbContextOptions<db_inventaireContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Emplacement> Emplacement { get; set; }
        public virtual DbSet<Equipement> Equipement { get; set; }
        public virtual DbSet<HistoEquip> HistoEquip { get; set; }
        public virtual DbSet<HistoMouv> HistoMouv { get; set; }
        public virtual DbSet<Local> Local { get; set; }
        public virtual DbSet<Modele> Modele { get; set; }
        public virtual DbSet<Mouvement> Mouvement { get; set; }
        public virtual DbSet<Poste> Poste { get; set; }
        public virtual DbSet<TempInvent> TempInvent { get; set; }
        public virtual DbSet<TypeDevice> TypeDevice { get; set; }
        public virtual DbSet<TypeLocal> TypeLocal { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=db_inventaire;User ID=sa;Password=Sa2018");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emplacement>(entity =>
            {
                entity.HasKey(e => e.CodeEmplacement);

                entity.ToTable("emplacement");

                entity.Property(e => e.CodeEmplacement).HasColumnName("codeEmplacement");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasColumnName("adresse")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Equipement>(entity =>
            {
                entity.HasKey(e => e.Sn);

                entity.ToTable("equipement");

                entity.Property(e => e.Sn)
                    .HasColumnName("SN")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeModel)
                    .IsRequired()
                    .HasColumnName("codeModel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreation)
                    .HasColumnName("dateCreation")
                    .HasColumnType("date");

                entity.Property(e => e.Inventory)
                    .HasColumnName("inventory")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NomPoste)
                    .IsRequired()
                    .HasColumnName("nomPoste")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Propriete)
                    .HasColumnName("propriete")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeModelNavigation)
                    .WithMany(p => p.Equipement)
                    .HasForeignKey(d => d.CodeModel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_equipement_modele");

                entity.HasOne(d => d.NomPosteNavigation)
                    .WithMany(p => p.Equipement)
                    .HasForeignKey(d => d.NomPoste)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_equipement_poste");
            });

            modelBuilder.Entity<HistoEquip>(entity =>
            {
                entity.HasKey(e => e.Sn);

                entity.ToTable("histoEquip");

                entity.Property(e => e.Sn)
                    .HasColumnName("SN")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeModel)
                    .IsRequired()
                    .HasColumnName("codeModel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreation)
                    .HasColumnName("dateCreation")
                    .HasColumnType("date");

                entity.Property(e => e.DateH)
                    .HasColumnName("dateH")
                    .HasColumnType("date");

                entity.Property(e => e.Inventory)
                    .HasColumnName("inventory")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeModelNavigation)
                    .WithMany(p => p.HistoEquip)
                    .HasForeignKey(d => d.CodeModel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_histoEquip_modele");
            });

            modelBuilder.Entity<HistoMouv>(entity =>
            {
                entity.HasKey(e => e.IdMouvement);

                entity.ToTable("histoMouv");

                entity.Property(e => e.IdMouvement)
                    .HasColumnName("idMouvement")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("idUser")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PositionFin)
                    .HasColumnName("positionFin")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionIni)
                    .HasColumnName("positionIni")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sn)
                    .IsRequired()
                    .HasColumnName("SN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeMouv).HasColumnName("typeMouv");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.HistoMouv)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_histoMouv_user");

                entity.HasOne(d => d.SnNavigation)
                    .WithMany(p => p.HistoMouv)
                    .HasForeignKey(d => d.Sn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_histoMouv_histEquip");
            });

            modelBuilder.Entity<Local>(entity =>
            {
                entity.HasKey(e => e.IdLocal);

                entity.ToTable("local");

                entity.Property(e => e.IdLocal).HasColumnName("idLocal");

                entity.Property(e => e.CodeEmplacement).HasColumnName("codeEmplacement");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdTypeLocal).HasColumnName("idTypeLocal");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Responsable)
                    .IsRequired()
                    .HasColumnName("responsable")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeEmplacementNavigation)
                    .WithMany(p => p.Local)
                    .HasForeignKey(d => d.CodeEmplacement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_local_emplacement");

                entity.HasOne(d => d.IdTypeLocalNavigation)
                    .WithMany(p => p.Local)
                    .HasForeignKey(d => d.IdTypeLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_local_typeLocal");
            });

            modelBuilder.Entity<Modele>(entity =>
            {
                entity.HasKey(e => e.CodeModel);

                entity.ToTable("modele");

                entity.Property(e => e.CodeModel)
                    .HasColumnName("codeModel")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeVendor).HasColumnName("codeVendor");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdTypeDev).HasColumnName("idTypeDev");

                entity.Property(e => e.ModelDetectable).HasColumnName("modelDetectable");

                entity.Property(e => e.Propriete)
                    .HasColumnName("propriete")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SnDetectable).HasColumnName("snDetectable");

                entity.HasOne(d => d.IdTypeDevNavigation)
                    .WithMany(p => p.Modele)
                    .HasForeignKey(d => d.IdTypeDev)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_modele_typeDevice");

                entity.HasOne(d => d.IdTypeDev1)
                    .WithMany(p => p.Modele)
                    .HasForeignKey(d => d.IdTypeDev)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_modele_vendor");
            });

            modelBuilder.Entity<Mouvement>(entity =>
            {
                entity.HasKey(e => e.IdMouvement);

                entity.ToTable("mouvement");

                entity.Property(e => e.IdMouvement).HasColumnName("idMouvement");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("idUser")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PositionFin)
                    .IsRequired()
                    .HasColumnName("positionFin")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionIni)
                    .IsRequired()
                    .HasColumnName("positionIni")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sn)
                    .IsRequired()
                    .HasColumnName("SN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Mouvement)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mouvement_user");

                entity.HasOne(d => d.SnNavigation)
                    .WithMany(p => p.Mouvement)
                    .HasForeignKey(d => d.Sn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mouvement_equipement");
            });

            modelBuilder.Entity<Poste>(entity =>
            {
                entity.HasKey(e => e.Nom);

                entity.ToTable("poste");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdLocal).HasColumnName("idLocal");

                entity.Property(e => e.IpAdresse)
                    .HasColumnName("ipAdresse")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IsBureau).HasColumnName("isBureau");

                entity.Property(e => e.NomUtilisateur)
                    .HasColumnName("nomUtilisateur")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.Poste)
                    .HasForeignKey(d => d.IdLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_poste_local");
            });

            modelBuilder.Entity<TempInvent>(entity =>
            {
                entity.ToTable("tempInvent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ModelDetected)
                    .IsRequired()
                    .HasColumnName("modelDetected")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModelName)
                    .HasColumnName("modelName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomPost)
                    .HasColumnName("nomPost")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sn)
                    .HasColumnName("SN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VendorDetected)
                    .IsRequired()
                    .HasColumnName("vendorDetected")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .HasColumnName("vendorName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeDevice>(entity =>
            {
                entity.HasKey(e => e.IdTypeDev);

                entity.ToTable("typeDevice");

                entity.Property(e => e.IdTypeDev).HasColumnName("idTypeDev");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TypeLocal>(entity =>
            {
                entity.HasKey(e => e.IdTypeLocal);

                entity.ToTable("typeLocal");

                entity.Property(e => e.IdTypeLocal).HasColumnName("idTypeLocal");

                entity.Property(e => e.NomTypeLocal)
                    .IsRequired()
                    .HasColumnName("nomTypeLocal")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("user");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Actif).HasColumnName("actif");

                entity.Property(e => e.Courriel)
                    .IsRequired()
                    .HasColumnName("courriel")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IdUserType).HasColumnName("idUserType");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserTypeNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdUserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_userType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.IdUserType);

                entity.ToTable("userType");

                entity.Property(e => e.IdUserType).HasColumnName("idUserType");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.IdVendor);

                entity.ToTable("vendor");

                entity.Property(e => e.IdVendor).HasColumnName("idVendor");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
