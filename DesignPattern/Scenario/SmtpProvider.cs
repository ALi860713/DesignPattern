using System;

namespace SimpleFactory.Scenario
{
    internal class SmtpProvider : ITcpCommunicationProvider
    {
        public void UploadFile()
        {
            Console.WriteLine("SmtpProvider uploading file...");
        }

        public void SendFile()
        {
            Console.WriteLine("SmtpProvider sending file...");
        }
    }
}