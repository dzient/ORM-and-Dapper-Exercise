using System;
using System.Collections.Generic;

//--------------------------------------
// David Zientara
// 11-7-2022
//
// IDepartmentRepository.cs
// 
// Interface for DepartmentRepository
// Only contains one class - GetAllDepartments()
//
//--------------------------------------

namespace IntroSQL
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments(); //Stubbed out method
    }
}
