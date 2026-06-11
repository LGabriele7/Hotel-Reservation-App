using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hotel_Reservation_App
{
    internal class Admin:User
    {
        static int option;
        public override void Menu ()
        {
            do
            {
                Console.WriteLine("----------ADMIN MENU----------\n");
                Console.WriteLine("1. Manage Rooms");
                Console.WriteLine("2. Manage Booking");
                Console.WriteLine("99. Exit");
                Console.Write("Select Option: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\n------Manage Rooms------");
                        ManageRooms();
                        break;
                    case 2:
                        Console.WriteLine("\n------Manage Booking------");
                        ManageBooking();
                        break;
                    case 99:
                        Console.WriteLine("Goodbye!!!");
                        Environment.Exit(0);
                        break;

                }
            }while (option != 99);

        }//end of menu

        //admin sub-menu  
        public void ManageRooms()
        {
            do
            {
                Console.WriteLine("1. View Room");
                Console.WriteLine("2. Add Room");
                Console.WriteLine("3. Remove Room");
                Console.WriteLine("4. Update Room");
                Console.WriteLine("5. Return to Admin Menu");
                Console.WriteLine("99. Exit");
                Console.Write("Select Option: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("-----ROOMS-----");
                        ViewRooms();
                        break;
                    case 2:
                        AddRooms();
                        break;
                    case 3:
                        RemoveRooms();
                        break;
                    case 4:
                        UpdateRooms();
                        break;
                    case 5:
                        return;
                    case 99:
                        Console.WriteLine("Goodbye!!!");
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Choose from the option above");
                        break;
                }
            }while (true);
        }//end of ManageRooms

        //Start of ManageBooking Method
        public void ManageBooking()
        {
            Console.WriteLine("\n----- BOOKINGS -----");

            if (Program.bookingList.Count == 0)
            {
                Console.WriteLine("No bookings found.");
                return;
            }

            foreach (Booking booking in Program.bookingList)
            {
                Console.WriteLine($"Guest Name: {booking.GuestName}");
                Console.WriteLine($"Room Number: {booking.RoomNumber}");
                Console.WriteLine($"Check-In Date: {booking.CheckInDate}");
                Console.WriteLine($"Check-Out Date: {booking.CheckOutDate}");
                Console.WriteLine("---------------------------");
            }
        }//end of ManageBooking

    }//end of class
}//end of namespace
 