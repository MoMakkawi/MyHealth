namespace MyHealth.Domain.Helpers;

public static class Role
{
    public const string Admin = nameof(Admin);
    public const string AdminId = "fa485500-3f43-4756-a45e-a9c4fa475789";
    public const string AdminConcurrencyStamp = "c23d091c-e477-4647-a864-e2d8914ed52f";

    public const string Patient = nameof(Patient);
    public const string PatientId = "09889c40-5e95-4522-99f7-0bfab29fbfea";
    public const string PatientConcurrencyStamp = "ff685fef-8349-425f-b9d5-a3bcc3eb4494";

    public const string Doctor = nameof(Doctor);
    public const string DoctorId = "64410517-6b14-4833-886a-0f949e3c5955";
    public const string DoctorConcurrencyStamp = "93464eb3-c99b-4c63-9070-8d3b3fd14733";

}
