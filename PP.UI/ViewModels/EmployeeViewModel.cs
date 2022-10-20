using PP.Domain.DAL;
using PP.Domain.Models;
using PP.Domain.Models.Enums;
using PP.UI.Shared;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PP.UI.ViewModels;

public class EmployeeViewModel : ViewModelBase
{
    private string firstName;
    private string lastName;
    private Role role;
    private string office;

    public string FirstName { get => firstName; set { firstName = value; OnPropertyChanged(nameof(FirstName)); } }

    public string LastName { get => lastName; set { lastName = value; OnPropertyChanged(nameof(LastName)); } }

    public Role ERole { get => role; set { role = value; OnPropertyChanged(nameof(this.ERole)); } }

    public string Office { get => office; set { office = value; OnPropertyChanged(nameof(Office)); } }

    public ICommand AddCommand => new Command(p => true, async o =>
    {
        var employee = Mapper.Map<Employee>(this);
        var employees = await unitOfWork.EmployeeRepository.GetAll();
        employee.Id = employees.Select(e => e.Id).Max() + 1;
        await unitOfWork.EmployeeRepository.Create(employee);
        ((Window)o).Close();
    });

    public ICommand UpdateEmployeeCommand => new Command(p => true, async a =>
    {
        await unitOfWork.EmployeeRepository.Update(Mapper.Map<Employee>(this));
    });
}
