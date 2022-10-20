using PP.Domain.DAL.Implementations;
using PP.Domain.Models;
using PP.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PP.Domain.DAL;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository()
    {
        //entities.Add(new Order { Id = 1, DateCreated = DateTime.Now, IsUrgent = false, ServiceType = ServiceType.CreatePassport, PassportId = 124123 });
        //entities.Add(new Order { Id = 2, DateCreated = DateTime.Now, IsUrgent = true, ServiceType = ServiceType.ChangePassport, PassportId = 2354123 });
        //entities.Add(new Order { Id = 3, DateCreated = DateTime.Now, IsUrgent = false, ServiceType = ServiceType.CreateForeignPassport, PassportId = 8765123 });
        //entities.Add(new Order { Id = 4, DateCreated = DateTime.Now, IsUrgent = false, ServiceType = ServiceType.ChangeForeignPassport, PassportId = 34734123 });

        this.storagePath += "Order.dat";
        this.ReadAll();
    }
}
