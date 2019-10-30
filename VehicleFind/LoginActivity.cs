using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Microsoft.EntityFrameworkCore;
using VehicleFind.Entities;
using VehicleFind.Entities.DatabaseContext;
using VehicleFind.Services;
using VehicleFind.Services.Interfaces;

namespace VehicleFind
{
    [Activity(Theme = "@style/MyTheme.Login", MainLauncher = true, NoHistory = true, Icon = "@mipmap/ic_launcher")]
    public class LoginActivity : Activity 
    {
        EditText email;
        EditText password;

        protected async override void OnCreate(Bundle savedInstanceState) 
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);

            //Get email & password values from edit text
            email = FindViewById<EditText>(Resource.Id.txtEmail);
            password = FindViewById<EditText>(Resource.Id.txtPassword);

            //Trigger click event of Login Button
            var button = FindViewById<FloatingActionButton>(Resource.Id.btnLogin);
            button.Click += DoLogin;

            var databaseCreate = await DatabaseService.CreateDatabase();          
}

        public void DoLogin(object sender, EventArgs e)
        {                      
            if (LoginService.LoginCheck(email.Text, password.Text))
            {
                Toast.MakeText(this, "Login successfully done!", ToastLength.Long).Show();
                Intent.PutExtra("user", email.Text);
                StartActivity(typeof(MainActivity));
            }
            else
            {
                Toast.MakeText(this, "Wrong credentials found!", ToastLength.Long).Show();
            }
        }

    }
}