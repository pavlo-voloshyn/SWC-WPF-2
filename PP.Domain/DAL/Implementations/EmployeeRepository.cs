using PP.Domain.DAL.Implementations;
using PP.Domain.Models;
using PP.Domain.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PP.Domain.DAL;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository() : base()
    {
        //entities.Add(new Employee() { Id = 1, FirstName = "Slavik", LastName = "Zozuk", Office = "Lviv DSMU", Role = Role.Officer });
        //entities.Add(new Employee() { Id = 2, FirstName = "Dmytro", LastName = "Melnyk", Office = "Lviv DSMU", Role = Role.SeniorOfficer });

        this.storagePath += "Employee.dat";
        this.ReadAll();
    }
}
