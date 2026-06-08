namespace Hotel_Reservation_App
{
    internal class Program
    {
        static List<User> users = new List<User>(); 
        static List<Room> rooms = new List<Room> (); 

        static void Main(string[] args) 
        {
            int option;
            bool running = true;

            while (running)
            {
                //user login and registration
                Console.WriteLine("======== HOTEL RESEVATION SYSTEM ========\n");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");

                Console.Write("Select Option: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                }

            }


        }

        public static void Register()
        {
            Console.WriteLine("\n--------- Register ---------");
            Console.WriteLine("Username: ");
            Console.WriteLine("Password: ");
        }

        public static void Login()
        {
            Console.WriteLine("\n--------- Login ---------");
            Console.WriteLine("Username: ");
            Console.WriteLine("Password: ");
        }
    }
}
