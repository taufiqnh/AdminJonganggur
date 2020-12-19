using MvvmHelpers;
using AdminJonganggur.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AdminJonganggur.Services;
using System.ComponentModel;
using AdminJonganggur;

namespace AdminJonganggur.ViewModel
{
    public class PerusahaanVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string namap;
        public string NamaP
        {
            get { return namap; }
            set
            {
                namap = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NamaP"));
            }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string alamat;
        public string Alamat
        {
            get { return alamat; }
            set
            {
                alamat = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Alamat"));
            }
        }
        private string tentang;
        public string Tentang
        {
            get { return tentang; }
            set
            {
                tentang = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Tentang"));
            }
        }
        public Command AddPerusahaanCommand
        {
            get
            {
                return new Command(() =>
                {
                    Daftar();
                });
            }
        }
        private async void Daftar()
        {
            //null or empty field validation, check weather email and password is null or empty    

            if (string.IsNullOrEmpty(NamaP) || string.IsNullOrEmpty(Username) ||
                string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Alamat) ||
                string.IsNullOrEmpty(Tentang))
                await App.Current.MainPage.DisplayAlert("Peringatan", "Harap isi semua data!", "OK");
            else
            {
                //call AddUser function which we define in Firebase helper class    
                var user = await FirebaseHelper.AddPerusahaan(NamaP, Username, Password, Alamat, Tentang);
                //AddUser return true if data insert successfuly     
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("Daftar Sukses", "", "Ok");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Daftar Gagal", "OK");

            }
        }
    }
}
