using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAwesomeDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyContext>());
            using (var db = new MyContext())
            {
                db.Database.Delete();
                db.SaveChanges();
            }
            Console.WriteLine("success");
        }
        static void InsertNation()
        {
            var lst = new List<Nation>
            {
                new Nation
                {
                    Name = "Viet Nam"
                },
                new Nation
                {
                    Name = "America"
                },
                new Nation
                {
                    Name = "Korean"
                }
            };
            using (var db = new MyContext())
            {
                db.Nations.AddRange(lst);
                db.SaveChanges();
            }
        }
        static void InsertSpecialDay()
        {
            var day = new SpecialDay
            {
                Name = "Valentine"
            };
            using (var db = new MyContext())
            {
                db.SpecialDays.Add(day);
                db.SaveChanges();
            }
        }
        static void InsertNationalDay()
        {
            var day = new NationalDay
            {
                NationID = 3,
                SpecialDayID = 1,
                Start = new DateTime(2018, 2, 14)
            };
            using (var db = new MyContext())
            {
                db.NationalDays.Add(day);
                db.SaveChanges();
            }
        }
        static void InsertUser()
        {
            var user = new User
            {
                UserID = "an003",
                Password = "12345abc",
                BirthDate = DateTime.Now,
                NationID = 3,
                PrivateAnswer = "cat"
            };
            using (var db = new MyContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }        
    }
}
