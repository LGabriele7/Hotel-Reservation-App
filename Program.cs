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
        //Code for the booking list
        public static List<Booking> bookingList = new List<Booking>();
        static int option;

        static void Main(string[] args)
        {
            
            do
            {
                try
                {
                    //user login and registration
                    Console.WriteLine("======== HOTEL RESEVATION SYSTEM ========");
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
                            Console.WriteLine("Please select a valid menu option");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                

            } while (option != 99);


        }//end of main

        static void Register()
        {
            Customer user = new Customer();
            Console.WriteLine("--USER REGISTRATION--");
            Console.Write("Create Username: ");
            user.Username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }
            if (customerList.Any(u => u.Username == user.Username) || adminList.Any(u => u.Username == user.Username))
            {
                Console.WriteLine("Username already exists.");
                return;
            }
            Console.Write("Create Password: ");
            user.Password = ReadPassword();
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }
            customerList.Add(user);

            Console.WriteLine("Account created successfully.");
        }//end of register
        static void Login()
        {
           
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }
            Console.Write("Enter password: ");
            string password = ReadPassword();
            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

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

        //password masking method
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
        }//end of readpassword method







    }//end of class program
}//end of namespace 
