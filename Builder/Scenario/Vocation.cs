using System;

namespace Builder.Scenario
{
    internal class Vocation
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDateTime;
        private readonly Hotel _hotel;
        private readonly Restaurant _restaurant;

        public Vocation(DateTime startDate, DateTime endDateTime)
        {
            _startDate = startDate;
            _endDateTime = endDateTime;
        }

        public Vocation(DateTime startDate, DateTime endDateTime, Hotel hotel)
        {
            _startDate = startDate;
            _endDateTime = endDateTime;
            _hotel = hotel;
        }

        public Vocation(DateTime startDate, DateTime endDateTime, Hotel hotel, Restaurant restaurant)
        {
            _startDate = startDate;
            _endDateTime = endDateTime;
            _hotel = hotel;
            _restaurant = restaurant;
        }

        public override string ToString()
        {
            return $"StartDate: {_startDate}, EndDate: {_endDateTime}, Hotel: {_hotel}, Restaurant: {_restaurant}";
        }
    }
}