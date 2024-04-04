using System;
using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Contact
{
    [Key]
    public int Id { get; set; } // Primary key, assuming one isn't defined in your Django model

    [Required]
    [MaxLength(50)]
    public string? System { get; set; }

    [Required]
    [MaxLength(255)]
    public string? Value { get; set; }

    [MaxLength(50)]
    public string? Use { get; set; } // Nullable to accommodate blank=True, null=True

    public override string ToString()
    {
        return $"{System}: {Value}";
    }
}