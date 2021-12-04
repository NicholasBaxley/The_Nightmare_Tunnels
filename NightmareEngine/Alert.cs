using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Objects
{
    public class Alert
    {
        public delegate void SendMessageLine(string message);
        public delegate void SendMessage(string message);
        public delegate string GetInput();
        public delegate Task<string> Del();

        public Alert(SendMessageLine sendMessageLine, SendMessage sendMessage, GetInput getInput)
        {
            SendLine = sendMessageLine;
            Send = sendMessage;
            Input = getInput;
        }

        public Alert(SendMessageLine sendMessageLine, SendMessage sendMessage, Del del)
        {
            SendLine = sendMessageLine;
            Send = sendMessage;
            ReadText = del;
        }

        public Alert(SendMessageLine sendMessageLine, SendMessage sendMessage)
        {
            SendLine = sendMessageLine;
            Send = sendMessage;

        }
        public Del ReadText { get; set; }
        public string Message { get; set; }
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
        
        
        public async Task<string> ReadLine() // probably a better way to do this
        {
            
            if(ReadText == null)
            {
                return Input();
            }
            else
            {
                await Task.Run(() => ReadText());
                return Message;
            }
            
        }

        public void SetMessage(string s)
        {
            Message = s;
            WriteLine(Message);
        }

    }
}