using System.ComponentModel.DataAnnotations;

namespace Domain.Variant_WithoutOwnPK;

public class BookDescription : BookDescriptionBase
{
    [Key]
    public int BookId { get; set; }
    public Book Book { get; set; }
}