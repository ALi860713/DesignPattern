using System;
using System.Collections.Generic;

namespace Builder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var hotel = new Hotel();
            var vocation = new ThreeDayVocationBuilder()
                .SetBeginDate("2018/01/01")
                .SetEndDate("2018/01/03")
                .SetHotel(hotel)
                .Create();
            Console.ReadLine();
        }
    }

    public interface IVocationBuilder
    {
        public IVocationBuilder SetBeginDate(string date);

        public IVocationBuilder SetEndDate(string date);

        public IVocationBuilder SetHotel(Hotel hotel);

        public IVocationBuilder SetRestaurant(Restaurant restaurant);

        public IVocationBuilder SetTicket(List<string> tickets);

        public Vocation Create();
    }

    public class ThreeDayVocationBuilder : IVocationBuilder
    {
        private string _beginDate;
        private string _endDate;
        private Hotel _hotel;
        private Restaurant _restaurant;
        private List<string> _tickets;

        public IVocationBuilder SetBeginDate(string date)
        {
            _beginDate = date;
            return this;
        }

        public IVocationBuilder SetEndDate(string date)
        {
            _endDate = date;
            return this;
        }

        public IVocationBuilder SetHotel(Hotel hotel)
        {
            _hotel = hotel;
            return this;
        }

        public IVocationBuilder SetRestaurant(Restaurant restaurant)
        {
            _restaurant = restaurant;
            return this;
        }

        public IVocationBuilder SetTicket(List<string> tickets)
        {
            _tickets = tickets;
            return this;
        }

        public Vocation Create()
        {
            return new Vocation(_beginDate, _endDate, _hotel,
                _restaurant, _tickets);
        }
    }

    public class Vocation
    {
        public Vocation(string beginDate, string endDate, Hotel hotel, Restaurant restaurant, List<string> tickets)
        {
        }
    }

    public class Restaurant
    {
    }

    public class Hotel
    {
    }
}