
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Moodify.Views
{

    public class Product
    {
        public String price { get; set; }
        public String name { get; set; }
        public long id { get; set; }
        public String imageName { get; set; }
        public String description { get; set; }
    }
    class ListViewData
    {
        
        public static ObservableCollection<Product> ProductList = new ObservableCollection<Product>
        {
            new Product { price="10.99", name="Butter Chicken", id = 5, description= "Pleb dish", imageName = "food"}
        };
        

    }
}

