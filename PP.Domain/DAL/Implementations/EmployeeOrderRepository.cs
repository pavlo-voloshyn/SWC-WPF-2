using PP.Domain.DAL.Implementations;
using PP.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PP.Domain.DAL;

public class EmployeeOrderRepository : BaseRepository<EmployeeOrder>, IEmployeeOrderRepository
{
    public EmployeeOrderRepository() : base()
    {
    //    this.entities.Add(new EmployeeOrder() { EmployeeId = 1, OrderId = 1 });
    //    this.entities.Add(new EmployeeOrder() { EmployeeId = 1, OrderId = 2 });
    //    this.entities.Add(new EmployeeOrder() { EmployeeId = 2, OrderId = 3 });
    //    this.entities.Add(new EmployeeOrder() { EmployeeId = 2, OrderId = 4 });
        this.storagePath += $@"EmployeeOrder.dat";
        this.ReadAll();
    }

    public async Task Create(int employeeId, int orderId)
    {
        await Task.Run(() => entities.Add(new EmployeeOrder() { EmployeeId = employeeId, OrderId = orderId}));   
    }

    public async Task Delete(int employeeId, int orderId)
    {
        await Task.Run(() => entities.Where(x => x.EmployeeId == employeeId && x.OrderId == orderId)
           .ToList()
           .ForEach(eo => entities.Remove(eo)));
    }

    public async Task DeleteByEmployee(int employeeId)
    {
        await Task.Run(() => entities.Where(x => x.EmployeeId == employeeId)
           .ToList()
           .ForEach(eo => entities.Remove(eo)));
    }
}
