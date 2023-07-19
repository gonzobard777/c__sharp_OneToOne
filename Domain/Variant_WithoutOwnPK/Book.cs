namespace Domain.Variant_WithoutOwnPK;

public class Book : BookBase
{
    public int DescriptionId => Id; 
    public BookDescription? Description { get; set; }
}