using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Reservation_App
{
    internal class Room
    {
        public static List<Room> roomList = new List<Room>()
        {
            new Room {RoomType ="Standard", RoomNo = 201, RoomPrice = 200},
            new Room {RoomType ="Deluxe", RoomNo = 301, RoomPrice = 300},
            new Room {RoomType ="Suite", RoomNo = 401, RoomPrice = 400}
        };

        // rooms fields
        private string roomType = "";
        private int roomNo;
        private bool roomIsAvailabe = true;
        private decimal roomPrice;

        //properties 
        public string RoomType { get { return roomType; } set { roomType = value; } }
        public int RoomNo { get { return roomNo; } set {roomNo = value; } }
        public decimal RoomPrice { get { return roomPrice; } set { roomPrice = value; } }
        public bool RoomIsAvailable { get { return roomIsAvailabe; } set { roomIsAvailabe = value; } }

        //display rooms
        public void DisplayRooms()
        {
            Console.WriteLine($"\nRoom Type: {RoomType}");
            Console.WriteLine($"Room No: {RoomNo}");
            RoomAvailability();
            Console.WriteLine($"Price Per Night: ${RoomPrice:F2}");
        }


        //constructor 
        public Room()
        {

        }
        public Room(string rt, int rn, decimal rm)
        {
            RoomType = rt;
            RoomNo = rn;
            RoomPrice = rm;
        }

        //the avalability of the room
        public void RoomAvailability()
        {
            if (roomIsAvailabe != false)
            {
                Console.WriteLine($"Room {RoomNo}: is available");
            }
            else 
            {
                Console.WriteLine($"Room {RoomNo}: is not available");
            }
        }

    }//end of class
}//end of namespace
