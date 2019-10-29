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
    [Activity(Theme = "@style/MyTheme.Register", MainLauncher = false, NoHistory = true, Icon = "@mipmap/ic_launcher")]
    public class RegisterActivity : Activity 
    {
        EditText firstName;
        EditText surname;
        EditText cellNumber;
        EditText email;
        EditText password;
        EditText confirmPassword;


        protected  override void OnCreate(Bundle savedInstanceState) 
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);

            //Get register details from text boxes
            firstName = FindViewById<EditText>(Resource.Id.txtFirstName);
            surname = FindViewById<EditText>(Resource.Id.txtSurname);
            cellNumber = FindViewById<EditText>(Resource.Id.txtCellNumber);
            email = FindViewById<EditText>(Resource.Id.txtEmail);
            password = FindViewById<EditText>(Resource.Id.txtPassword);
            confirmPassword = FindViewById<EditText>(Resource.Id.txtConfirmPassword);


            //Trigger click event of Login Button
            var button = FindViewById<FloatingActionButton>(Resource.Id.btnRegister);
            button.Click += DoRegister;

}

        public void DoRegister(object sender, EventArgs e)
        {                      
            if (LoginService.LoginCheck(email.Text, password.Text))
            {
                Toast.MakeText(this, "Login successfully done!", ToastLength.Long).Show();
                StartActivity(typeof(MainActivity));
            }
            else
            {
                Toast.MakeText(this, "Wrong credentials found!", ToastLength.Long).Show();
            }
        }

    }
}