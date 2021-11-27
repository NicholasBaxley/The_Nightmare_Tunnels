﻿
namespace WinUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.characterSheetPictureBox = new System.Windows.Forms.PictureBox();
            this.gameDisplayTextBox = new System.Windows.Forms.RichTextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterSheetPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.Location = new System.Drawing.Point(12, 12);
            this.mapPictureBox.MinimumSize = new System.Drawing.Size(245, 196);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(245, 196);
            this.mapPictureBox.TabIndex = 0;
            this.mapPictureBox.TabStop = false;
            // 
            // characterSheetPictureBox
            // 
            this.characterSheetPictureBox.Location = new System.Drawing.Point(797, 12);
            this.characterSheetPictureBox.MinimumSize = new System.Drawing.Size(179, 339);
            this.characterSheetPictureBox.Name = "characterSheetPictureBox";
            this.characterSheetPictureBox.Size = new System.Drawing.Size(179, 339);
            this.characterSheetPictureBox.TabIndex = 1;
            this.characterSheetPictureBox.TabStop = false;
            // 
            // gameDisplayTextBox
            // 
            this.gameDisplayTextBox.Location = new System.Drawing.Point(278, 13);
            this.gameDisplayTextBox.MinimumSize = new System.Drawing.Size(509, 384);
            this.gameDisplayTextBox.Name = "gameDisplayTextBox";
            this.gameDisplayTextBox.ReadOnly = true;
            this.gameDisplayTextBox.Size = new System.Drawing.Size(509, 384);
            this.gameDisplayTextBox.TabIndex = 2;
            this.gameDisplayTextBox.Text = "";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(278, 404);
            this.inputTextBox.MinimumSize = new System.Drawing.Size(420, 20);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(420, 20);
            this.inputTextBox.TabIndex = 3;
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(705, 404);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(75, 23);
            this.enterButton.TabIndex = 4;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 461);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.gameDisplayTextBox);
            this.Controls.Add(this.characterSheetPictureBox);
            this.Controls.Add(this.mapPictureBox);
            this.MinimumSize = new System.Drawing.Size(1004, 500);
            this.Name = "Form1";
            this.Text = "The Nightmare Tunnels";
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterSheetPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.PictureBox characterSheetPictureBox;
        private System.Windows.Forms.RichTextBox gameDisplayTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button enterButton;
    }
}

