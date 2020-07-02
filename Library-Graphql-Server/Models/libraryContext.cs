using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Server.Models
{
    public partial class libraryContext : DbContext
    {
        public libraryContext()
        {
        }

        public libraryContext(DbContextOptions<libraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Borrows> Borrows { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<ChiefEditor> ChiefEditor { get; set; }
        public virtual DbSet<Copy> Copy { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<InvEditor> InvEditor { get; set; }
        public virtual DbSet<JournalIssue> JournalIssue { get; set; }
        public virtual DbSet<JournalVolume> JournalVolume { get; set; }
        public virtual DbSet<Proceedings> Proceedings { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Reader> Reader { get; set; }
        public virtual DbSet<Reserves> Reserves { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Writes> Writes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:koc3.database.windows.net,1433;Initial Catalog=library;Persist Security Info=False;User ID=koc3;Password=Playstation3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.Authorid).HasColumnName("authorid");

                entity.Property(e => e.Aname)
                    .IsRequired()
                    .HasColumnName("aname")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("book");

                entity.HasIndex(e => e.Isbn)
                    .HasName("isbn")
                    .IsUnique();

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("isbn")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doc)
                    .WithMany()
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docid5");
            });

            modelBuilder.Entity<Borrows>(entity =>
            {
                entity.HasKey(e => e.Bornumber)
                    .HasName("PK__borrows__83621B9D74FCE830");

                entity.ToTable("borrows");

                entity.HasIndex(e => e.Bornumber)
                    .HasName("IX_borrows")
                    .IsUnique();

                entity.Property(e => e.Bornumber).HasColumnName("bornumber");

                entity.Property(e => e.Btime)
                    .HasColumnName("btime")
                    .HasColumnType("date");

                entity.Property(e => e.Copyid)
                    .IsRequired()
                    .HasColumnName("copyid")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Duedate)
                    .HasColumnName("duedate")
                    .HasColumnType("date");

                entity.Property(e => e.Fines).HasColumnName("fines");

                entity.Property(e => e.Libid).HasColumnName("libid");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Readerid).HasColumnName("readerid");

                entity.Property(e => e.Rtime)
                    .HasColumnName("rtime")
                    .HasColumnType("date");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Borrows)
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docid3");

                entity.HasOne(d => d.Lib)
                    .WithMany(p => p.Borrows)
                    .HasForeignKey(d => d.Libid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_libid3");

                entity.HasOne(d => d.Reader)
                    .WithMany(p => p.Borrows)
                    .HasForeignKey(d => d.Readerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_readid2");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.Libid)
                    .HasName("PK__branch__13D472409EEE0D14");

                entity.ToTable("branch");

                entity.Property(e => e.Libid).HasColumnName("libid");

                entity.Property(e => e.Llocation)
                    .IsRequired()
                    .HasColumnName("llocation")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChiefEditor>(entity =>
            {
                entity.HasKey(e => e.EditorId)
                    .HasName("PK__chief_ed__2301A4B1C9DA4905");

                entity.ToTable("chief_editor");

                entity.Property(e => e.EditorId).HasColumnName("editor_id");

                entity.Property(e => e.Ename)
                    .IsRequired()
                    .HasColumnName("ename")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Copy>(entity =>
            {
                entity.ToTable("copy");

                entity.Property(e => e.Copyid)
                    .HasColumnName("copyid")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Available)
                    .HasColumnName("available")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Libid).HasColumnName("libid");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Copy)
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docid1");

                entity.HasOne(d => d.Lib)
                    .WithMany(p => p.Copy)
                    .HasForeignKey(d => d.Libid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_libid1");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.Docid)
                    .HasName("PK__document__0638DBFA77839155");

                entity.ToTable("document");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Pdate)
                    .HasColumnName("pdate")
                    .HasColumnType("date");

                entity.Property(e => e.Publisherid).HasColumnName("publisherid");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.Publisherid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pubid");
            });

            modelBuilder.Entity<InvEditor>(entity =>
            {
                entity.HasKey(e => new { e.Docid, e.IssueNo, e.Iename })
                    .HasName("PK__inv_edit__F9D2AF9D7C418EC2");

                entity.ToTable("inv_editor");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.IssueNo).HasColumnName("issue_no");

                entity.Property(e => e.Iename)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.InvEditor)
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docid9");

                entity.HasOne(d => d.IssueNoNavigation)
                    .WithMany(p => p.InvEditor)
                    .HasForeignKey(d => d.IssueNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_issueid");
            });

            modelBuilder.Entity<JournalIssue>(entity =>
            {
                entity.HasKey(e => e.IssueNo)
                    .HasName("PK__journal___D6189B02E605B055");

                entity.ToTable("journal_issue");

                entity.Property(e => e.IssueNo)
                    .HasColumnName("issue_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasColumnName("SCOPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.JournalIssue)
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docid8");
            });

            modelBuilder.Entity<JournalVolume>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("journal_volume");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.EditorId).HasColumnName("editor_id");

                entity.Property(e => e.Jvolume).HasColumnName("jvolume");

                entity.HasOne(d => d.Doc)
                    .WithMany()
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docid7");

                entity.HasOne(d => d.Editor)
                    .WithMany()
                    .HasForeignKey(d => d.EditorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_editid");
            });

            modelBuilder.Entity<Proceedings>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("proceedings");

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasColumnType("date");

                entity.Property(e => e.Ceditor)
                    .IsRequired()
                    .HasColumnName("ceditor")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Clocation)
                    .IsRequired()
                    .HasColumnName("clocation")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.HasOne(d => d.Doc)
                    .WithMany()
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docid4");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("publisher");

                entity.Property(e => e.Publisherid).HasColumnName("publisherid");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pubname)
                    .IsRequired()
                    .HasColumnName("pubname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("zipcode")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reader>(entity =>
            {
                entity.ToTable("reader");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__reader__AB6E61646BC1D843")
                    .IsUnique();

                entity.Property(e => e.Readerid).HasColumnName("readerid");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rtype)
                    .IsRequired()
                    .HasColumnName("rtype")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("zipcode")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reserves>(entity =>
            {
                entity.HasKey(e => e.Resnumber)
                    .HasName("PK__reserves__CA13127A8163DD89");

                entity.ToTable("reserves");

                entity.Property(e => e.Resnumber).HasColumnName("resnumber");

                entity.Property(e => e.Copyid)
                    .IsRequired()
                    .HasColumnName("copyid")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Dtime)
                    .HasColumnName("DTIME")
                    .HasColumnType("date");

                entity.Property(e => e.Libid).HasColumnName("libid");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ptime)
                    .HasColumnName("ptime")
                    .HasColumnType("date");

                entity.Property(e => e.Readerid).HasColumnName("readerid");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Reserves)
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docid2");

                entity.HasOne(d => d.Lib)
                    .WithMany(p => p.Reserves)
                    .HasForeignKey(d => d.Libid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_libid2");

                entity.HasOne(d => d.Reader)
                    .WithMany(p => p.Reserves)
                    .HasForeignKey(d => d.Readerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_readid1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Readerid)
                    .HasName("PK__users__4A1642FBE7DB39F0");

                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Readerid)
                    .HasName("users_readerid_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("users_username_uindex")
                    .IsUnique();

                entity.Property(e => e.Readerid)
                    .HasColumnName("readerid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Reader)
                    .WithOne(p => p.Users)
                    .HasForeignKey<Users>(d => d.Readerid)
                    .HasConstraintName("users_reader_readerid_fk");
            });

            modelBuilder.Entity<Writes>(entity =>
            {
                entity.HasKey(e => new { e.Authorid, e.Docid })
                    .HasName("PK__writes__3E45B82E13ECC5EB");

                entity.ToTable("writes");

                entity.Property(e => e.Authorid).HasColumnName("authorid");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Writes)
                    .HasForeignKey(d => d.Authorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_authid");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Writes)
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docid6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
