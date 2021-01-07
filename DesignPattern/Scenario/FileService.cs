using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory.Scenario
{
    internal class FileService
    {
        public void Upload()
        {
            var ftpServer = TcpCommunicationFactory.GetProvider();
            ftpServer.UploadFile();
        }

        public void Send()
        {
            var ftpServer = TcpCommunicationFactory.GetProvider();
            ftpServer.SendFile();
        }
    }
}
