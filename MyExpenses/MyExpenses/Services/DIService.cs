﻿using MyExpenses.Models;
using MyExpenses.ViewModels;
using MyExpenses.Views;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyExpenses.Services
{
    public class DIService
    {
        static Container container { get; set; }
        public static void RegisterDIService(string dbPath)
        {
            container = new Container();

            container.Register<IDataStore>(() => new DatabaseRepository(dbPath));


            container.Verify();
        }


        public static T Resolve<T>() where T: class
        {
            return container.GetInstance<T>();
        }
    }
}
