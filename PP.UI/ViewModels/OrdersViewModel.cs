using PP.UI.Shared;
using PP.UI.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.UI.ViewModels;

public class OrdersViewModel : ViewModelBase
{
    private ObservableCollection<OrderViewModel> orders = new ObservableCollection<OrderViewModel>();
    private int selectedIdEmployee;

    public int SelectedIdEmployee { get => selectedIdEmployee; set { selectedIdEmployee = value; LoadOrders().Wait(); } }

    public OrdersViewModel() : base()
    {
        LoadOrders().Wait();
    }

    private async Task LoadOrders()
    {
        var orders = await unitOfWork.OrderRepository.GetAll();
        var employeeOrders = await unitOfWork.EmployeeOrderRepository.GetAll();
        var employeeOrderIds = employeeOrders.Where(eo => eo.EmployeeId == SelectedIdEmployee).Select(eo => eo.OrderId).ToList();

        Orders = Mapper.Map<ObservableCollection<OrderViewModel>>(orders.Where(o => employeeOrderIds.Contains(o.Id)).ToList());
    }

    public ICommand DeleteOrderCommand => new Command(p => true, async id =>
    {
        await unitOfWork.EmployeeOrderRepository.Delete(SelectedIdEmployee, (int)id);
        await LoadOrders();
    });

    public ICommand AddOrderCommand => new Command(p => true, async a =>
    {
        AddOrderView win = new(SelectedIdEmployee);
        win.ShowDialog();
        await LoadOrders();
    });
    public ObservableCollection<OrderViewModel> Orders { get => orders; set { orders = value; OnPropertyChanged(nameof(Orders)); } }
}
