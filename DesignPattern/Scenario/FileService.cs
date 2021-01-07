using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory.Scenario
{
    internal class FileService
    {
        public void Upload()
        {
            var ftpServer = new FtpProvider();
            ftpServer.UploadFile();
        }

        public void Send()
        {
            var ftpServer = new FtpProvider();
            ftpServer.SendFile();
        }
    }
}
