using HolidayWeb.Models.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Repositories
{
    public class DepartmentRepository : IDepartment
    {

        private readonly AppDbContext _AppDbContext;
        public DepartmentRepository(AppDbContext AppDbContext)
        {
            _AppDbContext = AppDbContext;
        }

        public void AddDepartment(Department department)
        {
            _AppDbContext.Departments.Add(department);
            _AppDbContext.SaveChanges();
        }

        public void DeleteDepartment(Department department)
        {
            _AppDbContext.Departments.Remove(department);
            _AppDbContext.SaveChanges();
        }


        public void EditDepartment(Department department)
        {
            _AppDbContext.Departments.Update(department);
            _AppDbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return _AppDbContext.Departments;
        }


        public Department GetDepartmentById(int departmentId)
        {
            return _AppDbContext.Departments.FirstOrDefault(p => p.Id == departmentId);
        }

        public SelectList DepartmentSelectList()
        {
            return new SelectList(GetAllDepartment(), "Id", "DepartmentName");
        }


    }
}
