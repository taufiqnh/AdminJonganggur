﻿using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminJonganggur.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdminJonganggur
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            PerusahaanVM perusahaanVM;
            InitializeComponent();
            perusahaanVM = new PerusahaanVM();
            BindingContext = perusahaanVM;
            CheckConnectivity();
        }
        void CheckConnectivity()
        {
            CheckConnectivityOnStart();
            CheckConnectivityContinuously();
        }
        public void CheckConnectivityOnStart()
        {
            var Conn = CrossConnectivity.Current.IsConnected;
            if (Conn != true)
            {
                DisplayAlert("Message", "Tidak ada sambungan internet", "Oke");
            }

        }

        public void CheckConnectivityContinuously()
        {
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                var Conn = args.IsConnected;
                if (Conn != true)
                {
                    DisplayAlert("Message", "Tidak ada sambungan internet", "Oke");
                }
            };
        }

    }
}
