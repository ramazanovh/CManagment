using C.Interface;
using C.Utilities.Exeptions;


using System;
using System.Xml.Linq;


using C.DataAccess.Contexts;
using CManagment.Entities;

namespace Hr.Business.Services;

public class DepartmentServices : Interface.DepartmentServices
{
    private Interface.CompanyServices companyServices { get; }
    public DepartmentServices()
    {
        companyServices = new CompanyServices();
    }
    public void Create(string name, int employeeLimit, string companyName)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Department? dbDepartment =
            HRDbContext.Departments.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbDepartment is not null)
            throw new AlreadyExistException($"{dbDepartment.Name} is already exist");
        if (employeeLimit < 4)
            throw new MinCountException("Minimum employee count requirement is 4");
        Company? company = companyServices.FindCompanyByName(companyName);
        if (company is null) throw new NotFoundException($"{companyName} is not exist");
        Department department = new(name, employeeLimit, company);
        HRDbContext.Departments.Add(department);
    }
    public void Activate(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        var isDepartment = HRDbContext.Departments.Find(x => x.Name.ToLower() == name.ToLower());
        if (isDepartment is null) throw new NotFoundException($"{name} department is not found");
        isDepartment.IsActive = true;
    }

    public void Delete(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        var isDepartment = HRDbContext.Departments.Find(x => x.Name.ToLower() == name.ToLower());
        if (isDepartment is null) throw new NotFoundException($"{name} department is not found");
        isDepartment.IsActive = false;
    }
    public Department? GetById(int id)
    {
        return HRDbContext.Departments.Find(x => x.Id == id);
    }
    public Department? GetByName(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        return HRDbContext.Departments.Find(x => x.Name.ToLower() == name.ToLower());
    }

    public void ShowAll()
    {
        foreach (var department in HRDbContext.Departments)
        {
            if (department.IsActive == true) 
                Console.WriteLine($"Id: {department.Id}; Department name:{department.Name}");
        }
    }
    public void GetDepartmentEmployee(string name)
    {
        foreach (var item in HRDbContext.Employees)
        {
            if (item.DepartmentId.Name.ToLower() == name.ToLower())
            {
                if (item.IsDelete == false)
                {
                    Console.WriteLine($"ID: {item.Id}\n" +
                                      $"Name: {item.Name}\n" +
                                      $"Surname: {item.Surname}\n" +
                                      $"Email: {item.Email}\n" +
                                      $"Password:{item.Password}\n" +
                                      $"Salary:{item.Salary}");
                }
            }
        }
    }
    public bool IsDepartmentExist()
    {
        foreach (var item in HRDbContext.Departments)
        {
            if (item is not null && item.IsActive == true)
            {
                return true;
            }
        }
        return false;
    }

     public void moveEmployee(int employeeId)
     {
        throw new Exception();
     }


}


    