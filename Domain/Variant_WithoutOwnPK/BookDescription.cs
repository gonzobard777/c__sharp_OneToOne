namespace Domain.Variant_WithoutOwnPK;

public class BookDescription : BookDescriptionBase
{
    public int BookId { get; set; } // PK и FK таблицы BookDescription 
    public Book? Book { get; set; }
}