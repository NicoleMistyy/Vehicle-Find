using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.EntityFrameworkCore;
using VehicleFind.Entities;
using VehicleFind.Entities.DatabaseContext;
using VehicleFind.Services;
using VehicleFind.Services.Interfaces;
.
using Xamarin.Android;


namespace VehicleFind.Services
{
    public static class DatabaseService
    {
        public static async Task<bool> CreateDatabase()
        {
            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fileName = "VehicleFind.db";
            var dbFullPath = Path.Combine(dbFolder, fileName);
            try
            {
                using (var db = new DatabaseContext(dbFullPath))
                {
                    await db.Database.MigrateAsync(); //We need to ensure the latest Migration was added. This is different than EnsureDatabaseCreated.

                    Users user1 = new Users()
                    {
                        FirstName = "User1",
                        Surname = "UserSurname1",
                        CellNumber = "0791097076",
                        Email = "user1@gmail.com",
                        Password = "Password1"
                    };


                    Users user2 = new Users()
                    {
                        FirstName = "User2",
                        Surname = "UserSurname2",
                        CellNumber = "0791097077",
                        Email = "user2@gmail.com",
                        Password = "Password2"
                    };


                    Users user3 = new Users()
                    {
                        FirstName = "User3",
                        Surname = "UserSurname3",
                        CellNumber = "0791097078",
                        Email = "user3@gmail.com",
                        Password = "Password3"
                    };


                  
                    List<Users> usersList = new List<Users>() { user1, user2, user3 };

                    if (await db.User.CountAsync() < 3)
                    {
                        await db.User.AddRangeAsync(usersList);
                        await db.SaveChangesAsync();
                    }

                    if (db.Models.Where(r => r.Range == "320i").FirstOrDefault() == null)
                    {
                        Models model = new Models()
                        {
                            Name = "Bmw",
                            Range = "320i"
                        };

                        var modelSaved = db.Models.Add(model);

                        Specifications specifications = new Specifications()
                        {
                            Name = "0-100",
                            Value = "7.1s",
                            ModelId = modelSaved.Entity.Id

                        };

                        Specifications specifications1 = new Specifications()
                        {
                            Name = "Power",
                            Value = "170hp",
                            ModelId = modelSaved.Entity.Id

                        };

                        Specifications specifications2 = new Specifications()
                        {
                            Name = "Torque",
                            Value = "320nm",
                            ModelId = modelSaved.Entity.Id

                        };

                        List<Specifications> specificationList = new List<Specifications>() { specifications, specifications1, specifications2 };

                        db.Specifications.AddRange(specifications);
                        await db.SaveChangesAsync();
                    }

                    if (db.Models.Where(r => r.Range == "C250").FirstOrDefault() == null)
                    {
                        Models model = new Models()
                        {
                            Name = "Mercedes",
                            Range = "C250"
                        };

                        var modelSaved = db.Models.Add(model);

                        Specifications specifications = new Specifications()
                        {
                            Name = "0-100",
                            Value = "6.8s",
                            ModelId = modelSaved.Entity.Id

                        };

                        Specifications specifications1 = new Specifications()
                        {
                            Name = "Power",
                            Value = "220hp",
                            ModelId = modelSaved.Entity.Id

                        };

                        Specifications specifications2 = new Specifications()
                        {
                            Name = "Torque",
                            Value = "340nm",
                            ModelId = modelSaved.Entity.Id
                        };

                        List<Specifications> specificationList = new List<Specifications>() { specifications, specifications1, specifications2 };

                        db.Specifications.AddRange(specifications);
                        await db.SaveChangesAsync();
                    }

                    if (db.Models.Where(r => r.Range == "A4 1.8").FirstOrDefault() == null)
                    {
                        Models model = new Models()
                        {
                            Name = "Audi",
                            Range = "A4 1.8"
                        };

                        var modelSaved = db.Models.Add(model);

                        Specifications specifications = new Specifications()
                        {
                            Name = "0-100",
                            Value = "6.8s",
                            ModelId = modelSaved.Entity.Id
                        };

                        Specifications specifications1 = new Specifications()
                        {
                            Name = "Power",
                            Value = "220hp",
                            ModelId = modelSaved.Entity.Id
                };

                        Specifications specifications2 = new Specifications()
                        {
                            Name = "Torque",
                            Value = "340nm",
                            ModelId = modelSaved.Entity.Id
                    };

                        List<Specifications> specificationList = new List<Specifications>() { specifications, specifications1, specifications2 };

                        
                        db.Specifications.AddRange(specifications);
                        await db.SaveChangesAsync();
                    }


                    //var catsInTheBag = await db.Cats.ToListAsync();

                    //foreach (var cat in catsInTheBag)
                    //{
                    //    textView.Text += $"{cat.CatId} - {cat.Name} - {cat.MeowsPerSecond}" + System.Environment.NewLine;
                    //}
                }
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}