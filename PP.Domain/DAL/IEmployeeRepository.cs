using PP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PP.Domain.DAL;

public interface IEmployeeRepository
{
    public Task<IList<Employee>> GetAll();

    public Task<Employee> Get(int id);
    
    public Task Update(Employee employee);

    public Task Delete(int id);

    public Task Create(Employee employee);
    void SaveAll();
}
