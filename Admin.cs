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
        //admin menu
        public override void Menu ()
        {
            do
            {
                try
                {
                    Console.WriteLine("----------ADMIN MENU----------\n");
                    Console.WriteLine("1. Manage Rooms");
                    Console.WriteLine("2. Manage Booking");
                    Console.WriteLine("99. Exit");
                    Console.Write("Select Option: ");
                    option = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("------------------------------------");

                switch (option)
                {
                    case 1:
                        ManageRooms();
                        break;
                    case 2:
                        ManageBooking();
                        break;
                    case 99:
                        Console.WriteLine("Goodbye!!!");
                        Environment.Exit(0);
                        break;

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            } while (option != 99);

        }//end of menu

        //admin sub-menu  
        public void ManageRooms()
        {
            do
            {
                try
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
                            Console.WriteLine("Please select a valid menu option");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            } while (option != 99);
        }//end of ManageRooms

        //Start of ManageBooking Method
        public void ManageBooking()
        {
            int option;

            do
            {
                Console.WriteLine("\n----- MANAGE BOOKING -----");
                Console.WriteLine("1. View Booking");
                Console.WriteLine("2. Search Booking");
                Console.WriteLine("3. Delete Booking");
                Console.WriteLine("4. Return to Admin Menu");

                Console.Write("Select Option: ");

                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        ViewBooking();
                        break;

                    case 2:
                        SearchBooking();
                        break;

                    case 3:
                        DeleteBooking();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Choose from the options above.");
                        break;
                }

            } while (true);
        }// end of Manage Booking method

        //View Booking Method
        public void ViewBooking()
        {
            if (Program.bookingList.Count == 0)
            {
                Console.WriteLine("No bookings found.");
                return;
            }

            foreach (Booking booking in Program.bookingList)
            {
                Console.WriteLine("\n----- BOOKING -----");
                Console.WriteLine($"Guest Name: {booking.GuestName}");
                Console.WriteLine($"Room Number: {booking.RoomNumber}");
                Console.WriteLine($"Check-In Date: {booking.CheckInDate}");
                Console.WriteLine($"Check-Out Date: {booking.CheckOutDate}");
                Console.WriteLine($"Total Price: {booking.TotalPrice:C}");
            }
        }//end of method

        //Search Booking Method
        public void SearchBooking()
        {
            Console.Write("Enter Room Number: ");

            if (!int.TryParse(Console.ReadLine(), out int roomNo))
            {
                Console.WriteLine("Invalid room number.");
                return;
            }

            Booking booking = Program.bookingList
                .Find(b => b.RoomNumber == roomNo);

            if (booking != null)
            {
                Console.WriteLine($"Guest Name: {booking.GuestName}");
                Console.WriteLine($"Check-In Date: {booking.CheckInDate}");
                Console.WriteLine($"Check-Out Date: {booking.CheckOutDate}");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }//end of method

        //Delete Booking Method
        public void DeleteBooking()
        {
            Console.Write("Enter Guest Name: ");
            string guestName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(guestName))
            {
                Console.WriteLine("Guest name cannot be empty.");
                return;
            }

            Console.Write("Enter Room Number: ");
            if (!int.TryParse(Console.ReadLine(), out int roomNo))
            {
                Console.WriteLine("Invalid room number.");
                return;
            }

            Booking booking = Program.bookingList
                .Find(b => b.GuestName == guestName && b.RoomNumber == roomNo);

            if (booking != null)
            {
                Program.bookingList.Remove(booking);
                Console.WriteLine("Booking deleted successfully!");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }//end of method

    }//end of class
}//end of namespace
 