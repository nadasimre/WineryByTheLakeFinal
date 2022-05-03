// <copyright file="ExtensionClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Program
{
    using System;
    using System.Collections.Generic;
    using ConsoleTools;
    using WineryByTheLake.Models;

    /// <summary>
    /// Contains the methods that implement the menu.
    /// </summary>
    internal static class ExtensionClass
    {
        /// <summary>
        /// This method can write the input on the console.
        /// </summary>
        /// /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="items">We want to write this object on the console.</param>
        /// <param name="text">This will be the title of the input.</param>
        public static void ToConsole<T>(this IEnumerable<T> items, string text)
        {
            Console.WriteLine("----------" + text + "----------");
            foreach (T item in items)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This method starts the program.
        /// </summary>
        /// <param name="factory">Contains all elements.</param>
        public static void Start(Factory factory)
        {
            foreach (var item in factory.Listing.GetAllSuppliers())
            {
                factory.Listing.WinePriceSum(item);
            }

            Menu(factory);
        }

        private static void Menu(Factory factory)
        {
            var menu = new ConsoleMenu()
                .Add("Listing", () => ListingMenu(factory))
                .Add("Modify", () => Modification(factory))
                .Add("Average Prices", () => AveragePrices(factory))
                .Add("Close", ConsoleMenu.Close);
            menu.Show();
        }

        private static void AveragePrices(Factory factory)
        {
            var menu = new ConsoleMenu()
                .Add("Average wine prices by suppliers", () => factory.Product.AverageWinePriceBySupplier().ToConsole("Average prices of wines by suppliers"))
                .Add("Average wine prices by suppliers with async method", () => factory.Product.AverageWinePriceBySupplierAsync().Result.ToConsole("Average prices of wines by suppliers with async method"))
                .Add("Average wine prices by regions", () => factory.Product.AverageWinePriceByRegion().ToConsole("Average prices of wines by regions"))
                .Add("Average wine prices by regions with async method", () => factory.Product.AverageWinePriceByRegionAsync().Result.ToConsole("Average prices of wines by regions with async method"))
                .Add("Average stock prices by regions", () => factory.Product.AverageSupplierStock().ToConsole("Average prices of stocks by regions"))
                .Add("Average stock prices by regions with async method", () => factory.Product.AverageSupplierStockAsync().Result.ToConsole("Average prices of stocks by regions with async method"))
                .Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void ListingMenu(Factory factory)
        {
            var menu = new ConsoleMenu()
                .Add("Listing all the wines", () => factory.Listing.GetAllWines().ToConsole("Wines"))
                .Add("Listing all the suppliers", () => factory.Listing.GetAllSuppliers().ToConsole("Suppliers"))
                .Add("Listing all the regions", () => factory.Listing.GetAllRegions().ToConsole("Regions"))
                .Add("Listing all the Rose wines", () => factory.Product.Rose().ToConsole("Rose wines"))
                .Add("Listing all the Rose wines with async method", () => factory.Product.RoseAsync().Result.ToConsole("Rose wines with async method"))
                .Add("Listing all the Red wines", () => factory.Product.Red().ToConsole("Red wines"))
                .Add("Listing all the Red wines with async method", () => factory.Product.RedAsync().Result.ToConsole("Red wines with async method"))
                .Add("Listing all the White wines", () => factory.Product.White().ToConsole("White wines"))
                .Add("Listing all the White wines with async method", () => factory.Product.WhiteAsync().Result.ToConsole("White wines with async method"))
                .Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void Modification(Factory factory)
        {
            var menu = new ConsoleMenu()
                .Add("Wine", () => WineModification(factory))
                .Add("Supplier", () => SupplierModification(factory))
                .Add("Region", () => RegionModification(factory))
                .Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void WineModification(Factory factory)
        {
            var menu = new ConsoleMenu()
                .Add("Remove", () => RemoveWine(factory))
                .Add("Insert", () => InsertWine(factory))
                .Add("Change Price", () => ChangeWinePrice(factory))
                .Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void ChangeWinePrice(Factory factory)
        {
            var menu = new ConsoleMenu();
            foreach (var item in factory.Listing.GetAllWines())
            {
                menu.Add(item.Name, () => ChangeThePrice(item.Id, factory));
            }

            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void ChangeThePrice(int id, Factory factory)
        {
            Console.WriteLine("New Price of the wine: ");
            int newPrice = int.Parse(Console.ReadLine());
            try
            {
                factory.Modify.ChangeWinePrice(id, newPrice);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
                ChangeThePrice(id, factory);
            }

            Console.WriteLine("Price changed, press any.");
            Console.ReadLine();
        }

        private static void InsertWine(Factory factory)
        {
            var menu = new ConsoleMenu();
            foreach (var item in factory.Listing.GetAllRegions())
            {
                menu.Add(item.Name, () => InsertWineSuppliers(item.Id, factory));
            }

            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void InsertWineSuppliers(int regionid, Factory factory)
        {
            var menu = new ConsoleMenu();
            foreach (var item in factory.Listing.GetSuppliers(regionid))
            {
                menu.Add(item.Name, () => InsertTheWine(item.Id, factory));
            }

            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void InsertTheWine(int supplierid, Factory factory)
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Color: 1 = White, 2 = Red, 3 = Rose: ");
            int color = int.Parse(Console.ReadLine());
            Console.WriteLine("Sweetness: ");
            string sweetness = Console.ReadLine();
            Console.WriteLine("Price: ");
            int price = int.Parse(Console.ReadLine());

            Wine newWine = new Wine()
            {
                Name = name,
                Color = (ColorE)color,
                Sweetness = sweetness,
                Price = price,
                SupplierID = supplierid,
            };

            try
            {
                factory.Modify.InsertWine(newWine);
            }
            catch (InvalidOperationException x)
            {
                Console.WriteLine(x.Message);
                InsertTheWine(supplierid, factory);
            }

            Console.WriteLine("Wine inserted. Press any.");
            Console.ReadLine();
        }

        private static void RemoveWine(Factory factory)
        {
            var menu = new ConsoleMenu();
            foreach (var item in factory.Listing.GetAllRegions())
            {
                menu.Add(item.Name, () => RemoveWineSuppliers(item.Id, factory));
            }

            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RemoveWineSuppliers(int regionid, Factory factory)
        {
            var menu = new ConsoleMenu();
            foreach (var item in factory.Listing.GetSuppliers(regionid))
            {
                menu.Add(item.Name, () => RemoveWineWines(item.Id, factory));
            }

            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RemoveWineWines(int supplierid, Factory factory)
        {
            var menu = new ConsoleMenu();
            foreach (var item in factory.Listing.GetWines(supplierid))
            {
                menu.Add(item.Name, () => RemoveTheWine(item.Id, factory));
            }

            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RemoveTheWine(int wineid, Factory factory)
        {
            factory.Modify.RemoveWine(wineid);
            Console.WriteLine("Wine removed. Press any.");
            Console.ReadLine();
        }

        private static void SupplierModification(Factory factory)
        {
            var menu = new ConsoleMenu()
               .Add("Remove", () => RemoveSupplier(factory))
               .Add("Insert", () => InsertSupplier(factory))
               .Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void InsertSupplier(Factory factory)
        {
            var menu = new ConsoleMenu();
            foreach (var item in factory.Listing.GetAllRegions())
            {
                menu.Add(item.Name, () => InsertTheSupplier(item.Id, factory));
            }

            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void InsertTheSupplier(int regionid, Factory factory)
        {
            Console.WriteLine("Name: ");
            string supplierName = Console.ReadLine();
            Supplier newSupplier = new Supplier()
            {
                Name = supplierName,
                RegionID = regionid,
            };

            try
            {
                factory.Modify.InsertSupplier(newSupplier);
            }
            catch (InvalidOperationException x)
            {
                Console.WriteLine(x.Message);
                InsertTheSupplier(regionid, factory);
            }

            Console.WriteLine("Supplier inserted. Press any.");
            Console.ReadLine();
        }

        private static void RemoveSupplier(Factory factory)
        {
            var menu = new ConsoleMenu();
            foreach (var item in factory.Listing.GetAllRegions())
            {
                menu.Add(item.Name, () => RemoveSupplierList(item.Id, factory));
            }

            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RemoveSupplierList(int regionid, Factory factory)
        {
            var menu = new ConsoleMenu();
            foreach (var item in factory.Listing.GetSuppliers(regionid))
            {
                menu.Add(item.Name, () => RemoveTheSupplier(item.Id, regionid, factory));
            }

            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RemoveTheSupplier(int supplierid, int regionid, Factory factory)
        {
            try
            {
                factory.Modify.RemoveSupplier(supplierid);
                Console.WriteLine("Supplier removed. Press any.");
                Console.ReadLine();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("This supplier cant be removed, please remove the dependencies first!");
                Console.ReadLine();
                RemoveSupplierList(regionid, factory);
            }
        }

        private static void RegionModification(Factory factory)
        {
            var menu = new ConsoleMenu()
               .Add("Remove", () => RemoveRegion(factory))
               .Add("Insert", () => InsertRegion(factory))
               .Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void InsertRegion(Factory factory)
        {
            Console.WriteLine("Name: ");
            string regionName = Console.ReadLine();
            Region newRegion = new Region()
            {
                Name = regionName,
            };

            try
            {
                factory.Modify.InsertRegion(newRegion);
            }
            catch (InvalidOperationException x)
            {
                Console.WriteLine(x.Message);
                InsertRegion(factory);
            }

            Console.WriteLine("Region inserted. Press any.");
            Console.ReadLine();
        }

        private static void RemoveRegion(Factory factory)
        {
            var menu = new ConsoleMenu();
            foreach (var item in factory.Listing.GetAllRegions())
            {
                menu.Add(item.Name, () => RemoveTheRegion(item.Id, factory));
            }

            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RemoveTheRegion(int regionid, Factory factory)
        {
            try
            {
                factory.Modify.RemoveRegion(regionid);
                Console.WriteLine("Region removed. Press any.");
                Console.ReadLine();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("This region cant be removed, please remove the dependencies first!");
                Console.ReadLine();
                RemoveRegion(factory);
            }
        }
    }
}
