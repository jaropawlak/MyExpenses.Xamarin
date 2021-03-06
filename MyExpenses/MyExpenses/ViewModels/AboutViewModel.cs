﻿using MyExpenses.Interfaces;
using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(IDataStore dataStore):base(dataStore)
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}