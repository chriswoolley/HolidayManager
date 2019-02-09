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

        //public IEnumerable<DepartmentManager> Managers(Department department)
        //{          
        //    return _AppDbContext.Departments.FirstOrDefault(p => p.Id == department.Id).DepartmentManagers.ToList();
        //}

//        IEnumerable<User> IDepartment.Managers(Department department)
//        {
//            List<User> Managers = new List<User>();
//            Department DM2 = _holidayContext.Departments.FirstOrDefault(p => p.Id == department.Id);
//            foreach (DepartmentManager dm2 in DM2.DepartmentManagers)
//            {
//                Managers.Add(dm2.User);
//            }

////            List<User> Managers = new List<User>();
////            foreach (DepartmentManager DM in _holidayContext.DepartmentManagers.Where(p => p.Department.Id == department.Id))
////            {
////                Managers.Add(DM.User);
////            }
//            return Managers;
//        }
    }
}
