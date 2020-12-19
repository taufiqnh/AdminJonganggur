using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminJonganggur.Models;

namespace AdminJonganggur.ViewModel
{
    public class FirebaseHelper
    {
        //Connect app with firebase using API Url  
        public static FirebaseClient firebase = new FirebaseClient("https://testlogin-fa8bc-default-rtdb.firebaseio.com/");

        //Inser a user    
        public static async Task<bool> AddPerusahaan(string namap, string username, string password, string alamat, string tentang)
        {
            try
            {
                await firebase
                .Child("Perusahaan")
                .PostAsync(new Perusahaan() { NamaP = namap, Username = username, Password = password, Alamat = alamat, Tentang = tentang });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

    }
}

