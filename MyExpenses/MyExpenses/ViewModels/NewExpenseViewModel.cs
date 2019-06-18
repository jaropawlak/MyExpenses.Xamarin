using MyExpenses.Interfaces;
using MyExpenses.Models;
using MyExpenses.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    public class NewExpenseViewModel : BaseViewModel
    {
        public ItemEditorViewModel EditorModel { get; set; }
       
       

       
        private readonly IProgressCalculator _progressCalculator;
       
       

        private ObservableCollection<BudgetProgress> _progress;
        public ObservableCollection<BudgetProgress> Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                SetProperty(ref _progress, value);
            }
        }
      

      
        public NewExpenseViewModel(IDataStore dataStore, IProgressCalculator progressCalculator) :base (dataStore)
        {
            try
            {
                _progressCalculator = progressCalculator;
                EditorModel = new ItemEditorViewModel(dataStore);
                var _task = _progressCalculator.CalculateProgress();

                MessagingCenter.Subscribe<BudgetsViewModel>(this, Constants.CategoriesChanged, async (sender) =>
                {
                    Progress = new ObservableCollection<BudgetProgress>(await _progressCalculator.CalculateProgress());
                });
                MessagingCenter.Subscribe<ItemEditorViewModel>(this, Constants.ExpenseChanged, async (sender) =>
                {
                    Progress = new ObservableCollection<BudgetProgress>(await _progressCalculator.CalculateProgress());
                });
                Progress = new ObservableCollection<BudgetProgress>(_task.Result);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
              
       
    }
    

}
