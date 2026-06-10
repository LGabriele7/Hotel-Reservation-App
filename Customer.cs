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
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ViewRooms();
                        break;
                    case 2:
                        break;
                    case 99:
                        Console.WriteLine("Goodbye!!!");
                        Environment.Exit(0);
                        return;

                }
            }while (option != 99);


        }//end of menu
    }
}
