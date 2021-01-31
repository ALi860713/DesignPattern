using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeACommunication = new StoreACommunicationFactory().CreateCommunication();
            storeACommunication.ConnectToNetwork();
            var storeBCommunication = new StoreBCommunicationFactory().CreateCommunication();
            storeBCommunication.ConnectToNetwork();
        }
    }

    public interface ICommunicationFactory
    {
        ICommunication CreateCommunication();
    }

    public class StoreACommunicationFactory : ICommunicationFactory
    {
        public ICommunication CreateCommunication()
        {
            return new TcpCommunication();
        }
    }
    public class StoreBCommunicationFactory : ICommunicationFactory
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
