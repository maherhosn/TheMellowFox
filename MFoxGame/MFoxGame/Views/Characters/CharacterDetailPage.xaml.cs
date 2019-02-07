﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MFoxGame.Models;
using MFoxGame.ViewModels;

namespace MFoxGame.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDetailPage : ContentPage
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private CharacterDetailViewModel _viewModel;

        public CharacterDetailPage(CharacterDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

        public CharacterDetailPage()
        {
            InitializeComponent();

            var data = new Character();
          

            _viewModel = new CharacterDetailViewModel(data);
            BindingContext = _viewModel;
        }


        private async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterEditPage(_viewModel));
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterDeletePage(_viewModel));
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}


/*
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MFoxGame.Models;
using MFoxGame.ViewModels;
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable RedundantExtendsListEntry

namespace MFoxGame.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDetailPage : ContentPage
    {
        private CharacterDetailViewModel _viewModel;

        public CharacterDetailPage(CharacterDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

        public CharacterDetailPage()
        {
            InitializeComponent();

            var data = new Character
            {
                Name = "Item 1",
                Description = "This is an item description.",
                Level = 1
            };

            _viewModel = new CharacterDetailViewModel(data);
            BindingContext = _viewModel;
        }


        public async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterEditPage(_viewModel));
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterDeletePage(_viewModel));
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
*/
