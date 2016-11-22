
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

        public static void addToFavourites(Product p)
        {
            
        }


        public static ObservableCollection<Product> ProductList = new ObservableCollection<Product>
        {
            new Product { price=10.99, name="Butter Chicken", id = 5, description= "Pleb dish", imageName = "food", easyName="butter_chicken"}
        };
        

    }
}

