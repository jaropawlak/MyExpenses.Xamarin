using Autofac;
using Autofac.Core;
using MyExpenses.Interfaces;
using MyExpenses.Models;
using MyExpenses.ViewModels;
using MyExpenses.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyExpenses.Services
{
    public class DIService
    {
        static IContainer container { get; set; }
        public static void RegisterDIService(string dbPath)
        {
            var builder = new ContainerBuilder();

            builder.Register(a => new DatabaseRepository(dbPath)).As<IDataStore>();
            builder.RegisterType<ProgressCalculator>().As<IProgressCalculator>();

            builder.RegisterType<NewExpenseViewModel>();
            builder.RegisterType<BudgetsViewModel>();
            builder.RegisterType<ItemsViewModel>();
            builder.RegisterType<ItemDetailViewModel>();

            builder.RegisterType<NewExpensePage>();
            builder.RegisterType<BudgetsPage>();
            builder.RegisterType<ItemsPage>();
            builder.RegisterType<ItemDetailPage>();
            builder.RegisterType<MainPage>();
            builder.RegisterType<AboutPage>();

            builder.RegisterType<PageNavigator>();

            container = builder.Build();

        }


        public static T Resolve<T>() where T: class
        {
            return container.Resolve<T>();
        }
    }
}
