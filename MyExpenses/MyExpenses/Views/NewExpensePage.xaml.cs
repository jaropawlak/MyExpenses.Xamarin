using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyExpenses.Models;

namespace MyExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExpensePage : ContentPage
    {
        public Expense Item  {get;set;}
        //date for datepicke
        public DateTime Date
        {
            get
            {
                return Item.Date.Date;
            }
            set
            {
                Item.Date = value.Add(Time);
            }
        }
        // time for timepicker
        public TimeSpan Time
        {
            get
            {
                return Item.Date.TimeOfDay;
            }
            set
            {
                Item.Date = Date.Add(value);
            }
        }
        public NewExpensePage()
        {
            InitializeComponent();

            Item = new Expense
            {
                Date = DateTime.Now,
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);            
            Pop();
        }

        void Pop() //byc moze nie bedzie potrzeby robic pop w ogole
        {
            if (Navigation.ModalStack.Count >0)
                Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            Pop();
        }
    }
}