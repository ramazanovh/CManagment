using CManagment.Entities;

namespace C.Interface;

public interface CompanyServices
{
    void Create(string? name, string description);
    void Delete(string name);
    void Activate(string name);
    void ShowAll();
    void GetCompany(string name);
    void GetDepartmentIncluded(string name);

    //----------------------------------------
    bool IsCompanyExist();
}
