using PP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PP.Domain.DAL;

public interface IEmployeeOrderRepository
{
    public Task<IList<EmployeeOrder>> GetAll();

    public Task Delete(int employeeId, int orderId);

    public Task Create(int employeeId, int orderId);

    public Task DeleteByEmployee(int employeeId);
    void SaveAll();
}
