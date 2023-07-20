namespace Domain.Variant_WithoutOwnPK;

public class Book : BookBase
{
    public int DescriptionId => Id; // это поле можно и удалить
    public BookDescription? Description { get; set; }
}