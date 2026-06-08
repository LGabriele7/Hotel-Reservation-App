using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Reservation_App
{
    public class Booking
    {
        public string GuestName { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal Price { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Booking(string guestName, int roomNumber, string roomType,
                       decimal price, DateTime checkInDate, DateTime checkOutDate)
        {
            GuestName = guestName;
            RoomNumber = roomNumber;
            RoomType = roomType;
            Price = price;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }// end of class
}// end of namespace