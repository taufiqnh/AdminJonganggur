using Firebase.Database;
using Firebase.Database.Query;

using AdminJonganggur.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AdminJonganggur.Services
{
    public class DBFire
    {
        FirebaseClient client;
        public DBFire()
        {
            client = new FirebaseClient("https://testlogin-fa8bc-default-rtdb.firebaseio.com/");
        }

        public async Task AddPerusahaan(string namap, string username, string password, string alamat, string tentang)
        {
            Perusahaan p = new Perusahaan()
            {
                NamaP = namap,
                Username = username,
                Password = password,
                Alamat = alamat,
                Tentang = tentang,
                
            };
            await client
                .Child("Perusahaan")
                .PostAsync(p);
        }
    }
}
