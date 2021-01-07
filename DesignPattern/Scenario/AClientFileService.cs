using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory.Scenario
{
    internal class AClientFileService
    {
        public void Upload()
        {
            var ftpServer = TcpCommunicationFactory.GetProvider(TcpCommunicationType.Ftp);
            ftpServer.UploadFile();
        }

        public void Send()
        {
            var ftpServer = TcpCommunicationFactory.GetProvider(TcpCommunicationType.Ftp);
            ftpServer.SendFile();
        }
    }

    internal class BClientFileService
    {
        public void Upload()
        {
            var ftpServer = TcpCommunicationFactory.GetProvider(TcpCommunicationType.Smtp);
            ftpServer.UploadFile();
        }

        public void Send()
        {
            var ftpServer = TcpCommunicationFactory.GetProvider(TcpCommunicationType.Smtp);
            ftpServer.SendFile();
        }
    }
}
