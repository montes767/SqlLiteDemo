using SqlLiteDemo.MVVM.Views;
using SqlLiteDemo.Repositories;

namespace SqlLiteDemo
{
    public partial class App : Application
    {
        
        public static CustomerRepository CustomerRepository { get; set; }

        public App(CustomerRepository cr)
        {
            InitializeComponent();

            CustomerRepository = cr;

            MainPage = new MainPage();
        }
    }
}
