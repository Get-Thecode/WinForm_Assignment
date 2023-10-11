using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_EmployeeSalaryDetails.Models
{
    public class Employee
    {
        
        public string Code { get; set; }

        
        public string First_Name { get; set; }

        
        public string Middle_Name { get; set; }

       
        public string Last_Name { get; set; }

       
        public string Full_Name { get; set; }

        public DateTime DOB { get; set; }

        public int Salary { get; set; }

        public int Dept_Code { get; set; }

        public int Country_Code { get; set; }

        public int State_Code { get; set; }

        public int City_Code { get; set; }
    }

    public class Data
    {

        public string Code { get; set; }


        public string First_Name { get; set; }


        public string Middle_Name { get; set; }


        public string Last_Name { get; set; }


        public string Full_Name { get; set; }

        public DateTime DOB { get; set; }

        public int Salary { get; set; }

        public string Dept_Code { get; set; }

        public string Country_Code { get; set; }

        public string State_Code { get; set; }

        public string City_Code { get; set; }
    }
    // Department model class
    public class DepartmentItem
    {
        public int Code { get; }
        public string Name { get; }

        public DepartmentItem(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public override string ToString()
        {
            return Name; // Display the department name in the ComboBox
        }
    }


    // City model class
    public class City
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int State_Code { get; set; }
        public int Country_Code { get; set; }
        public byte Sort_No { get; set; }
    }

    // State model class
    public class State
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Country_Code { get; set; }
        public byte Sort_No { get; set; }
    }

    // Country model class
    public class Country
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public byte Sort_No { get; set; }
    }

    public class CityStatisticsViewModel
    {
        public string Name { get; set; }
        public int TotalSalary { get; set; }
        public int EmployeeCount { get; set; }
    }

    public class DepartmentStatisticsViewModel
    {
        public string Name { get; set; }
        public int TotalSalary { get; set; }
        public int EmployeeCount { get; set; }
    }

   

}