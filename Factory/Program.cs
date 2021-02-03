using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeACommunication = new TcpCommunicationFactory().CreateCommunication();
            storeACommunication.ConnectToNetwork();
            var storeBCommunication = new UdpCommunicationFactory().CreateCommunication();
            storeBCommunication.ConnectToNetwork();
        }
    }

    public interface ICommunicationFactory
    {
        ICommunication CreateCommunication();
    }

    public class TcpCommunicationFactory : ICommunicationFactory
    {
        public ICommunication CreateCommunication()
        {
            return new TcpCommunication();
        }
    }
    public class UdpCommunicationFactory : ICommunicationFactory
    {
        public ICommunication CreateCommunication()
        {
            return new UdpCommunication();
        }
    }

    public interface ICommunication
    {
        void ConnectToNetwork();
        void Disconnect();
    }

    public class UdpCommunication : ICommunication
    {
        public void ConnectToNetwork()
        {
            Console.WriteLine("UdpCommunication ConnectToNetwork");
        }

        public void Disconnect()
        {
            Console.WriteLine("UdpCommunication Disconnect");
        }
    }

    public class TcpCommunication : ICommunication
    {
        public void ConnectToNetwork()
        {
            Console.WriteLine("TcpCommunication ConnectToNetwork");
        }

        public void Disconnect()
        {
            Console.WriteLine("TcpCommunication Disconnect");
        }
    }
}
