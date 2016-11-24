
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Moodify.ViewModels
{
    public class Product
    {
        public double price { get; set; }
        public String name { get; set; }
        public long id { get; set; }
        public String imageName { get; set; }
        public String description { get; set; }
        public String easyName { get; set; }
    }
   
   public class ListViewData
    {
        public static ObservableCollection<Product> FavouriteList = new ObservableCollection<Product>();
        public static ObservableCollection<Product> CartList = new ObservableCollection<Product>();
        public static HashSet<Product> productlist = new HashSet<Product>() { };
        public static Dictionary<string, Product> totalproductlist = new Dictionary<string, Product>();
    
        public static void addToFavourites(Product p)
        {
            FavouriteList.Add(p);  
        }


        public static ObservableCollection<Product> ProductList = new ObservableCollection<Product>
        {
            new Product { price=10.99, name="Risotto and greens", id = 5, description= "A gourmet mushroom risotto that is topped with a nutritious serving of potatoes, carrots and asparagus.", imageName = "risotto", easyName="risotto"},
            new Product {price=10.99, name="Steak and Veggies",id=6,description ="Delicious eye fillet steak with vegetables on the side.", imageName="steak",easyName="steak" },
            new Product {price=10.99,name="Beef burger", id=7, description = "A beef burger with a flamegrilled patty topped with caramelized onions, swiss cheese and tomato relish.",easyName = "beef_burger", imageName="beef_burger" }
        };

        public static ObservableCollection<Product> DrinkList = new ObservableCollection<Product>
        {
            new Product {price =3.99, name="Soda Cola", id=7,description="Have a refreshing drink of Soda-Cola, Taste the feeling." ,imageName="coca_cola", easyName="coca_cola"},
            new Product {price =6.99,name="Kiwi Berry Smoothie",id=8, description="Healthy and delicious smoothie, the perfect drink to replenish the mind.",imageName="smoothie",easyName="smoothie" },
            new Product {price =3.99,name="Belgian fries",id=9,description="Potato fries that are cooked to perfection extremely crunchy, served with ketchup", imageName="fries",easyName="fries" }
        };

        public static void populateHashMap()
        {
            if (totalproductlist.Count == 0)
            {
                foreach (Product x in ProductList)
                {
                    totalproductlist.Add(x.easyName, x);
                }

                foreach (Product x in DrinkList)
                {
                    totalproductlist.Add(x.easyName, x);
                }
            }
        }

    }
}

