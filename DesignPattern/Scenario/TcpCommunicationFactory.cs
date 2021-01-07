namespace SimpleFactory.Scenario
{
    internal class TcpCommunicationFactory
    {
        public static ITcpCommunicationProvider GetProvider()
        {
            return new FtpProvider();
        }
    }
}