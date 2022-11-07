using Dapper;
using IntroSQL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------
// David Zientara
// 11-7-2022
//
// DapperDepartmentRepository
// 
// Interface for DapperDepartmentRepository
// Contains constructor, GetAllDepartments, and
// InsertDepartment
//
//--------------------------------------


namespace ORM_Dapper
{
    internal class DapperDeparmentRepository
    {
        public class DapperDepartmentRepository : IDepartmentRepository
        {
            private readonly IDbConnection _connection;
            //Constructor
            public DapperDepartmentRepository(IDbConnection connection)
            {
                _connection = connection;
            }


            public IEnumerable<Department> GetAllDepartments()
            {
                return _connection.Query<Department>("SELECT * FROM Departments;").ToList();
            }

            public void InsertDepartment(string newDepartmentName)
            {
                _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
                    new { departmentName = newDepartmentName });
            }

        }
    }
}
