using Microsoft.EntityFrameworkCore;




namespace BookStoreApp.Models.Entites
{
    public partial class BookStoreContext : DbContext
    {
       

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookType> BookTypes { get; set; }
        public virtual DbSet<BooksSpecialTag> BooksSpecialTags { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersBook> OrdersBooks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SpecialTag> SpecialTags { get; set; }
        public virtual DbSet<User> Users { get; set; }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ImagePath).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PagesNo).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.Price).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.BookType)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.BookTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_BookTypes");
            });

            modelBuilder.Entity<BookType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BooksSpecialTag>(entity =>
            {
                entity.HasKey(e => new { e.SpecialTagId, e.BookId })
                    .HasName("PK_BookSpecialTag");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BooksSpecialTags)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BooksSpecialTags_Books");

                entity.HasOne(d => d.SpecialTag)
                    .WithMany(p => p.BooksSpecialTags)
                    .HasForeignKey(d => d.SpecialTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksSpecialTags_SpecialTags");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.CommentTitle)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Books");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Feedback_Users");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrdersBook>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.OrderId });

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrdersBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersBooks_Books");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersBooks)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrdersBooks_Orders");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SpecialTag>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UK_UserName")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.IsActiv)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
