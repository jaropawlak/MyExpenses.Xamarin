using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyExpenses.Views;
using MyExpenses.Models;
using System.Diagnostics;
using MyExpenses.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyExpenses
{
    public partial class App : Application
    {        
        public App(string dbPath)
        {
            InitializeComponent();
            Debug.WriteLine($"Database located at: {dbPath}");
            DIService.RegisterDIService(dbPath);
            MainPage = DIService.Resolve<MainPage>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
