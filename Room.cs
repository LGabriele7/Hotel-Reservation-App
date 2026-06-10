using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Reservation_App
{
    internal class Room
    {
        public static List<Room> roomList = new List<Room>()
        {
            new Room {RoomType ="Standard", RoomNo = 201, RoomPrice = 200}
        };

        // rooms fields
        private string roomType = "";
        private int roomNo;
        private bool roomIsAvailabe = false;
        private decimal roomPrice;

        //properties 
        public string RoomType { get { return roomType; } set { roomType = value; } }
        public int RoomNo { get { return roomNo; } set {roomNo = value; } }
        public decimal RoomPrice { get { return roomPrice; } set { roomPrice = value; } }


        public void DisplayRooms()
        {
            Console.WriteLine($"\nRoom Type: {RoomType}");
            Console.WriteLine($"Room No: {RoomNo}");
            Console.WriteLine($"Price: {RoomPrice}");
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


    }
}
