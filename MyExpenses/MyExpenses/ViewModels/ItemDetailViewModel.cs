using System;
using System.Threading.Tasks;
using MyExpenses.Interfaces;
using MyExpenses.Models;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemEditorViewModel EditorModel { get; set; }
      
        
        public ItemDetailViewModel(Expense item, IDataStore dataStore):base(dataStore)
        {
            EditorModel = new ItemEditorViewModel(dataStore, item);
            Title = item?.Category?.Name;          

           
        }

       
    }
}
