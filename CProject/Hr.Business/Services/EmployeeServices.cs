using C.Interface;
using C.Utilities.Exeptions;
using C.DataAccess.Contexts;
using CManagment.Entities;

namespace Hr.Business.Services;

public class EmployeeServices : interface.EmployeeServices
{
    private interface.DepartmentServices departmentServices { get; }
    public EmployeeServices()
    {
        departmentServices = new DepartmentServices();
    }
    public void Create(string name, string surname, string email, string password,
       decimal salary, string departmentName)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Department? department = departmentServices.GetByName(departmentName);
        if (department is null) throw new NotFoundException($"{departmentName} is not exist");
        if (department.EmployeeLimit == department.CurrentEmployeeCount)
        {
            throw new iTDepException($"{department.Name} is already full");
        }
        Employee employee = new(name, surname, email, password, salary);
        HRDbContext.Employees.Add(employee);
        department.CurrentEmployeeCount++;
    }
    public void Activate(string name, bool activated)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        var isEmployee = HRDbContext.Departments.Find(x => x.Name.ToLower() == name.ToLower());
        if (isEmployee is null) throw new NotFoundException($"{name} employee is not found");
        isEmployee.IsActive = true;
    }
    public void ChangeDepartment(int employeeId, string newDepartmentName)
    {
        var employee = HRDbContext.Employees.Find(x => x.Id == employeeId);
        if (employee is null) throw new NotFoundException("employee is not found");

        if (String.IsNullOrEmpty(newDepartmentName)) throw new ArgumentNullException();
        var department = HRDbContext.Departments.Find(x => x.Name.ToLower() == newDepartmentName.ToLower());
        if (department is null) throw new NotFoundException("department is not found");

        Delete(employee.Id);

        Create(employee.Name, employee.Surname, employee.Email, employee.Password, employee.Salary, department.Name);
    }
    public void Delete(int Id)
    {
        var employee = HRDbContext.Employees.Find(x => x.Id == Id);
        if (employee is null) throw new NotFoundException("employee is not found");
        employee.IsDelete = true;
        if (employee.DepartmentId.CurrentEmployeeCount > 4)
        {
            employee.DepartmentId.CurrentEmployeeCount--;
        }
        else departmentServices.Delete(employee.DepartmentId.Name);



    public string Name (DependencyObject obj)
    {
        return ()obj.GetValue(MyPropertyProperty);
    }

    public static void SetMyProperty(DependencyObject obj,  value)
    {
        obj.SetValue(MyPropertyProperty, value);
    }

// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
public static readonly DependencyProperty MyPropertyProperty =
    DependencyProperty.RegisterAttached("MyProperty", typeof(), typeof(ownerclass), new PropertyMetadata(0));


    }
}

