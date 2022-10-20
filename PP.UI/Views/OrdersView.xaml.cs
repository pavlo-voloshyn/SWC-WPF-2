using PP.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PP.UI.Views
{
    /// <summary>
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        public int EmployeeId { get => (int)GetValue(EmployeeIdProperty); set { SetValue(EmployeeIdProperty, value); } }

        public static readonly DependencyProperty EmployeeIdProperty =
            DependencyProperty.Register("EmployeeId", typeof(int), typeof(OrdersView),
                new PropertyMetadata(0, new PropertyChangedCallback(OnEmployeeIdChanged)));


        public ICommand BackCommand { get => (ICommand)GetValue(BackCommandProperty); set { SetValue(BackCommandProperty, value); } }

        public static readonly DependencyProperty BackCommandProperty =
            DependencyProperty.Register("BackCommand", typeof(ICommand), typeof(OrdersView));


        private static void OnEmployeeIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OrdersView UserControl1Control = d as OrdersView;
            UserControl1Control.OnEmployeeIdChanged(e);
        }

        private void OnEmployeeIdChanged(DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine(e.NewValue.ToString());
            ((OrdersViewModel)DataContext).SelectedIdEmployee = EmployeeId;
        }

        public OrdersView()
        {
            InitializeComponent();
        }
    }
}
