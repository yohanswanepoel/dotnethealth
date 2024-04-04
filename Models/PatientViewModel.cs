using System;
using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PatientViewModel
{
    public List<Patient>? Patients { get; set; }
    public Patient? SelectedPatient { get; set; }

    public PatientViewModel()
    {
        this.Patients = new List<Patient>();
        this.SelectedPatient = null;
    }
}