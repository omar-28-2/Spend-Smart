using System;
using System.ComponentModel.DataAnnotations;

public class DateRangeAttribute : ValidationAttribute
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;

    public DateRangeAttribute(int startYear)
    {
        _startDate = new DateTime(startYear, 1, 1);
        _endDate = DateTime.Now;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateValue)
        {
            if (dateValue < _startDate || dateValue > _endDate)
            {
                return new ValidationResult($"Date must be between {_startDate.Year} and {DateTime.Now.Year}.");
            }
        }
        return ValidationResult.Success;
    }
}
