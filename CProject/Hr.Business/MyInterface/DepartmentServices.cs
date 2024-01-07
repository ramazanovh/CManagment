using CManagment.Entities;

namespace C.Interface;

public interface DepartmentServices
{
    void Create (string name, int employeeLimit, string companyName);
    Department? GetById (int id);
    Department? GetByName (string name);
    void Activate(string name);
    void Delete(string name);
    void GetDepartmentEmployee(string name);
    //-----------------------------------------
    bool IsDepartmentExist();
    void moveEmployee(int employeeId);

}
