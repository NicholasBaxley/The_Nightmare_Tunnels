using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Objects;
using NightmareEngine;

namespace WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GameTimerEvent_Tick(object sender, EventArgs e)
        {
              
        }


        private void GameDisplayTextEvent(object sender, EventArgs e)
        {
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            World.message = new Alert(WriteLine, Write, ReadLine);

            //Todo - create new header
            World.message.WriteLine("Welcome to the Nightmare Tunnels!");
        }

        #region Input/Output
        private void WriteLine(string message)
        {
            gameDisplayTextBox.Text += message + "\n";
        }

        private void Write(string message)
        {
            gameDisplayTextBox.Text += message;
        }

        private string ReadLine()
        {
            string temp = inputTextBox.Text;
            ClearInput();
            return temp;
        }
        private void ClearInput()
        {
            inputTextBox.Text = "";
        }
        #endregion

    }
}
/*
            Login.PlayerLogin();

            /*
            Player player = World.player;

            // TODO - For now gives new players a random weapon.
            if (player.equippedWeapon == null)
            {
                player.equippedWeapon = Weapon.RandomWeapon(World.weapons);
            }

            // Shows help message and starting location
            StandardMessages.DisplayHelpMessage();
            World.message.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
            World.message.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));

            // Main Menu that controls most of the game
            */
//NightmareEngine.Menu.Game();