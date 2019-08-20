
using MyExpenses.Interfaces;
using MyExpenses.Models;
using MyExpenses.ViewModels;
using MyExpenses.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MyExpenses.Services
{
    public class DIService
    {
        public static void RegisterDIService(string dbPath)
        {
            PageNavigator.dbPath = dbPath;
            
        }


       
    }
}
