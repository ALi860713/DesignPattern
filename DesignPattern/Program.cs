using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var tcpCommunication = CommunicationFactory.GetInstance(CommunicationType.Tcp);
            tcpCommunication.ConnectToNetwork();
            var udpCommunication = CommunicationFactory.GetInstance(CommunicationType.Udp);
            udpCommunication.ConnectToNetwork();
            Console.ReadLine();
        }
    }

    public class CommunicationFactory
    {
        public static ICommunication GetInstance(CommunicationType communication)
        {
            switch (communication)
            {
                case CommunicationType.Tcp:
                    return new TcpCommunication();
                case CommunicationType.Udp:
                    return new UdpCommunication();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class UdpCommunication : ICommunication
    {
        public void ConnectToNetwork()
        {
            Console.WriteLine("UdpCommunication ConnectToNetwork");
        }
    }

    public class TcpCommunication : ICommunication
    {
        public void ConnectToNetwork()
        {
            Console.WriteLine("TcpCommunication ConnectToNetwork");
        }
    }

    public enum CommunicationType
    {
        Tcp,
        Udp
    }

    public interface ICommunication
    {
        void ConnectToNetwork();
    }
}