using CManagment.Interface;

namespace CManagment.Entities;

public class Department : IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public int EmployeeLimit { get; set; }
    public int CurrentEmployeeCount { get; set; }
    public Company CompanyId { get; set; }
    public bool IsActive { get; set; }
    private static int _id;
    public Department(string name, int employeeLimit, Company companyId)
    {
        Id = _id++;
        Name = name;
        EmployeeLimit = employeeLimit;
        CompanyId = companyId;
    }
}
