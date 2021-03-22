using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Keyger
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavePage : ContentPage
    {
        public SavePage(string generated_key)
        {
            InitializeComponent();

            this.keyGenerateDisplayLbl.Text = generated_key;
            this.creationDateDisplayLbl.Text = DateTime.Now.ToString("d");
        }

        private async void cancelBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}