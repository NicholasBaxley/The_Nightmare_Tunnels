using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Objects;
using NightmareEngine;
using System.Threading;
using System.Windows.Forms;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            World.message = new Alert(WriteLine, Write, ReadLine);

            Thread login = new Thread(new ThreadStart(Login.PlayerLogin));
            login.Start();

            Player player = new Player();
            player = World.player;
        }

        private void inputTextBox_KeyPress(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if(e.Key == Key.Enter)
            {

                if (inputTextBox.Text.Length > 0)
                {
                    World.message.Message = inputTextBox.Text;
                    gameDisplayTextBox.Text += inputTextBox.Text + "\n";
                    ClearInput();
                }
                else
                {
                    WriteLine("You didn't enter anything!");
                }

                if (World.loggedIn == 1) // Ill fix this later ( too lazy to do it the other way)
                {
                    // Shows help message and starting location
                    World.message.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                    World.message.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                    Thread game = new Thread(new ThreadStart(NightmareEngine.Menu.Game));
                    game.Start();

                }
            }
           
        }

        private void inputButton_Click(object sender, RoutedEventArgs e)
        {
            if (inputTextBox.Text.Length > 0)
            {
                World.message.Message = inputTextBox.Text;
                gameDisplayTextBox.Text += inputTextBox.Text + "\n";
                ClearInput();
            }
            else
            {
                WriteLine("You didn't enter anything!");
            }
        }

        #region Input/Output
        private void WriteLine(string message)
        {
            this.Dispatcher.Invoke(() => gameDisplayTextBox.Text += message + "\n");
            
        }

        private void Write(string message)
        {
            this.Dispatcher.Invoke(() => gameDisplayTextBox.Text += message);
        }
        #region ReadLine/Async
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
        #endregion
        private void ClearInput()
        {
            inputTextBox.Text = "";
        }
        #endregion

        
    }
}
