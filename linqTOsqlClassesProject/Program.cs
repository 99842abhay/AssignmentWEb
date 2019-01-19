using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqTOsqlClassesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Your Choice\n 1.Add Employee\n2.Edit Employee\n 3.Delete\n4.Select All Employee\n5.Select By Id");
            int n = Convert.ToInt32(Console.ReadLine());

            DataClasses1DataContext db = new DataClasses1DataContext();

            switch (n)
            {
                case 1:
                    Console.WriteLine("Insert EmployeeID,Country, Gender,Salary, DepID");
                    int empid = Convert.ToInt32(Console.ReadLine());
                    string country = Console.ReadLine();
                    string gender = Console.ReadLine();
                    int salary = Convert.ToInt32(Console.ReadLine());
                    int depid = Convert.ToInt32(Console.ReadLine());

                    Employee emp2 = new Employee() { EmployeeID = empid, Country = country, Gender = gender, Salary = salary, DepID = depid };

                    db.Employees.InsertOnSubmit(emp2);

                    db.SubmitChanges();

                    break;
                case 2:
                    Console.WriteLine("Insert EmployeeID");
                    int empid1 = Convert.ToInt32(Console.ReadLine());
                    Employee emp3 = (from e4 in db.Employees
                                     where e4.EmployeeID == empid1
                                     select e4).Single();

                    Console.WriteLine("Enter new salary");
                    int sal = Convert.ToInt32(Console.ReadLine());

                    emp3.Salary = sal;

                    db.SubmitChanges();


                    break;
                case 3:

                    Console.WriteLine("Insert EmployeeID");
                    int empid2 = Convert.ToInt32(Console.ReadLine());
                    Employee emp4 = (from e5 in db.Employees
                                     where e5.EmployeeID == empid2
                                     select e5).Single();

                    db.Employees.DeleteOnSubmit(emp4);

                    db.SubmitChanges();

                    break;
                case 4:
                    List<Employee> emps = db.Employees.ToList();

                    foreach (var e1 in emps)
                    {
                        Console.WriteLine("{0} {1} {2} {3} {4}", e1.EmployeeID, e1.Country, e1.Gender, e1.Salary, e1.DepID);
                    }
                    break;
                case 5:
                    int id;
                    Console.WriteLine("entr id");
                    id = Convert.ToInt32(Console.ReadLine());
                    Employee e = db.Employees.Where(a => a.EmployeeID == id).Single();

                    Console.WriteLine("{0} {1} {2} {3} {4}", e.EmployeeID, e.Country, e.Gender, e.Salary, e.DepID);
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }
    }
}
