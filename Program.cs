using Microsoft.VisualBasic.FileIO;

namespace Hotel_Reservation_App
{
    internal class Program
    {
        static List<Customer> customerList = new List<Customer>();
        static List<Admin> adminList = new List<Admin>()
        {
            new Admin {Username = "admin", Password = "admin"}
        };
       
        static void Main(string[] args)
        {
            int option;
            bool running = true;

            do
            {
                //user login and registration
                Console.WriteLine("======== HOTEL RESEVATION SYSTEM ========\n");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("99. Exit");

                Console.Write("Select Option: ");
                option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("===========================================");

                switch (option)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    case 99:
                        Console.WriteLine("Goodbye!!!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Choose from the MENU!");
                        break;
                }

            }while (option != 99);


        }//end of main

        static void Register()
        {
            Customer user = new Customer();
            Console.WriteLine("--USER REGISTRATION--");
            Console.Write("Create Username: ");
            user.Username = Console.ReadLine();
            if (customerList.Any(u => u.Username == user.Username) || adminList.Any(u => u.Username == user.Username))
            {
                Console.WriteLine("Username already exists.");
                return;
            }
            Console.Write("Create Password: ");
            user.Password = ReadPassword();
            customerList.Add(user);

            Console.WriteLine("Account created successfully.");
        }//end of register
        static void Login()
        {
           
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = ReadPassword();

            // Check admin list first
            Admin admin = adminList.Find(u => u.Username == username && u.Password == password);
            // Check customer list
            Customer customer = customerList.Find(u => u.Username == username && u.Password == password);

            if (admin != null)
            {
                Console.WriteLine($"\nWelcome, Admin {admin.Username}!");
                admin.Menu();
                int option = Convert.ToInt32(Console.ReadLine());

            }
            else if (customer != null)
            {
                Console.WriteLine($"\nWelcome, Customer {customer.Username}!");
                customer.Menu();
                int option = Convert.ToInt32(Console.ReadLine());

            }
            else
            {
                Console.WriteLine("\nInvalid username or password.");
            }

        }//end of login

        static void DisplayAll()
        {
            Console.WriteLine("-----New Record------");
            foreach (User user in customerList)
            {
                user.UserDisplay();

            }
            foreach (User adm in adminList)
            {
                adm.UserDisplay();
            }
        }//end of DisplayAll

        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }

            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }







    }//end of class program
}//end of namespace 
