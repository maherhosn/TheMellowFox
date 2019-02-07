using System;

using MFoxGame.Views;   

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MFoxGame.Views.Battle;

namespace MFoxGame.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OpeningPage : ContentPage
	{
		public OpeningPage ()
		{
			InitializeComponent ();
		}

        private async void NewGameButton_Command(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AutoBattlePage());
        }

        private async void ResumeBattleButton_Command(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AutoBattlePage());
        }
    }
}