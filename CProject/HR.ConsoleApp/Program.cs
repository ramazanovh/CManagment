using C.Business.Interface;
using C.Business.Services;
using C.Business.Utilities.Helpers;
using C.DataAccess.Contexts;
using System;

Console.WriteLine("HR App Start");
CompanyServices companyServices = new();
EmployeeServices employeeServices = new();
DepartmentServices departmentServices = new();
bool isContinue = true;
while (isContinue)
{
    Console.WriteLine("___________________________________________________________________");
    Console.WriteLine("Choose the option:");
    Console.WriteLine("-- wirket--\n" +
                      "1 - wirket yaradilmiwdir \n" +
                      "2 - butun wirketleri goster \n" +
                      "3 - Aktiv caliwan wirketler \n" +
                      "4 - Wirketleri Silin \n" +
                      "5 - Wirket Depertamenetine get\n" +

                      "-- Department--\n" +
                      "6 -  Department Yarat \n" +
                      "7 - Butun  Department goster \n" +
                      "8 - Aktiv Department \n" +
                      "9 -  Department sil \n" +
                      "10 - Butun depertamentleri goster \n" +

                      "-- Isciler--\n" +
                      "11 - ISci Yarat \n" +
                      "12 - butun iscileri goster \n" +


                      "0 - Exit");
    Console.WriteLine("--------------------------------------------------------------------");
    string? option = Console.ReadLine();
    int optionNumber;
    bool isInt = int.TryParse(option, out optionNumber);
    if (isInt)
    {
        if (optionNumber >= 0 && optionNumber <= 15)
        {
            switch (optionNumber)
            {
                case (int)Menu.Exit:
                    Environment.Exit(0);
                    break;
                case (int)Menu.CreateCompany:
                    try
                    {
                        Console.WriteLine("Sirket adini daxil ele:");
                        string? companyName = Console.ReadLine();
                        Console.WriteLine("sirket descption daxil ele:");
                        string? companyDescription = Console.ReadLine();
                        companyServices.Create(companyName, companyDescription);
                        Console.WriteLine("YAradilmiwdir");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case (int)Menu.CreateCompany;
                    }
                    break;

                case (int)Menu.ShowAllCompany:

                    Console.WriteLine("Butun Companiler":");
                    if (companyServices.IsCompanyExist() == false)
                    {
                        Console.WriteLine("Company is legv edillmiwdir:");
                    }
                    companyServices.ShowAll();
                    break;
                case (int)Menu.ActivateCompany:
                    if (companyServices.IsCompanyExist() == false) Console.WriteLine("Company is legv edilmiwdir:");
                    try
                    {
                        Console.WriteLine("Company adi daxil ele:");
                        string? companyName = Console.ReadLine();
                        companyServices.Activate(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.DeleteCompany:
                    if (companyServices.IsCompanyExist() == false) Console.WriteLine("Company is legv edilmiwdir");
                    try
                    {
                        Console.WriteLine("Company adi daxil ele:");
                        string? companyName = Console.ReadLine();
                        companyServices.Delete(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.GetByNameCompany:
                    try
                    {
                        Console.WriteLine("Company adi daxil ele");
                        string? companyName = Console.ReadLine();
                        companyServices.GetCompany(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
       



                case (int)Menu.CreateDepartment:
                    if (companyServices.IsCompanyExist() == false)
                    {
                        Console.WriteLine("Sen artik bir comoany yaratmisan:");
                        goto case (int)Menu.CreateCompany;
                    }
                    try
                    {
                        Console.WriteLine("Company adi daxil ele");
                        string? departmentName = Console.ReadLine();
                        Console.WriteLine("Enter department employee limit:");
                        int employeeLimit = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("----------------------");
                        companyServices.ShowAll();
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Company adi daxil ele");
                        string? companyName2 = Console.ReadLine();
                        departmentServices.Create(departmentName, employeeLimit, companyName2);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 3;
                    }
                    break;
                case (int)Menu.ShowAllDepartment:
                    if (departmentServices.IsDepartmentExist() == false)
                    {
                        Console.WriteLine("Department is missing:");
                        goto case (int)Menu.CreateDepartment;
                    }
                    Console.WriteLine("All department:");
                    departmentServices.ShowAll();
                    break;
                case (int)Menu.ActivateDepartment:
                    try
                    {
                        Console.WriteLine("Company adi daxil ele:");
                        string? departmentName = Console.ReadLine();
                        departmentServices.Activate(departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.DeleteDepartment:
                    try
                    {
                        Console.WriteLine("Enter department adini:");
                        string? departmentName = Console.ReadLine();
                        departmentServices.Delete(departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.GetDepartmentEmployee:
                    try
                    {
                        Console.WriteLine("Enter department adini:");
                        string? departmentName = Console.ReadLine();
                        departmentServices.GetDepartmentEmployee(departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.CreateEmployee:
                    try
                    {
                        Console.WriteLine("Enter isci adini:");
                        string? employeetName = Console.ReadLine();
                        Console.WriteLine("Enter isci soyadini:");
                        string? employeeSurname = Console.ReadLine();
                        Console.WriteLine("Enter isci email:");
                        string? employeeEmail = Console.ReadLine();
                        Console.WriteLine("Enter isci password:");
                        string? employeePassword = Console.ReadLine();
                        Console.WriteLine("Enter isci gelirini:");
                        decimal employeeSalary = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-----------------------");
                        departmentServices.ShowAll();
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Enter department adini:");
                        string? departmentName = Console.ReadLine();
                        employeeServices.Create(employeetName, employeeSurname, employeeEmail, employeePassword,
                            employeeSalary, departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.ShowAllEmployee:
                    Console.WriteLine("Butun isciler:");
                    employeeServices.ShowAll();
                    break;
                case (int)Menu.getCompany:
                    try
                    {
                        Console.WriteLine("Enter company adini:");
                        string? companyName = Console.ReadLine();
                        companyServices.GetCompany(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.moveEmployee:
                    try
                    {
                        Console.WriteLine("----------isciler-------------");
                        employeeServices.ShowAll();
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Enter isci ID");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-----------departments------------");
                        departmentServices.ShowAll();
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Enter department adini:");
                        string? departmentName = Console.ReadLine();
                        employeeServices.ChangeDepartment(employeeId, departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                default:
                    isContinue = false;
                    break;
            }
        }
        else
        {
            Console.WriteLine("xaiw eidrik duzgun optiopn nomreisini daxil edesiniz!");
        }
    }
    else
    {
        Console.WriteLine("xaiw edirik duzgun  option secin!");
    }
}
