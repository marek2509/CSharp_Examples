using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Exaples
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataBase = Seeder.SeedParcel();
            //Display(dataBase);
            //GetData_Where(dataBase);
            //GetData_Where_Select(dataBase);
            GetData_Where_Select_Dto(dataBase);

            Console.ReadKey();
        }

        static void GetData_Where_Select_Dto(IEnumerable<Parcel> parcels)
        {
            var resultAreaMin = parcels.Where(p => p.Area > 5000 && p.Category == Category.Building && p.Price > 300_000);

            var resultAnonymusClass = resultAreaMin.Select(p => new ParcelDto { Category = p.Category, Price = p.Price });

            foreach (var parcel in resultAnonymusClass)
            {
                Console.WriteLine($"{parcel.Category} {parcel.Price}");
            }
        }

        static void GetData_Where_Select(IEnumerable<Parcel> parcels)
        {
            var resultAreaMin = parcels.Where(p => p.Area > 5000 && p.Category == Category.Building && p.Price > 300_000);

            var resultAnonymusClass = resultAreaMin.Select(p => new { p.Category, p.Price });
            Console.WriteLine("Result:");
            foreach (var parcel in resultAnonymusClass)
            {
                Console.WriteLine($"{parcel.Category} {parcel.Price}");
            }

            var resultAnonymusClassMyName = resultAreaMin.Select(p => new { Ctg = p.Category, Pr = p.Price });
            Console.WriteLine("Result:");
            foreach (var parcel in resultAnonymusClassMyName)
            {
                Console.WriteLine($"{parcel.Ctg} {parcel.Pr}");
            }
        }

        static void GetData_Where(IEnumerable<Parcel> parcels)
        {
            var resultAreaMin = parcels.Where(p => p.Area > 5000 && p.Category == Category.Building && p.Price > 150_000);

            Console.WriteLine("Get more than 5000m2 and price > 150 000\n");
            Display(resultAreaMin);
        }

        static void Display(IEnumerable<Parcel> parcels)
        {
            foreach (var item in parcels)
            {
                Console.WriteLine(item);
            }
        }

        static void Display(Parcel parcel)
        {
            Console.WriteLine(parcel);
        }
    }
}
