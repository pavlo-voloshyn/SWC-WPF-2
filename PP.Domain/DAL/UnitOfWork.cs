using System.Threading.Tasks;

namespace PP.Domain.DAL;

public class UnitOfWork
{
    private UnitOfWork() 
    { 
        orderRepository = new OrderRepository();
        employeeOrderRepository = new EmployeeOrderRepository();
        employeeRepository = new EmployeeRepository();
    }

    private static UnitOfWork _instance;

    private static readonly object _lock = new();

    public static UnitOfWork GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new UnitOfWork();
                }
            }
        }
        return _instance;
    }

    readonly IEmployeeRepository employeeRepository;
    public IEmployeeRepository EmployeeRepository => employeeRepository;

    readonly IEmployeeOrderRepository employeeOrderRepository;
    public IEmployeeOrderRepository EmployeeOrderRepository => employeeOrderRepository;

    readonly IOrderRepository orderRepository;
    public IOrderRepository OrderRepository => orderRepository;

    public void SaveAll()
    {
        employeeOrderRepository.SaveAll();
        orderRepository.SaveAll();
        employeeRepository.SaveAll();
    }

}
