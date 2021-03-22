using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Diagnostics;

namespace Keyger
{
    public partial class MainPage : ContentPage
    {   
        //Core/RandonGenerateKey
        RandonGenerateKey keygeneration = new RandonGenerateKey();

        private GenerationType Type = GenerationType.pattern;

        public MainPage()
        {
            InitializeComponent();
                                                 //defalt start
            startGenerate(Type, 11);
        }

        private void startGenerate(GenerationType type, byte len)
        {
            keyGenerateDisplayLbl.Text = keygeneration.Generate(type, len);
        }

        private void sliderCtrValue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            sliderValueLbl.Text = Math.Round(sliderCtrValue.Value).ToString();
        }

        //Navigators pages button action >>>>>
        private async void navigateToHelpPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HelpPage());
        }

        private async void navigateToStoragePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new InvetoryPage());
        }

        private async void navigateToSavePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SavePage(this.keyGenerateDisplayLbl.Text));
        }
        //<<<<<

        //send key to suported apps >>>>>
        private void requestShare_Clicked(object sender, EventArgs e)
        {
            Share.RequestAsync(new ShareTextRequest
            {

                Text = keyGenerateDisplayLbl.Text,
                Title = "Enviar key para..."
            });
        }
        //<<<<<

        private void generateKeyBtn_Clicked(object sender, EventArgs e)
        {
            startGenerate(this.Type, (byte)Math.Round(sliderCtrValue.Value));
        }


        //radion buttons action >>>>>
        private void patternRdBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            this.Type = GenerationType.pattern;
        }

        private void simboldRBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            this.Type = GenerationType.symbol;
        }

        private void numericRdBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            this.Type = GenerationType.numeric;
        }

        private void characterpatterRdBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            this.Type = GenerationType.character;
        }

        private void emoticonRdBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            this.Type = GenerationType.emoticon;
        }

        private void binaryRdBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //falta implemetar
            this.Type = GenerationType.binary;
        }
        //<<<<<
    }
}
