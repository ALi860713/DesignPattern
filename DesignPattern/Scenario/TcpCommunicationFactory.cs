using System;

namespace SimpleFactory.Scenario
{
    internal class TcpCommunicationFactory
    {
        public static ITcpCommunicationProvider GetProvider(TcpCommunicationType type)
        {
            // if next time the library would like to change the different provider instance will not affect client side.
            switch (type)
            {
                case TcpCommunicationType.Smtp:
                    return new SmtpProvider();
                case TcpCommunicationType.Ftp:
                    return new FtpProvider();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}