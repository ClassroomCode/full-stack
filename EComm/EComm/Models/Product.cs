using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComm.Models;

public class Product : IValidatableObject
{
    public int ProductID { get; set; }

    [MinLength(3, ErrorMessage ="Name too short")]
    public string ProductName { get; set; } = "";

    [Required]
    [Column(TypeName ="money")]
    public Decimal? UnitPrice { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var retVal = new List<ValidationResult>();

        if (ProductName.StartsWith("x"))
        {
            retVal.Add(new ValidationResult("Name can't start with x", ["name"]));
        }
        if (UnitPrice <= (Decimal)1.0)
        {
            retVal.Add(new ValidationResult("Price must be greater than 1", ["unitPrice"]));
        }
        return retVal;
    }
}
