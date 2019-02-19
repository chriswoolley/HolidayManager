using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Interface
{
    public interface IDepartment
    {
        IEnumerable<Department> GetAllDepartment();
        Department GetDepartmentById(int departmentId);
        void EditDepartment(Department department);
        void DeleteDepartment(Department department);
        void AddDepartment(Department department);
        SelectList DepartmentSelectList();

    }
}
