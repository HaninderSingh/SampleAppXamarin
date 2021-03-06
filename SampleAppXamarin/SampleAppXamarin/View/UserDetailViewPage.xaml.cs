﻿using SampleAppXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleAppXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailViewPage : ContentPage
    {
        UserDetailViewModel userDetailViewModel;
        public UserDetailViewPage()
        {
            InitializeComponent();
            userDetailViewModel = new UserDetailViewModel();
            BindingContext = userDetailViewModel;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await userDetailViewModel.GetDetailFromSql();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}