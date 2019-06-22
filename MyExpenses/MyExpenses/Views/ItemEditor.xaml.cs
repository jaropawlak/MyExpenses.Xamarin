using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExpenses.Models;
using MyExpenses.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemEditor : ContentView
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            try
            {
                var model = this.BindingContext as ItemEditorViewModel;
                if (model != null)
                {
                    model.ValidationEvent += async (s, e) => await ValidationError(s, e);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public ItemEditor()
        {            
            InitializeComponent();
            
        }

        public async Task ValidationError(object sender, string property)
        {
            switch (property)
            {
                case nameof(Expense.Amount):
                    await Animate(AmountLabel, AmountEntry);        
                    break;
                case nameof(Expense.Description):
                    await Animate(DescriptionLabel, DescriptionEntry);
                    break;
            }
        }
        private async Task Animate(Label label, Entry entry)
        {
            await label.ScaleTo(2, 50);            
            await entry.RotateTo(10, 50);
            await entry.RotateTo(-10, 50);
            await entry.RotateTo(10, 50);
            await entry.RotateTo(-10, 50);
            await entry.RotateTo(10, 50);
            await entry.RotateTo(0, 50);
            await label.ScaleTo(1, 50);
        }
    }
}
