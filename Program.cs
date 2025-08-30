using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace C__Final_Project
{
    internal class Program
    {
        public static string[] usernames = { "admin", "staff" };
        public static string[] passwords = { "1234", "0000" };
        public static string[] categories = new string[5];
        public static int categoryCount = 0;
        public static string[] meals = new string[100];
        public static double[] prices = new double[100];
        public static string[] mealCategories = new string[100];
        public static int mealCount = 0;
        public static string[] orderMeals = new string[50];
        public static double[] orderPrices = new double[50];
        public static int orderCount = 0;

        public static bool Login()
        {
            while (true)
            {
                Console.WriteLine("=== Welcome to Qudrat Restaurant ===");
                Console.Write("Enter username: ");
                string user = Console.ReadLine();
                Console.Write("Enter password: ");
                string pass = Console.ReadLine();
                for (int i = 0; i < usernames.Length; i++)
                {
                    if (user == usernames[i] && pass == passwords[i])
                    {
                        Console.WriteLine("Login Successful! \n");
                        return true;
                    }
                }
                Console.WriteLine("Invalid Account, please try again.\n");
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine("\n Restaurant Menu: ");
            for (int i = 0; i < categoryCount; i++)
            {
                Console.WriteLine("[" + categories[i] + "]");

                for (int j = 0; j < mealCount; j++)
                {
                    if (mealCategories[j] == categories[i])
                    {
                        Console.WriteLine("-" + meals[j] + " : $" + prices[j].ToString("0.00"));
                    }
                }
                Console.WriteLine();
            }
        }
        public static void AddCategory()
        {
            Console.Write("Enter new category: ");
            string newCategory = Console.ReadLine();
            categories[categoryCount] = newCategory;
            categoryCount++;
            Console.WriteLine("Category added!");
        }
        public static void AddMeal()
        {
            Console.Write("Enter meal name: ");
            meals[mealCount] = Console.ReadLine();

            Console.Write("Enter price: ");
            prices[mealCount] = double.Parse(Console.ReadLine());

            Console.Write("Enter category: ");
            string category = Console.ReadLine();
            mealCategories[mealCount] = category;
            bool categoryExists = false;
            for (int i = 0; i < categoryCount; i++)
            {
                if (categories[i] == category)
                {
                    categoryExists = true;
                    break;
                }
            }
            if (!categoryExists)
            {
                categories[categoryCount] = category;
                categoryCount++;
            }
            mealCount++;
            Console.WriteLine("Meal added!");
        }
        public static void CreateOrder()
        {
            orderCount = 0;
            Console.WriteLine("--- Create New Order ---");
            while (true)
            {

                Console.Write("Pick your meals and drinks! Type 'done' when done : ");
                string input = Console.ReadLine();

                if (input == "done") break;

                bool found = false;
                for (int i = 0; i < mealCount; i++)
                {
                    if (meals[i] == input)
                    {
                        orderMeals[orderCount] = meals[i];
                        orderPrices[orderCount] = prices[i];
                        orderCount++;
                        Console.WriteLine(meals[i] + " added to order.");
                        found = true;
                        break;
                    }
                }
                if (!found) Console.WriteLine("Meal not found!");
            }
            Console.WriteLine("Order created successfully!");
        }

        public static void CreateInvoice()
        {

            Console.WriteLine("\n--- Invoice ---");
            Console.WriteLine("Qudrat Restaurant\n--------------------------");
            double total = 0;
            for (int i = 0; i < orderCount; i++)
            {
                Console.WriteLine(orderMeals[i] + " $" + orderPrices[i].ToString("0.00"));
                total += orderPrices[i];
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine("TOTAL: $" + total.ToString("0.00"));
            Console.WriteLine("Thank you for dining with us!");
        }
        public static void CloseSystem()
        {
            Console.WriteLine("Goodbye! Please visit us again! ^_^");
        }
        public static void Main(string[] args)
        {
            if (!Login()) return;
            string[] defaultCategories = { "Drinks", "Main Course", "Desserts", "Appetizers" };
            string[] defaultMeals = { "Water", "Cola", "Natural Juice ", "Burger", "Pizza" ,
"Pasta", "Cake", "Cookies", "Fries", "Garlic bread"};
            double[] defaultPrices = { 1.0, 2.0, 3.0, 5.5, 6.5, 6.0, 3.0, 1.5, 1.5, 2.0 };
            string[] defaultMealCategories =
            {

"Drinks", "Drinks", "Drinks", "Main Course", "Main Course", "Main Course",
"Desserts",
"Desserts", "Appetizers", "Appetizers"
};
            for (int i = 0; i < defaultCategories.Length; i++)
            {
                categories[i] = defaultCategories[i];
            }
            categoryCount = defaultCategories.Length;
            for (int i = 0; i < defaultMeals.Length; i++)
            {
                meals[i] = defaultMeals[i];
                prices[i] = defaultPrices[i];
                mealCategories[i] = defaultMealCategories[i];
            }
            mealCount = defaultMeals.Length;
            string choice;
            do
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Display Menu");
                Console.WriteLine("2. Add Meal Category");
                Console.WriteLine("3. Add Meal");
                Console.WriteLine("4. Create Order");
                Console.WriteLine("5. Create Invoice");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                choice = Console.ReadLine();
                if (choice == "1") DisplayMenu();
                else if (choice == "2") AddCategory();
                else if (choice == "3") AddMeal();
                else if (choice == "4") CreateOrder();
                else if (choice == "5") CreateInvoice();
                else if (choice == "6") CloseSystem();
                else Console.WriteLine("Invalid choice!");
            } while (choice != "6");
            Console.ReadKey();
        }

    }

}