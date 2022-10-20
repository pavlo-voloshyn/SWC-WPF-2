using PP.Domain.Models;
using PP.Domain.Models.Enums;
using PP.UI.Shared;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PP.UI.ViewModels;

public class OrderViewModel : ViewModelBase
{
    private ServiceType serviceType;
    private bool isUrdent;
    private Status status;
    private int passportId;

    public ServiceType ServiceType { get => serviceType; set { serviceType = value; } }

    public bool IsUrgent { get => isUrdent; set { isUrdent = value; OnPropertyChanged(nameof(IsUrgent)); } }

    public Status Status { get => status; set { status = value; OnPropertyChanged(nameof(Status)); } }

    public int PassportId { get => passportId; set { passportId = value; OnPropertyChanged(nameof(PassportId)); } }

    public DateTime DateCreated { get; set; }

    public ICommand AddCommand => new Command(p => true, async o =>
    {
        var order = Mapper.Map<Order>(this);
        order.DateCreated = DateTime.Now;

        var orders = await unitOfWork.OrderRepository.GetAll();
        order.Id = orders.Select(e => e.Id).Max() + 1;
        await unitOfWork.OrderRepository.Create(order);
        await unitOfWork.EmployeeOrderRepository.Create(SelectedEmployeeId, order.Id);
        ((Window)o).Close();
    });

    public int SelectedEmployeeId { get; set; }

    public ICommand UpdateOrderCommand => new Command(p => true, async a =>
    {
        await unitOfWork.OrderRepository.Update(Mapper.Map<Order>(this));
    });
}
