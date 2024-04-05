using System;
using Newtonsoft.Json;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

public class PatientService : IPatientService
{
    private string _base_url = "http://fhir-server-fhir-service.common-tools:8080/fhir";
    static readonly HttpClient client = new HttpClient();

    public List<Patient> GetPatients()
    {
        var patients = new List<Patient>();
        // Simulating async operation
        try {
            var fhirClient = new FhirClient("http://fhir-server-fhir-service.common-tools:8080/fhir").WithLenientSerializer();
            try
            {
                var fhirpatients = fhirClient.Search<Hl7.Fhir.Model.Patient>();
                foreach (var entry in fhirpatients.Entry)
                {
                    var fhirpatient = (Hl7.Fhir.Model.Patient)entry.Resource;
                    Console.WriteLine($"Patient ID: {fhirpatient.Id}");
                    // Output other desired properties of the Patient
                    var name = "";
                    if (fhirpatient.Name.Any()) // Checks if there are any names present
                    {
                        var firstHumanName = fhirpatient.Name.First(); // Gets the first HumanName object
                        
                        var family = firstHumanName.Family; // Family name (no need to convert to list/array)
                        var given = firstHumanName.Given.FirstOrDefault(); // Safely get the first given name if it exists
                        
                        name = given != null ? $"{family}, {given}" : family;
                    }
                    patients.Add(
                        new Patient
                            {
                                FhirId = fhirpatient.Id,
                                Active = fhirpatient.Active ?? false,
                                Name = name,
                                Gender = Gender.Female,
                                // BirthDate = fhirpatient.BirthDate,
                                BirthDate = new DateTime(1980, 5, 21),
                                //MaritalStatus = fhirpatient.MaritalStatus,
                                MaritalStatus = "Married"
                            }
                    );
                }
            }
            catch (FhirOperationException fhirOpEx)
            {
                // Handle any FHIR operation errors
                Console.WriteLine($"Error: {fhirOpEx.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other errors
                Console.WriteLine($"General Error: {ex.Message}");
            }
            
        }
        catch (HttpRequestException e) {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return patients;
    }
    
    public Patient GetPatient(string id) {
        var patient = new Patient();
        // Simulating async operation
        try {
            var fhirClient = new FhirClient("http://fhir-server-fhir-service.common-tools:8080/fhir").WithLenientSerializer();
            try
            {
                var fhirpatient = fhirClient.Read<Hl7.Fhir.Model.Patient>($"Patient/{id}");
                var name = "";
                if (fhirpatient.Name.Any()) // Checks if there are any names present
                {
                    var firstHumanName = fhirpatient.Name.First(); // Gets the first HumanName object
                    
                    var family = firstHumanName.Family; // Family name (no need to convert to list/array)
                    var given = firstHumanName.Given.FirstOrDefault(); // Safely get the first given name if it exists
                    
                    name = given != null ? $"{family}, {given}" : family;
                }
                patient.FhirId = fhirpatient.Id;
                patient.Active = fhirpatient.Active ?? false;
                patient.Name = name;
                patient.Gender = Gender.Female;
                patient.BirthDate = DateTime.Parse(fhirpatient.BirthDate);
                //patient.BirthDate = new DateTime(1980, 5, 21);
                patient.MaritalStatus = fhirpatient.MaritalStatus?.Text ?? "Unknown";
                //patient.MaritalStatus = "Married";
            }
            catch (FhirOperationException fhirOpEx)
            {
                // Handle any FHIR operation errors
                Console.WriteLine($"Error: {fhirOpEx.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other errors
                Console.WriteLine($"General Error: {ex.Message}");
            }
            
        }
        catch (HttpRequestException e) {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return patient;
    }
}
