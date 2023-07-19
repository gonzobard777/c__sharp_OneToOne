namespace Domain.Variant_WithoutOwnPK;

public class BookDescription : BookDescriptionBase
{
    public int BookId { get; set; }
    public Book Book { get; set; }
}