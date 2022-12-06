#pragma warning disable CS8618
namespace FormSubmission.Models;
using System.ComponentModel.DataAnnotations;


public class User
{
    [Required(ErrorMessage ="Name is required!")]
    [MinLength(2, ErrorMessage ="Name must be 2 characters")]
    public string Name{get;set;}
    [Required]
    [EmailAddress]
    public string Email{get;set;}

    [Required]
    [Date]
    [DataType(DataType.DateTime)]
    public DateTime Birthday{get;set;}
    [Required]
    [MinLength(8, ErrorMessage ="Password must be 8 characters")]
    public string Password{get;set;}
    [Required]
    [OddNum]
    public int OddNum{get;set;}

}

public class DateAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   
        if((DateTime)value == null)
        {
            return new ValidationResult("Please enter a Birthday!");
        }
        if((DateTime)value > DateTime.Now)
        {
            return new ValidationResult("Birthday must be before today");
        } 
        else 
        {
            return ValidationResult.Success;
        }  
    }
}

public class OddNumAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   
        if((int)value % 2 != 1)
        {
            return new ValidationResult("Must be an odd number!");
        } 
        else 
        {
            return ValidationResult.Success;
        }  
    }
}

