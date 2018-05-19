using System.Collections.Generic;
using System.Linq;
using ToyApp.Data.Data;

namespace ToyApp.Web.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Toys.Any())
            {
                context.AddRange
                (
                new Toy
                {
                    ToyName = "Convertible Car",
                    Description = "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." +
                              "Power it up and let it go!",
                    ImagePath = "car-1.jpg",
                    UnitPrice = 22.50,
                    Category = Categories["Cars"]
                },
                new Toy
                {
                    ToyName = "Old-time Car",
                    Description = "There's nothing old about this toy car, except it's looks. Compatible with other old toy cars.",
                    ImagePath = "car-2.jpg",
                    UnitPrice = 15.95,
                    Category = Categories["Cars"]
                },
                new Toy
                {
                    ToyName = "Fast Car",
                    Description = "Yes this car is fast, but it also floats in water.",
                    ImagePath = "car-3.jpg",
                    UnitPrice = 32.99,
                    Category = Categories["Cars"]
                },
                new Toy
                {
                    ToyName = "Super Fast Car",
                    Description = "Use this super fast car to entertain guests. Lights and doors work!",
                    ImagePath = "car-4.jpg",
                    UnitPrice = 8.95,
                    Category = Categories["Cars"]
                },
                new Toy
                {
                    ToyName = "Old Style Racer",
                    Description = "This old style racer can fly (with user assistance). Gravity controls flight duration." +
                                  "No batteries required.",
                    ImagePath = "car-5.jpg",
                    UnitPrice = 34.95,
                    Category = Categories["Cars"]
                },
                new Toy
                {
                    ToyName = "Ace Plane",
                    Description = "Authentic airplane toy. Features realistic color and details.",
                    ImagePath = "plane-1.svg",
                    UnitPrice = 95.00,
                    Category = Categories["Planes"]
                },
                new Toy
                {
                    ToyName = "Glider",
                    Description = "This fun glider is made from real balsa wood. Some assembly required.",
                    ImagePath = "plane-2.jpg",
                    UnitPrice = 4.95,
                    Category = Categories["Planes"]
                },
                new Toy
                {
                    ToyName = "Paper Plane",
                    Description = "This paper plane is like no other paper plane. Some folding required.",
                    ImagePath = "plane-3.jpg",
                    UnitPrice = 2.95,
                    Category = Categories["Planes"]
                },
                new Toy
                {
                    ToyName = "Propeller Plane",
                    Description = "Rubber band powered plane features two wheels.",
                    ImagePath = "plane-4.jpg",
                    UnitPrice = 32.95,
                    Category = Categories["Planes"]
                },
                new Toy
                {
                    ToyName = "Early Truck",
                    Description = "This toy truck has a real gas powered engine. Requires regular tune ups.",
                    ImagePath = "truck-1.png",
                    UnitPrice = 15.00,
                    Category = Categories["Planes"]
                },
                new Toy
                {
                    ToyName = "Fire Truck",
                    Description = "You will have endless fun with this one quarter sized fire truck.",
                    ImagePath = "truck-2.jpg",
                    UnitPrice = 26.00,
                    Category = Categories["Trucks"]
                },
                new Toy
                {
                    ToyName = "Big Truck",
                    Description = "This fun toy truck can be used to tow other trucks that are not as big.",
                    ImagePath = "truck-3.jpg",
                    UnitPrice = 29.00,
                    Category = Categories["Trucks"]
                },
                 new Toy
                 {
                     ToyName = "Big Truck",
                     Description = "This fun toy truck can be used to tow other trucks that are not as big.",
                     ImagePath = "truck-4.jpg",
                     UnitPrice = 29.00,
                     Category = Categories["Trucks"]
                 },
                  new Toy
                  {
                      ToyName = "Big Truck",
                      Description = "This fun toy truck can be used to tow other trucks that are not as big.",
                      ImagePath = "truck-5.jpg",
                      UnitPrice = 29.00,
                      Category = Categories["Trucks"]
                  },
                   new Toy
                   {
                       ToyName = "Big Truck",
                       Description = "This fun toy truck can be used to tow other trucks that are not as big.",
                       ImagePath = "truck-5.jpg",
                       UnitPrice = 29.00,
                       Category = Categories["Trucks"]
                   },
                    new Toy
                    {
                        ToyName = "Big Truck",
                        Description = "This fun toy truck can be used to tow other trucks that are not as big.",
                        ImagePath = "truck-6.jpg",
                        UnitPrice = 29.00,
                        Category = Categories["Trucks"]
                    },
                     new Toy
                     {
                         ToyName = "Big Truck",
                         Description = "This fun toy truck can be used to tow other trucks that are not as big.",
                         ImagePath = "truck-7.png",
                         UnitPrice = 29.00,
                         Category = Categories["Trucks"]
                     },
                new Toy
                {
                    ToyName = "Big Ship",
                    Description = "Is it a boat or a ship. Let this floating vehicle decide by using its " +
                                  "artifically intelligent computer brain!",
                    ImagePath = "boat-1.png",
                    UnitPrice = 95.00,
                    Category = Categories["Boats"]
                },
                new Toy
                {
                    ToyName = "Paper Boat",
                    Description = "Floating fun for all! This toy boat can be assembled in seconds. Floats for minutes!" +
                                  "Some folding required.",
                    ImagePath = "boat-2.jpg",
                    UnitPrice = 4.95,
                    Category = Categories["Boats"]
                },
                new Toy
                {
                    ToyName = "Sail Boat",
                    Description = "Put this fun toy sail boat in the water and let it go!",
                    ImagePath = "boat-3.jpg",
                    UnitPrice = 42.95,
                    Category = Categories["Boats"]
                },
                new Toy
                {
                    ToyName = "Rocket",
                    Description = "This fun rocket will travel up to a height of 200 feet.",
                    ImagePath = "rocket-1.png",
                    UnitPrice = 122.95,
                    Category = Categories["Rockets"]
                },
                new Toy
                {
                    ToyName = "Rocket",
                    Description = "This fun rocket will travel up to a height of 200 feet.",
                    ImagePath = "rocket-2.jpg",
                    UnitPrice = 122.95,
                    Category = Categories["Rockets"]
                }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {

                        new Category
                        {
                            CategoryName = "Cars"
                        },
                        new Category
                        {
                            CategoryName = "Planes"
                        },
                        new Category
                        {
                            CategoryName = "Trucks"
                        },
                        new Category
                        {
                            CategoryName = "Boats"
                        },
                        new Category
                        {
                            CategoryName = "Rockets"
                        },
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}

