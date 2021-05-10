using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea3_DWB.NorthwindData;
using Tarea3_DWB.Models;

namespace Tarea3_DWB.BackEnd
{
    public class EmployeesSC : BaseSC
    {
        public IQueryable<Employee>GetEmployees()   //Obtener los Empleados
        {
            return dbContext.Employees.AsQueryable();
        }
        
        public Employee GetEmployeeById(int id)
        {
            var employee = GetEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();

            if(employee == null)
            {
                throw new Exception("El usuario con el ID solicitado no existe");
            }

            return employee;
        }

        public void UpdateEmployeeById(int id)
        {
            var currentEmployee = GetEmployees().Where(w => w.EmployeeId == id).First();

            currentEmployee.FirstName = "Pablo";

            dbContext.Employees.Update(currentEmployee);
            dbContext.SaveChanges();
            Console.WriteLine("ID:" + currentEmployee.EmployeeId + " Nombre:" + currentEmployee.FirstName);

            var currentEmployee2 = GetEmployees().Where(w => w.EmployeeId == 2).First();

            currentEmployee2.FirstName = "Hector";

            dbContext.Employees.Update(currentEmployee2);
            dbContext.SaveChanges();
            Console.WriteLine("ID:" + currentEmployee2.EmployeeId + " Nombre" + currentEmployee2.FirstName);
        }

        public void DeleteEmployeeById(int id)
        {
            var currentEmployee = GetEmployeeById(id);

            try
            {
                dbContext.Employees.Remove(currentEmployee);
                dbContext.SaveChanges();
            }
            catch(Exception ex) 
            {
                throw new Exception("No se pudo guardar el cambio en la Base de Datos: " +
                    ex.Message + ". " + ex.InnerException != null ? ex.InnerException.Message : " ");
            }
        }

        public void AddEmployee(EmployeeModel newEmployee)
        {
            var newEmployeeReg = new Employee();

            newEmployeeReg.FirstName = newEmployee.Name;
            newEmployeeReg.LastName = newEmployee.LastName;

            dbContext.Employees.Add(newEmployeeReg);
            dbContext.SaveChanges();
        }
    }
}
