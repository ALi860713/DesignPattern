using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory.Scenario
{
    internal class FtpProvider : ITcpCommunicationProvider
    {
        public void UploadFile()
        {
            Console.WriteLine("FtpProvider uploading file...");
        }

        public void SendFile()
        {
            Console.WriteLine("FtpProvider sending file...");
        }
    }
}
