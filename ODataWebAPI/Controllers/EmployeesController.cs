using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using Microsoft.Data.OData;
using ODataWebAPI.Domain.Entities;
using ODataWebAPI.DomainContext;

namespace ODataWebAPI.Controllers
{
    public class EmployeesController : EntitySetController<Employee, int>
    {
        private readonly EntitiesContext _dbContext;

        public EmployeesController()
        {
            _dbContext = new EntitiesContext();
        }

        [Queryable]
        public override IQueryable<Employee> Get()
        {
            return _dbContext.Employees;
        }

        protected override Employee GetEntityByKey(int key)
        {
            return _dbContext.Employees.FirstOrDefault(e => e.Id == key);
        }

        protected override Employee CreateEntity(Employee entity)
        {
            _dbContext.Employees.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        protected override Employee UpdateEntity(int key, Employee update)
        {
            if (!_dbContext.Employees.Any(e => e.Id == key))
            {
                throw new HttpResponseException(
                    Request.CreateODataErrorResponse(
                    HttpStatusCode.NotFound,
                    new ODataError
                    {
                        ErrorCode = "NotFound.",
                        Message = "Employee " + key + " not found."
                    }));
            }

            update.Id = key;

            _dbContext.Employees.Attach(update);
            _dbContext.Entry(update).State = System.Data.Entity.EntityState.Modified;
            _dbContext.SaveChanges();
            return update;
        }

        protected override Employee PatchEntity(int key, Delta<Employee> patch)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.Id == key);
            if (employee == null)
                throw new HttpResponseException(
                    Request.CreateODataErrorResponse(
                    HttpStatusCode.NotFound,
                    new ODataError
                    {
                        ErrorCode = "NotFound.",
                        Message = "Employee " + key + " not found."
                    }));

            patch.Patch(employee);
            _dbContext.SaveChanges();

            return employee;
        }

        public override void Delete(int key)
        {
            var employee = _dbContext.Employees.Where(a => a.Id == key).FirstOrDefault();
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
            else
                throw new HttpResponseException(
                    Request.CreateODataErrorResponse(
                    HttpStatusCode.NotFound,
                    new ODataError
                    {
                        ErrorCode = "NotFound.",
                        Message = "Employee " + key + " not found."
                    }));
        }

        protected override int GetKey(Employee entity)
        {
            return entity.Id;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _dbContext.Dispose();
        }
    }
}