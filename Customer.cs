using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Hotel_Reservation_App
{
    internal class Customer : User
    {
        public override void Menu()
        {
            int option;
            do
            {
                Console.WriteLine("----------CUSTOMER MENU----------\n");
                Console.WriteLine("1. View Rooms");
                Console.WriteLine("2. Create Booking");
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
                        ViewRooms();
                        break;
                    case 2:
                        CreateBooking();
                        break;
                    case 99:
                        Console.WriteLine("Goodbye!!!");
                        Environment.Exit(0);
                        return;

                }
            }while (option != 99);


        }//end of menu

        //Start of Create Booking Method
        public void CreateBooking()
        {
            Booking booking = new Booking();

            Console.WriteLine("\n----- CREATE BOOKING -----");

            Console.Write("Guest Name: ");
            booking.GuestName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(booking.GuestName))
            {
                Console.WriteLine("Guest name cannot be empty.");
                return;
            }

            Console.Write("Room Number: ");

            if (!int.TryParse(Console.ReadLine(), out int roomNo))
            {
                Console.WriteLine("Invalid room number.");
                return;
            }

            Room room = roomList.Find(r => r.RoomNo == booking.RoomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found!");
                return;
            }

            Console.WriteLine($"Price: {room.RoomPrice}");

            Console.Write("Check-In Date: ");
            booking.CheckInDate = Console.ReadLine();

            Console.Write("Check-Out Date: ");
            booking.CheckOutDate = Console.ReadLine();

            Program.bookingList.Add(booking);

            Console.WriteLine("Booking created successfully!");
        }//end of create booking method
    }
}
