namespace C.Interface;

public interface EmployeeServices
{
    void Create(string name, string surname, string email, string password, decimal Salary, string departmentName);
    void Delete(int Id);
    void ChangeDepartment(int employeeId, string newDepartmentName);
}
