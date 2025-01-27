using Bogus;
using PropertyChanged;
using SqlLiteDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SqlLiteDemo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public ObservableCollection<Customer> customers { get; set; } = new ObservableCollection<Customer>();

        public Customer currentCustomer { get; set; }

        
        public MainPageViewModel()
        {
            currentCustomer = generateNewCustomer();
            refresh();
        }

        public Customer generateNewCustomer()
        {
            return new Faker<Customer>().RuleFor(c => c.Name, f => f.Person.FirstName)
                .RuleFor(c => c.Address, f => f.Person.Address.Street)
                .RuleFor(c=> c.Phone, f => f.Person.Phone)
                .Generate();

        }

        public ICommand AddOrUpdateCommand => new Command(() =>
        {


            App.CustomerRepository.Save(currentCustomer);
            App.OrderRepository.Save(new Order { CustomerID = currentCustomer.Id, OrderDate = DateTime.Now });
            var orders = App.OrderRepository.GetAll();
            refresh();
            currentCustomer= generateNewCustomer();
        });

        private void refresh()
        {
            customers.Clear();
           // var customersdb = App.CustomerRepository.GetAll(c => c.Name.StartsWith("V"));
            var customersdb = App.CustomerRepository.GetAll();
            
            customersdb!.ForEach(c => customers.Add(c));  
            currentCustomer = generateNewCustomer();
            
        }

        public ICommand DeleteCommand => new Command(() =>
        {
            App.CustomerRepository.Delete(currentCustomer);

            refresh();
        });
    }
}
