using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyExpenses.Views;
using System.Diagnostics;
using MyExpenses.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyExpenses
{
    public partial class App : Application
    {
        private string _dbPath;
       

        public App(string dbPath)
        {
            _dbPath = dbPath;
            InitializeComponent();
            Debug.WriteLine($"Database located at: {dbPath}");
            DIService.RegisterDIService(_dbPath);
            var pn = new PageNavigator();
            MainPage = pn.MainPage();
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
