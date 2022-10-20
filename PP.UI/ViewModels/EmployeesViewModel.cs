using PP.Domain.DAL;
using PP.UI.Shared;
using PP.UI.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.UI.ViewModels;

public class EmployeesViewModel : ViewModelBase
{
    private ObservableCollection<EmployeeViewModel> employees = new ObservableCollection<EmployeeViewModel>();
    private int selectedEmployeeId;

    public int SelectedEmployeeId { get => selectedEmployeeId; set { selectedEmployeeId = value; OnPropertyChanged(nameof(SelectedEmployeeId)); } }

    public EmployeesViewModel() : base()
    {
        LoadEmployees().Wait();
    }

    private async Task LoadEmployees()
    {
        var employees = await unitOfWork.EmployeeRepository.GetAll();
        Employees = Mapper.Map<ObservableCollection<EmployeeViewModel>>(employees);
    }

    public ObservableCollection<EmployeeViewModel> Employees { get => employees; set { employees = value; OnPropertyChanged(nameof(Employees)); } }

    public ICommand DeleteEmployeeCommand => new Command(p => true, async id =>
    {
        await unitOfWork.EmployeeRepository.Delete((int)id);
        await unitOfWork.EmployeeOrderRepository.DeleteByEmployee((int)id);
        await LoadEmployees();
    });

    public ICommand ResetSelectedEmployeeCommand => new Command(p => true, a =>
    {
        SelectedEmployeeId = 0;
    });

    public ICommand SelectEmployeeCommand => new Command(p => true, id =>
    {
        SelectedEmployeeId = (int)id;
    });

    public ICommand AddEmployeeCommand => new Command(p => true, async a =>
    {
        AddEmployee win = new();
        win.ShowDialog();
        await LoadEmployees();
    });
}
