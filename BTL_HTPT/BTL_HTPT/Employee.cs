using System;

public class Employee
{
    private int employeeID;
    private string fullName;
    private double salary;
    private DateTime hireDate;
    private bool isActive;

    public int EmployeeID
    {
        get { return employeeID; }
        set
        {
            if (value > 0)
            {
                employeeID = value;
            }
        }
    }

    public string FullName
    {
        get { return fullName; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                fullName = value;
            }
        }
    }

    public double Salary
    {
        get { return salary; }
        set
        {
            if (value >= 0)
            {
                salary = value;
            }

        }
    }

    public DateTime HireDate
    {
        get { return hireDate; }
        set
        {
            if (value != null)
            {
                hireDate = value;
            }
        }
    }

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    public Employee(int employeeID, string fullName, double salary, DateTime hireDate, bool isActive)
    {
        EmployeeID = employeeID;
        FullName = fullName;
        Salary = salary;
        HireDate = hireDate;
        IsActive = isActive;
    }
}


