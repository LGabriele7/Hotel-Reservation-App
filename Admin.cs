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
                    Console.WriteLine("\n----- MANAGE ROOMS -----");
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
                Console.WriteLine("1. View Booking");
                Console.WriteLine("2. Add Booking");
                Console.WriteLine("3. Search Booking");
                Console.WriteLine("4. Delete Booking");
                Console.WriteLine("5. Return to Admin Menu");
                Console.WriteLine("99. Exit");

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
                        AddBooking();
                        break;

                    case 3:
                        SearchBooking();
                        break;

                    case 4:
                        DeleteBooking();
                        break;

                    case 5:
                        return;

                    case 99:
                        Console.WriteLine("Goodbye!!!");
                        Environment.Exit(0);
                        return;

                    default:
                        Console.WriteLine("Choose from the options above.");
                        break;
                }

            } while (true);
        }// end of Manage Booking method

        //Start of Add Booking Method
        public void AddBooking()
        {
            Console.WriteLine("\n----- ADD BOOKING -----");

            Booking booking = new Booking();

            // Guest Name
            Console.Write("Guest Name: ");
            booking.GuestName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(booking.GuestName))
            {
                Console.WriteLine("Guest name cannot be empty.");
                return;
            }

            // Room Number
            Console.Write("Room Number: ");

            if (!int.TryParse(Console.ReadLine(), out int roomNo))
            {
                Console.WriteLine("Invalid room number.");
                return;
            }

            booking.RoomNumber = roomNo;

            // Check if room exists
            Room room = roomList.Find(r => r.RoomNo == booking.RoomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found!");
                return;
            }

            Console.WriteLine($"Price Per Night: {room.RoomPrice:C}");

            // Check-In Date
            Console.Write("Check-In Date (dd/MM/yyyy): ");

            DateTime checkIn;

            if (!DateTime.TryParse(Console.ReadLine(), out checkIn))
            {
                Console.WriteLine("Invalid date!");
                return;
            }

            booking.CheckInDate = checkIn.ToString("dd/MM/yyyy");

            // Check-Out Date
            Console.Write("Check-Out Date (dd/MM/yyyy): ");

            DateTime checkOut;

            if (!DateTime.TryParse(Console.ReadLine(), out checkOut))
            {
                Console.WriteLine("Invalid date!");
                return;
            }

            if (checkOut <= checkIn)
            {
                Console.WriteLine("Check-out date must be after the check-in date.");
                return;
            }

            booking.CheckOutDate = checkOut.ToString("dd/MM/yyyy");

            // Calculate Total Price
            int nights = (checkOut - checkIn).Days;

            booking.TotalPrice = nights * room.RoomPrice;

            Console.WriteLine($"Number of Nights: {nights}");
            Console.WriteLine($"Total Price: {booking.TotalPrice:C}");

            // Save Booking
            Program.bookingList.Add(booking);

            Console.WriteLine("Booking added successfully!");
        }//end of Add Booking Method

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
 