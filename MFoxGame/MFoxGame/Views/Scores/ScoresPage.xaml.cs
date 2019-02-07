using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MFoxGame.Models;
using MFoxGame.ViewModels;

namespace MFoxGame.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoresPage : ContentPage
    {
        private ScoresViewModel _viewModel;

        public ScoresPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = ScoresViewModel.Instance;
        }

    }
}