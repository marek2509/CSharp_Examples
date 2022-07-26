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

            Console.WriteLine("\n\n\n Get more than 5000m2\n");
            var getData = GetData(dataBase);
            Display(getData);

            Console.ReadKey();
        }



        static IEnumerable<Parcel> GetData(IEnumerable<Parcel>parcels)
        {
            var resultAreaMin = parcels.Where(p => p.Area > 5000 && p.Category == Category.Building && p.Price > 150000);
            return resultAreaMin;
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
