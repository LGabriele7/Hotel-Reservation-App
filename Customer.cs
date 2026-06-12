using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Hotel_Reservation_App
{
    internal class Customer : User 
    {
        static int option;

        //customer menu
        public override void Menu()
        {
            do
            {
                try
                {

                    Console.WriteLine("----------CUSTOMER MENU----------\n");
                    Console.WriteLine("1. View Rooms");
                    Console.WriteLine("2. Create Booking");
                    Console.WriteLine("99. Exit");
                    Console.Write("Select Option: ");
                    option = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("------------------------------------");

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
                        default:
                            Console.WriteLine("Please select a valid menu option");
                            break;
                    }
                } 
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
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

            booking.RoomNumber = roomNo;

            Room room = roomList.Find(r => r.RoomNo == booking.RoomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found!");
                return;
            }
            Console.WriteLine($"Price Per Night: {room.RoomPrice:C}");

            Console.Write("Check-In Date (dd/MM/yyyy): ");

            DateTime checkIn;

            if (!DateTime.TryParse(Console.ReadLine(), out checkIn))
            {
                Console.WriteLine("Invalid date! Please enter a valid date.");
                return;
            }

            booking.CheckInDate = checkIn.ToString("dd/MM/yyyy");

            Console.Write("Check-Out Date (dd/MM/yyyy): ");

            DateTime checkOut;

            if (!DateTime.TryParse(Console.ReadLine(), out checkOut))
            {
                Console.WriteLine("Invalid date! Please enter a valid date.");
                return;
            }

            booking.CheckOutDate = checkOut.ToString("dd/MM/yyyy");

            if (checkOut <= checkIn)
            {
                Console.WriteLine("Check-out date must be after the check-in date.");
                return;
            }

            booking.CheckOutDate = checkOut.ToString("dd/MM/yyyy");

            // Calculate number of nights
            int nights = (checkOut - checkIn).Days;

            // Calculate total price
            booking.TotalPrice = nights * room.RoomPrice;

            Console.Write("Check-Out Date: ");
            booking.CheckOutDate = Console.ReadLine();
            room.RoomIsAvailable = false; 
            Program.bookingList.Add(booking);

            Console.WriteLine("Booking created successfully!");
        }//end of create booking method
    }//end of customer class
}//end of namespace
