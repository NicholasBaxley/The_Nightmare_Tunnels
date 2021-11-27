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
        public delegate string GetInput();

        public Alert(SendMessageLine sendMessageLine, SendMessage sendMessage, GetInput getInput)
        {
            SendLine = sendMessageLine;
            Send = sendMessage;
            Input = getInput;
        }

        public SendMessageLine SendLine { get; set; }
        public SendMessage Send { get; set; }
        public GetInput Input { get; set; }

        public void Write(string message)
        {
            Send(message);
        }

        public void WriteLine(string message)
        {
            SendLine(message);
        }

        public string ReadLine()
        {
            return Input();
        }

    }
}