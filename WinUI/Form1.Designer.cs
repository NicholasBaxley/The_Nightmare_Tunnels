
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
            this.components = new System.ComponentModel.Container();
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.characterSheetPictureBox = new System.Windows.Forms.PictureBox();
            this.gameDisplayTextBox = new System.Windows.Forms.RichTextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterSheetPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.mapPictureBox.Location = new System.Drawing.Point(12, 12);
            this.mapPictureBox.MinimumSize = new System.Drawing.Size(245, 196);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(245, 196);
            this.mapPictureBox.TabIndex = 0;
            this.mapPictureBox.TabStop = false;
            // 
            // characterSheetPictureBox
            // 
            this.characterSheetPictureBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.characterSheetPictureBox.Location = new System.Drawing.Point(797, 12);
            this.characterSheetPictureBox.MinimumSize = new System.Drawing.Size(179, 339);
            this.characterSheetPictureBox.Name = "characterSheetPictureBox";
            this.characterSheetPictureBox.Size = new System.Drawing.Size(179, 339);
            this.characterSheetPictureBox.TabIndex = 1;
            this.characterSheetPictureBox.TabStop = false;
            // 
            // gameDisplayTextBox
            // 
            this.gameDisplayTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.gameDisplayTextBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.gameDisplayTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gameDisplayTextBox.Location = new System.Drawing.Point(278, 13);
            this.gameDisplayTextBox.MinimumSize = new System.Drawing.Size(509, 384);
            this.gameDisplayTextBox.Name = "gameDisplayTextBox";
            this.gameDisplayTextBox.ReadOnly = true;
            this.gameDisplayTextBox.Size = new System.Drawing.Size(509, 384);
            this.gameDisplayTextBox.TabIndex = 2;
            this.gameDisplayTextBox.TabStop = false;
            this.gameDisplayTextBox.Text = "";
            this.gameDisplayTextBox.TextChanged += new System.EventHandler(this.GameDisplayTextEvent);
            // 
            // inputTextBox
            // 
            this.inputTextBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.inputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.inputTextBox.Location = new System.Drawing.Point(278, 401);
            this.inputTextBox.MinimumSize = new System.Drawing.Size(420, 23);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(420, 23);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.Enter += new System.EventHandler(this.EnterButton_Click);
            // 
            // enterButton
            // 
            this.enterButton.BackColor = System.Drawing.SystemColors.ControlText;
            this.enterButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.enterButton.Location = new System.Drawing.Point(704, 401);
            this.enterButton.MinimumSize = new System.Drawing.Size(82, 23);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(82, 23);
            this.enterButton.TabIndex = 1;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.EnterButton_Click);
            this.enterButton.Enter += new System.EventHandler(this.EnterButton_Click);
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimerEvent_Tick);
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
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Timer GameTimer;
    }
}

