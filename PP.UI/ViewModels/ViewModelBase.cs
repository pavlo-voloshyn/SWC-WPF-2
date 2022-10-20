using AutoMapper;
using PP.Domain.DAL;
using PP.UI.Shared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PP.UI.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    public int Id { get; set; }

    protected UnitOfWork unitOfWork => UnitOfWork.GetInstance();

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    protected Mapper Mapper => new(PassportPointProfile.Initialize());
}
