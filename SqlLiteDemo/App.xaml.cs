using SqlLiteDemo.Abstractions;
using SqlLiteDemo.MVVM.Models;
using SqlLiteDemo.MVVM.Views;
using SqlLiteDemo.Repositories;

namespace SqlLiteDemo
{
    public partial class App : Application
    {
        
        //public static CustomerRepository CustomerRepository { get; set; }

        public static IBaseRepository<Customer> CustomerRepository { get; set; }

        public static IBaseRepository<Order> OrderRepository { get; set; }

        public App(IBaseRepository<Customer> cr, IBaseRepository<Order> or)
        {
            InitializeComponent();

            CustomerRepository = cr;
            OrderRepository = or;

            MainPage = new MainPage();
        }
    }
}
