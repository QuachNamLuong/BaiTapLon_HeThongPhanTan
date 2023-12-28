using System;
using System.Data;
using System.Data.SqlClient;

namespace BTL_HTPT
{
    class EmployeeDAO
    {
        private SQLConnector connector;

        public EmployeeDAO(string connectionString)
        {
            connector = new SQLConnector(connectionString);
        }

        public bool InsertEmployee(Employee employee)
        {
            string sp_insert_employee_name = "SP_Insert_Employee";

            SqlParameter[] parameters = {
                new SqlParameter("@EmployeeID", employee.EmployeeID),
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@Salary", employee.Salary),
                new SqlParameter("@HireDate", employee.HireDate),
                new SqlParameter("@IsActive", employee.IsActive)
            };

            bool isSuccess = connector.ExecuteStoredProcedure(sp_insert_employee_name, parameters);

            return isSuccess;
        }

        public bool UpdateEmployee(Employee employee)
        {
            string sp_update_employee_name = "SP_Update_Employee";

            SqlParameter[] parameters = {
                new SqlParameter("@EmployeeID", employee.EmployeeID),
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@Salary", employee.Salary),
                new SqlParameter("@HireDate", employee.HireDate),
                new SqlParameter("@IsActive", employee.IsActive)
            };

            bool isSuccess = connector.ExecuteStoredProcedure(sp_update_employee_name, parameters);

            return isSuccess;
        }

        public bool DeleteEmployee(Employee employee)
        {
            string sp_delete_employee_name = "SP_Delete_Employee";

            SqlParameter[] parameters = {
                new SqlParameter("@EmployeeID", employee.EmployeeID)
            };

            bool isSuccess = connector.ExecuteStoredProcedure(sp_delete_employee_name, parameters);

            return isSuccess;
        }

        public DataTable GetEmployeeTable()
        {
            string query = "SELECT * FROM dbo.Employee";
            return connector.GetTable(query);
        }
    }
}
