using System;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Departments> GetAllDepartments()
        {
            return _connection.Query<Departments>("SELECT * FROM DEPARTMENTS;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
                new { departmentName = newDepartmentName });
        }



    }
}

