using System.ComponentModel.DataAnnotations;

namespace EComm.Models;

public class Product : IValidatableObject
{
    public int ProductID { get; set; }

    [MinLength(3, ErrorMessage ="Name too short")]
    public string ProductName { get; set; } = "";

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var retVal = new List<ValidationResult>();

        if (ProductName.StartsWith("x"))
        {
            retVal.Add(new ValidationResult("Name can't start with x", ["name"]));
        }
        return retVal;
    }
}
