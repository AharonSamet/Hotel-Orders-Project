using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BE
{
    [Serializable]
    public class FilterElements
    {
        public int Pool { get; set; }
        public int Jacuzzi { get; set; }
        public int Garden { get; set; }
        public int Terrace { get; set; }
        public int ChildrenAttractions { get; set; }
        public int Tv { get; set; }
        public int SmokingRoom { get; set; }
        public int BabyCrib { get; set; }
        public int Elevator { get; set; }
        public int Spa { get; set; }
        public int AirConditioning { get; set; }
        public int WiFi { get; set; }
        public int RoomService { get; set; }
        public int DoubleBed { get; set; }
        public int TwinBeds { get; set; }
        public int Breakfast { get; set; }
        public int Lunch { get; set; }
        public int Dinner { get; set; }
        public int FreeParking { get; set; }
        public int Gym { get; set; }
        public int PrivateBathroom { get; set; }
        public int Bathtub { get; set; }
        public int WashingMachine { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}