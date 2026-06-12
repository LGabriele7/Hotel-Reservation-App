using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hotel_Reservation_App
{

    abstract class User : Room
    {
        public static string userChoice;
        //fileds
        private string username;
        private string password;

        //properties
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }


        public void UserDisplay()
        {
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Password: {Password}\n");
        }
        public abstract void Menu();


        public void ViewRooms()
        {
            Console.WriteLine("----- ROOMS -----");
            foreach (Room u in roomList)
            {
                u.DisplayRooms();
            }
            Console.Write("Do you want to continue? (yes/no): ");
            userChoice = Console.ReadLine().ToLower();
            if ( userChoice == "yes" )
            {
                return;
            }
            else
            {
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }
        }//end of ViewRooms

        
        public void AddRooms()
        {
            do
            {
                try
                {
                    Console.Write("Enter Room Type:");
                    string roomType = Console.ReadLine();
                    Console.Write("Enter Room Number:");
                    int roomNo = Convert.ToInt32(Console.ReadLine());
                    if (roomList.Any(l => l.RoomNo == roomNo))
                    {
                        Console.WriteLine("Room number already exist");
                        break;
                    }
                    Console.Write("Enter Room Price:");
                    decimal roomPrice = Convert.ToDecimal(Console.ReadLine());
                    Room room = new Room(roomType, roomNo, roomPrice);

                    roomList.Add(room);
                    Console.WriteLine("New Room Recorded");
                    Console.Write("Do you want to continue? (yes/no): ");
                    userChoice = Console.ReadLine().ToLower();
                    if (userChoice == "yes")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                    }


                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter the correct input.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Input cannot be null.");
                }


            } while (true);

        }//end of Addrooms

        public void RemoveRooms()
        {
            Console.Write("Enter the Room Number to remove:");
            int roomNo = Convert.ToInt32(Console.ReadLine());

            Room removeRooms = roomList.Find(r => r.RoomNo == roomNo);
            if (removeRooms != null)
            {
                roomList.Remove(removeRooms);
                Console.WriteLine($"Room NO:{roomNo} has been removed");
            }
            else
            {
                Console.WriteLine("Room not found!");
            }
            Console.Write("Do you want to continue? (yes/no): ");
            userChoice = Console.ReadLine().ToLower();
            if (userChoice == "yes")
            {
                return;
            }
            else
            {
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }


        }//end of RemoveRooms

        public void UpdateRooms()
        {
            Console.Write("Enter Room Number to update: ");
            int roomNo = int.Parse(Console.ReadLine());

            Room room = roomList.FirstOrDefault(r => r.RoomNo == roomNo);

            if (room != null)
            {
                Console.WriteLine("Room found!");

                Console.Write("New Room Type: ");
                room.RoomType = Console.ReadLine();

                Console.Write("New Room Number: ");
                room.RoomNo = Convert.ToInt32(Console.ReadLine());

                Console.Write("New Price: ");
                room.RoomPrice = Convert.ToDecimal(Console.ReadLine());

               
                Console.WriteLine("Room updated successfully!");
            }
            else
            {
                Console.WriteLine("Room not found!");
            }
            Console.Write("Do you want to continue? (yes/no): ");
            userChoice = Console.ReadLine().ToLower();
            if (userChoice == "yes")
            {
                return;
            }
            else
            {
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }
        }//end of update Rooms










    } //end of class
}//end of namespace
