using System;
using System.Collections.Generic;
using System.Data.Entity;
using ODataWebAPI.Domain.Entities;

namespace ODataWebAPI.DomainContext
{
    public class EntitiesInitializer : DropCreateDatabaseIfModelChanges<EntitiesContext>
    {
        protected override void Seed(EntitiesContext context)
        {
            // Companies
            GetCompanies().ForEach(c => context.Companies.Add(c));

            // Addresses
            GetAddresses().ForEach(a => context.Addresses.Add(a));

            // Employees
            GetEmployees().ForEach(e => context.Employees.Add(e));

            base.Seed(context);
        }

        private static List<Company> GetCompanies()
        {
            var companies = new List<Company>();

            for (var i = 1; i <= 10; i++)
            {
                companies.Add(new Company()
                {
                    Id = i,
                    Name = MockData.Company.Name()
                });
            }

            return companies;
        }

        private static List<Address> GetAddresses()
        {
            var addresses = new List<Address>();

            for (var i = 1; i <= 200; i++)
            {
                addresses.Add(new Address()
                {
                    Id = i,
                    City = MockData.Address.City(),
                    Country = MockData.Address.Country(),
                    State = MockData.Address.State(),
                    ZipCode = MockData.Address.ZipCode()
                });
            }

            return addresses;
        }

        private static List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            for (var i = 1; i <= 200; i++)
            {
                employees.Add(new Employee()
                {
                    Id = i,
                    FirstName = MockData.Person.FirstName(),
                    Surname = MockData.Person.Surname(),
                    AddressId = i,
                    CompanyId = new Random().Next(1, 10),
                    Email = MockData.Internet.Email(),
                });
            }

            return employees;
        }
    }
}
