using Tarea3_DWB.DataAccess;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tarea3_DWB.BackEnd;
using Tarea3_DWB.NorthwindData;

namespace Tarea3_DWB
{
    class Program
    {
        public static void InitialTest()
        {
            DWBLMVContext dbContext = new DWBLMVContext();

            //SELECT *FROM PRODUCTS
            var productsQry = dbContext.Products;   //Datos en forma de Qry
            var productList = productsQry.ToList(); //Datos Obtenido del Qry, guardados en una lista

            //SELECT Title as Titulo, Cost as Costo from Products  <- Objeto anonimo
            var productSelectQry = dbContext.Products.Select(s => new
            {// Proyeccion Lambda
                Titulo = s.Title,
                Costo = s.Cost
            }).ToList();

            productSelectQry.ForEach(f => Console.WriteLine(f.Titulo));
        }

        public static void Excercise1()
        {
            var employeQry = new EmployeesSC().GetEmployees();
            var output = employeQry.ToList();
        }

        public static void Excercise2()
        {
            var employeQry = new EmployeesSC().GetEmployees().Select(s => new
            {
                s.Title,
                s.FirstName,
                s.LastName
            }).Where(w => w.Title == "Sales Representative").AsQueryable();

            var output = employeQry.ToList();

            output.ForEach(Fe => Console.WriteLine("Name:" + Fe.FirstName + " Title:" + Fe.Title));
        }

        public static void Excercise3()
        {
            var employeeQry = new EmployeesSC().GetEmployees().Select(s => new
            {
                s.Title,
                s.FirstName,
                s.LastName
            }).Where(w => w.Title != "Sales Representative").AsQueryable();

            var output = employeeQry.ToList();
        }

        public static void Excercise4()
        {
            new EmployeesSC().UpdateEmployeeById(1);
        }

        public static void Excercise5()
        {
            new ProductSC().AddNewProduct("Coca - Cola", 12.50m);
        }

        public static void Excercise6(int id)
        {
            new EmployeesSC().DeleteEmployeeById(id);
        }

        public static void Excercise7(int orderId)
        {
            var qry = new OrderSC().GetOrderById(orderId).Select(s => new
            {
                Empleado = s.Employee.FirstName,
                Cliente = s.Customer.ContactName,
                Products = s.OrderDetails.Select(sel => sel.Product.ProductName)
           });

            var result = qry.ToList();
        }
        
        static void Main(string[] args)
        {
        //    Excercise1();
        //    Excercise2();
        //    Excercise3();
        //    Excercise4();
        //    Excercise5();
        //    Excercise6(9);
        //    Excercise7(10248);
        }
    }
}
