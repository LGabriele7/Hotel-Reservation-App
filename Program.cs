namespace Hotel_Reservation_App
{
    internal class Program
    {
        static List<User> users = new List<User>(); 
        static List<Room> rooms = new List<Room> ();
        static List<Booking> bookings = new List<Booking>(); 

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

        //Create Booking Method
        public static void CreateBooking()
        {
            Booking booking = new Booking();

            Console.WriteLine("\n--------- Create Booking ---------");

            Console.Write("Guest Name: ");
            booking.GuestName = Console.ReadLine();

            Console.Write("Room Number: ");
            booking.RoomNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Check-In Date: ");
            booking.CheckInDate = Console.ReadLine();

            Console.Write("Check-Out Date: ");
            booking.CheckOutDate = Console.ReadLine();

            bookings.Add(booking);

            Console.WriteLine("\nBooking Created Successfully!");
        }//end of Create Booking Method

        //Guest Menu
        public static void GuestMenu()
        {
            int option;

            do
            {
                Console.WriteLine("\n--------- Guest Menu ---------");
                Console.WriteLine("1. View Rooms");
                Console.WriteLine("2. Create Booking");
                Console.WriteLine("3. Logout");

                Console.Write("Select Option: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Display Rooms Here");
                        break;

                    case 2:
                        CreateBooking();
                        break;
                }

            } while (option != 3);
        }//end of Guest Menu

        //Manage Booking Method
        public static void ManageBooking()
        {
            Console.WriteLine("\n--------- Manage Booking ---------");

            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found.");
                return;
            }

            for (int i = 0; i < bookings.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. {bookings[i].GuestName} | Room {bookings[i].RoomNumber}");
            }
        }//end of Manage Booking Method

        //Admin Menu
        public static void AdminMenu()
        {
            int option;

            do
            {
                Console.WriteLine("\n--------- Admin Menu ---------");
                Console.WriteLine("1. Manage Rooms");
                Console.WriteLine("2. Manage Guest");
                Console.WriteLine("3. Manage Booking");
                Console.WriteLine("4. Exit");

                Console.Write("Select Option: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 3:
                        ManageBooking();
                        break;
                }

            } while (option != 4);
        }//end of Admin Menu

    }//end of class
}//end of namespace
