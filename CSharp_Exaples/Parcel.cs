using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Exaples
{
    enum Category
    {
        Arable,
        Forest,
        Meadow,
        Building
    }

    internal class Parcel
    {
        public int Id { get; set; }
        public int Area { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public string City { get; set; }

        private static int idGenerate = 0;

        public Parcel(int area, double price, Category ctg, string city)
        {
            Id = idGenerate++;
            Area = area;
            Price = price;
            Category = ctg;
            City = city;
        }

        public override string ToString()
        {
            return
                    $"{"",-5} | " +
                    $"{Id,-5} | " +
                    $"{Area,-10} | " +
                    $"{Price,-10} | " +
                    $"{Category,-11} | " +
                    $"{City,-16} | ";
        }
    }
}
