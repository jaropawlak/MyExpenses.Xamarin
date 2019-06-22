using System;
using System.Threading.Tasks;
using MyExpenses.Interfaces;
using MyExpenses.Models;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    public class ItemDetailViewModel : ItemEditorViewModel
    {
       
      
        
        public ItemDetailViewModel(Expense item, IDataStore dataStore):base(dataStore)
        {
            Item = item;
            Title = item?.Category?.Name;

            
        }

        
    }
}
