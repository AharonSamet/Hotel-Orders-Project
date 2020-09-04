using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace BE
{
    [Serializable]

    public class GuestRequest
    {
        public int GuestRequestKey { get; set; }
        public Login ClientLoginDetails { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public enums.Area Area { get; set; }
        public enums.Districts SubArea { get; set; }
        public enums.Type TypeOfAccommodationRequested { get; set; }
        public enums.Style StyleOfUnitRequested { get; set; }
        public int AmountOfAdults { get; set; }
        public int AmountOfChildren { get; set; }
        public FilterElementsForGuest SpecificRequirements { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}