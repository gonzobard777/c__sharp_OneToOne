using Microsoft.EntityFrameworkCore;
using Domain.Variant_WithoutOwnPK;

namespace Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<BookDescription> BookDescriptions { get; set; }

    public AppDbContext(DbContextOptions opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(b =>
        {
            b.ToTable("Books");
            b.HasKey(x => x.Id).HasName("PK_Books_Id");
        });

        /*
         * Вариант 1.
         * у BookDescription есть свой PK - поле Id
         */
        // modelBuilder.Entity<BookDescription>(b =>
        // {
        //     b.ToTable("BookDescriptions");
        //     b.HasKey(x => x.Id).HasName("PK_BookDescriptions_Id");
        //     
        //     b
        //         .HasOne(bd => bd.Book)
        //         .WithOne(book => book.Description)
        //         .HasForeignKey<BookDescription>(bd => bd.BookId)
        //         .HasConstraintName("FK_BookDescriptions_BookId")
        //         .OnDelete(DeleteBehavior.Cascade);
        //     b.HasIndex(x => x.BookId, "UX_BookDescriptions_BookId").IsUnique(true);
        // });

        /*
         * Вариант 2.
         * у BookDescription нет своего независимого PK
         * Значение PK должно совпадать с PK Book.
         */
        modelBuilder.Entity<BookDescription>(b =>
        {
            b.ToTable("BookDescriptions");
            b.HasKey(x => x.BookId).HasName("PK_BookDescriptions_BookId");

            b
                .HasOne(bd => bd.Book)
                .WithOne(book => book.Description)
                .HasForeignKey<BookDescription>(bd => bd.BookId)
                .HasConstraintName("FK_BookDescriptions_BookId")
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}