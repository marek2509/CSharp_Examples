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
            Console.WriteLine(Parcel.GetHeader());
            var dataBase = Seeder.SeedParcel();
            //Display(dataBase);
            //LINQ_Where(dataBase);
            //LINQ_Where_Select(dataBase);
            //LINQ_Where_Select_Dto(dataBase);
            //LINQ_Take(dataBase);
            //LINQ_TakeWhile(dataBase);
            //LINQ_Skip(dataBase);
            //LINQ_SkipWhile(dataBase);
            //LINQ_OrderBy(dataBase);
            //LINQ_OrderBy_ThenBy(dataBase);
            //LINQ_Distinct(dataBase);
            //LINQ_Union();
            //LINQ_Intersect();
            Console.WriteLine("'*__*'");
            LINQ_Except();
            Console.WriteLine("'*__*'");

            Console.WriteLine(); 
            Console.ReadKey();
        }



        static void LINQ_Except()
        {
            List<int> a = new List<int> { 1, 2, 2, 3, 4, 5, 5, };
            List<int> b = new List<int> { 3, 4, 5, 5, 6, 7, 7, 8, 9 };
            Console.WriteLine("Collection a");
            Display(a);
            Console.WriteLine("Collection b");
            Display(b);
            var result = a.Except(b);
            Console.WriteLine(" a.Except(b)");
            Display(result); // 1, 2
        }

        static void LINQ_Intersect()
        {
            List<int> a = new List<int> { 1, 2, 2, 3, 4, 5, 5, };
            List<int> b = new List<int> { 3, 4, 5, 5, 6, 7, 7, 8, 9 };
            Console.WriteLine("Collection a");
            Display(a);
            Console.WriteLine("Collection b");
            Display(b);
            var result = a.Intersect(b);
            Console.WriteLine(" a.Intersect(b)");
            Display(result); // 3, 4, 5
        }

        static void LINQ_Union()
        {
            List<int> a = new List<int> { 1, 2, 2, 3, 4, 5, 5 };
            List<int> b = new List<int> { 3, 4, 5, 5, 6, 7, 7, 8, 9 };
            Console.WriteLine("Collection a");
            Display(a);
            Console.WriteLine("Collection b");
            Display(b);
            var result = a.Union(b);
            Console.WriteLine("a.Union(b)");
            Display(result); //1, 2, 3, 4, 5, 6, 7, 8, 9
        }

        static void LINQ_Distinct(IEnumerable<Parcel> parcels)
        {
            Console.WriteLine("DISTINCT");
            var result = parcels.Select(x => x.City).Distinct();
            result.ToList().ForEach(c => Console.WriteLine(string.Join(", ", c)));
        }

        static void LINQ_OrderBy_ThenBy(IEnumerable<Parcel> parcels)
        {
            Console.WriteLine(".OrderBy(x => x.Category).ThenBy(x => x.City).ThenByDescending(p => p.Price)");
            var result = parcels.Take(20)
                .OrderBy(x => x.Category).ThenBy(x => x.City).ThenByDescending(p => p.Price);
            Display(result);
        }

        static void LINQ_OrderBy(IEnumerable<Parcel> parcels)
        {
            Console.WriteLine("parcels.Take(20).OrderBy(x => x.Price)");
            var result = parcels.Take(20).OrderBy(x => x.Price);
            Display(result);
        }

        static void LINQ_SkipWhile(IEnumerable<Parcel> parcels)
        {
            var result = parcels.SkipWhile(p => p.Area < 10001);
            Display(result);
        }

        //SkipLast()
        static void LINQ_Skip(IEnumerable<Parcel> parcels)
        {
            var result = parcels.Skip(5);
            Display(result);
        }

        static void LINQ_TakeWhile(IEnumerable<Parcel> parcels)
        {
            var result = parcels.TakeWhile(p => p.Area != 2000);
            Display(result);
        }

        //TakeLast()
        static void LINQ_Take(IEnumerable<Parcel> parcels)
        {
            var result = parcels.Take(15);
            Display(result);
        }

        static void LINQ_Where_Select_Dto(IEnumerable<Parcel> parcels)
        {
            var resultAreaMin = parcels.Where(p => p.Area > 5000 && p.Category == Category.Building && p.Price > 300_000);

            var resultAnonymusClass = resultAreaMin.Select(p => new ParcelDto { Category = p.Category, Price = p.Price });

            foreach (var parcel in resultAnonymusClass)
            {
                Console.WriteLine($"{parcel.Category} {parcel.Price}");
            }
        }

        static void LINQ_Where_Select(IEnumerable<Parcel> parcels)
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

        static void LINQ_Where(IEnumerable<Parcel> parcels)
        {
            var resultAreaMin = parcels.Where(p => p.Area > 5000 && p.Category == Category.Building && p.Price > 150_000);

            Console.WriteLine("Get more than 5000m2 and price > 150 000\n");
            Display(resultAreaMin);
        }


        //Display in console
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

        static void Display<T>(IEnumerable<T> list)
        {
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
