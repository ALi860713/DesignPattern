using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Scenario
{
    internal class Traveler
    {
        public void Main()
        {
            var selfTravel = new Vocation(new DateTime(2021, 01, 09), new DateTime(2021, 01, 10));

            var familyOuting = new Vocation(new DateTime(2021, 01, 08), new DateTime(2021, 01, 10), new Hotel("HotelA"));

            var familyOutingWithRestaurant = new Vocation(new DateTime(2021, 01, 08), new DateTime(2021, 01, 10), new Hotel("HotelA"), new Restaurant("RestaurantA"));
        }
    }
}
