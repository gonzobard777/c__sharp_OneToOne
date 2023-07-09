namespace Domain.Variant_Full01;

public class BookDescription : BookDescriptionBase
{
    public int Id { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }
}