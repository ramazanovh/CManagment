using C.Interface;
using C.Utilities.Exeptions;
using C.DataAccess.Contexts;
using CManagment.Entities;

namespace Hr.Business.Services;

public class CompanyServices : MyInterface.CompanyServices
{
    public void Create(string? name, string description)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company? dbCompany=
            HRDbContext.Companies.Find(c=>c.Name.ToLower() == name.ToLower());
        if(dbCompany is not null) 
            throw new AlreadyExistException($"{dbCompany.Name} is already exist");
        Company company = new(name, description);
        HRDbContext.Companies.Add(company);
    }
  
    public void Activate(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company? dbCompany =
            HRDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbCompany is null)
            throw new NotFoundException($"{name} company is not found");
        dbCompany.IsActive = true;
    }

    public void Delete(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company? dbCompany = 
            HRDbContext.Companies.Find(c=> c.Name.ToLower() == name.ToLower());
        if (dbCompany is null)
            throw new NotFoundException($"{name} company is not found");
        dbCompany.IsActive = false;
    }
    public void GetCompany(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company? dbCompany =
            HRDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbCompany is null)
            throw new NotFoundException($"{name} company is not found");
        Console.WriteLine($"id: {dbCompany.Id}\n" +
                          $"Company name: {dbCompany.Name}\n" +
                          $"Company description: {dbCompany.Description}\n");
        GetDepartmentIncluded(dbCompany.Name);
    }
    
    public void GetDepartmentIncluded(string name)
    {
        foreach (var department in HRDbContext.Departments)
        {
            if (department.CompanyId.Name.ToLower() == name.ToLower())
            {
                Console.WriteLine($"Id: {department.Id}; Group name:{department.Name}");
                Console.WriteLine("------------------------------------------");
            }
        }
    }

    public Company? FindCompanyByName(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        return HRDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
    }

    public bool IsCompanyExist()
    {
        foreach (var item in HRDbContext.Companies)
        {
            if (item is not null && item.IsActive == true) return true;
        }
        return false;
    }

}
