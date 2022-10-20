using PP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PP.Domain.DAL;

public interface IOrderRepository
{
    public Task<IList<Order>> GetAll();

    public Task<Order> Get(int id);

    public Task Update(Order order);

    public Task Delete(int id);

    public Task Create(Order order);
    void SaveAll();
}
