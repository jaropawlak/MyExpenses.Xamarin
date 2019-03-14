using MyExpenses.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyExpenses.Controls
{
    
    public partial class FALabel : Label
    {
        private string _text;
        public string Icon
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
               base.Text = typeof(FontAwesome).GetField(value).GetValue(null).ToString();                
            }
        }

        public FALabel()
        {
            FontFamily = GetFontFamily();
        }
        private string GetFontFamily()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS: return "FontAwesome";
                case Device.Android: return "fontawesome-webfont.ttf#FontAwesome Regular";
                case Device.UWP: return "/Assets/fontawesome-webfont.ttf#FontAwesome";
                default: return null;
            }
        }

    }
}