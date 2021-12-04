using System;
using System.Windows.Forms;
using Objects;
using NightmareEngine;
using System.Threading.Tasks;
using System.Threading;

namespace WinUI
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
       private void Form1_Load(object sender, EventArgs e)
       {
            World.message = new Alert(WriteLine, Write, ReadLine);
            
            Thread login = new Thread(new ThreadStart(Login.PlayerLogin));
            login.Start();
            
            Player player = new Player();
            player = World.player;
 
        }

        private void InputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if(inputTextBox.Text.Length > 0)
                {
                    World.message.Message = inputTextBox.Text;
                    gameDisplayTextBox.Text += inputTextBox.Text + "\n";
                    ClearInput();
                }
                else
                {
                    WriteLine("You didn't enter anything!");
                }

                if(World.loggedIn == 1) // Ill fix this later ( too lazy to do it the other way)
                {
                    // Shows help message and starting location
                    World.message.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                    World.message.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                    Thread game = new Thread(new ThreadStart(NightmareEngine.Menu.Game));
                    game.Start();
                    
                }
            }
        }

        #region Input/Output
        private void WriteLine(string message)
        {
            Invoke(new MethodInvoker(() => gameDisplayTextBox.Focus()));
            Invoke(new MethodInvoker(() => gameDisplayTextBox.AppendText(message + "\n")));
            Invoke(new MethodInvoker(() => inputTextBox.Focus()));
        }

        private void Write(string message)
        {
            Invoke(new MethodInvoker(() => gameDisplayTextBox.Focus()));
            Invoke(new MethodInvoker(() => gameDisplayTextBox.AppendText(message)));
            Invoke(new MethodInvoker(() => inputTextBox.Focus()));
        }
        private async Task<string> ReadLine()
        {
            await Task.Run(() => AwaitInputAsync().Wait());
            return World.message.Message;
        }

        private async Task AwaitInputAsync()
        {
            string old = World.message.Message;
            await Task.Run(() =>
            {
                while (true)
                {
                    if (old != World.message.Message)
                    {
                        break;
                    }
                }

            });
        }

        #region Clears
        private void ClearConsole()
        {
            gameDisplayTextBox.Text = "";
        }
         
        private void ClearInput()
        {
            inputTextBox.Text = "";
        }
        #endregion
        #endregion
        
    }
}