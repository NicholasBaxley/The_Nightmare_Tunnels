using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Alert
    {
        public delegate void SendMessageLine(string message);
        public delegate void SendMessage(string message);        
        
        public Alert(SendMessageLine sendMessageLine, SendMessage sendMessage)
        {
            SendLine = sendMessageLine;
            Send = sendMessage;
        }

        public SendMessageLine SendLine { get; set; }
        public SendMessage Send { get; set; }

        public void Write(string message)
        {
            Send(message);
        }

        public void WriteLine(string message)
        {
            SendLine(message);
        }

    }
}