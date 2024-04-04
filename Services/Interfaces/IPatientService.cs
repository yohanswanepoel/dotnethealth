public interface IPatientService
{
   //Task<List<Patient>> GetPatientsAsync();

    List<Patient> GetPatients();

    Patient GetPatient(string id);
}
