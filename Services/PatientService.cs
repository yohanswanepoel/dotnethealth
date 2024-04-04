public class PatientService : IPatientService
{
    public List<Patient> GetPatients()
    {
        // Simulating async operation
        string _address = "http://api.worldbank.org/countries?format=json";

        // Returning mock data
        var patients = new List<Patient>
        {
            new Patient
            {
                FhirId = "1",
                Active = true,
                Name = "John Doe",
                Gender = Gender.Male,
                BirthDate = new DateTime(1980, 5, 21),
                MaritalStatus = "Married",
                MultipleBirth = false
            },
            new Patient
            {
                FhirId = "2",
                Active = true,
                Name = "Jane Smith",
                Gender = Gender.Female,
                BirthDate = new DateTime(1992, 8, 15),
                MaritalStatus = "Single",
                MultipleBirth = true
            }
            // Add more patients as needed
        };

        return patients;
    }
    
    public Patient GetPatient(string id){
        var patient = new Patient
            {
                FhirId = "1",
                Active = true,
                Name = "John Doe",
                Gender = Gender.Male,
                BirthDate = new DateTime(1980, 5, 21),
                MaritalStatus = "Married",
                MultipleBirth = false
            };
        return patient;
    }
}
