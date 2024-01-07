using CManagment.Entities;

namespace C.DataAccess.Contexts;

public static class CDbContext
{
    public static List<Employee> Employees { get; set; } = new List<Employee>();
    public static List<Department> Departments { get; set; } = new List<Department>();
    public static List<Company> Companies { get; set; } = new List<Company>();
}

    

