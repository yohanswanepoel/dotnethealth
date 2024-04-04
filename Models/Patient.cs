using System;
using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum Gender
{
    Male,
    Female,
    Other,
    Unknown
}

//[Table("Patients")]
public class Patient
{
    [Key]
    //[Required]
    [MaxLength(100)]
    public string? FhirId { get; set; }

    public bool Active { get; set; } = true;

    [MaxLength(100)]
    public string? Name { get; set; } // Assuming a simple string for the example; adjust according to your needs.

    // Assuming 'Contact' is another model class you have defined
    public ICollection<Contact> Telecoms { get; set; } = new List<Contact>();
    public ICollection<Contact> Addresses { get; set; } = new List<Contact>();

    public Gender Gender { get; set; }

    [Column(TypeName = "date")]
    public DateTime? BirthDate { get; set; } // Nullable for optional

    [MaxLength(20)]
    public string? MaritalStatus { get; set; } // Adjust according to your needs

    public bool MultipleBirth { get; set; } = false;

    // Additional methods or properties here as needed
}
