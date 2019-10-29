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
    [Activity(Theme = "@style/MyTheme.AddModel", MainLauncher = false, NoHistory = true, Icon = "@mipmap/ic_launcher")]
    public class AddModelActivity : Activity
    {
        EditText name;
        EditText range;
        EditText zeroToOneHundred;
        EditText power;
        EditText price;
        EditText confirmPassword;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);

            //Get register details from text boxes
            name = FindViewById<EditText>(Resource.Id.txtName);
            range = FindViewById<EditText>(Resource.Id.txtRange);
            zeroToOneHundred = FindViewById<EditText>(Resource.Id.txtZeroToOneHundred);
            power = FindViewById<EditText>(Resource.Id.txtPower);
            price = FindViewById<EditText>(Resource.Id.txtPrice);

            //Trigger click event of Login Button
            var button = FindViewById<FloatingActionButton>(Resource.Id.btnRegister);
            button.Click += DoRegister;

        }

        public void DoRegister(object sender, EventArgs e)
        {
            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fileName = "VehicleFind.db";
            var dbFullPath = Path.Combine(dbFolder, fileName);
            try
            {
                using (var db = new DatabaseContext(dbFullPath))
                {
                    Models model = new Models()
                    {
                        Name = name.Text,
                        Range = range.Text,
                    };

                    var modelId = db.Models.Add(model);
                    db.SaveChanges();

                    Specifications specifications = new Specifications()
                    {
                        Name = "0-100",
                        Value = zeroToOneHundred.Text,
                        ModelId = modelId.Entity.Id

                    };

                    Specifications specifications1 = new Specifications()
                    {
                        Name = "Power",
                        Value = power.Text,
                        ModelId = modelId.Entity.Id

                    };

                    Specifications specifications2 = new Specifications()
                    {
                        Name = "Price",
                        Value = price.Text,
                        ModelId = modelId.Entity.Id
                    };

                    List<Specifications> specificationList = new List<Specifications>() { specifications, specifications1, specifications2 };

                    db.Specifications.AddRange(specifications);
                    db.SaveChanges();

                    Toast.MakeText(this, "Model has been saved!", ToastLength.Long).Show();
                    StartActivity(typeof(LoginActivity));
                }
            }
            catch (Exception ex)
            {

            }
        }

    }

}
