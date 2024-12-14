namespace PLaneTrackerGUI
{
    partial class Form1View
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MoveTimer = new System.Windows.Forms.Timer(components);
            shortWarning = new RadioButton();
            mediumWarning = new RadioButton();
            longWarning = new RadioButton();
            groupBox1 = new GroupBox();
            SpeedButton = new Button();
            GameTimer = new System.Windows.Forms.Timer(components);
            IJKLWinning = new RichTextBox();
            WASDWinning = new RichTextBox();
            Instructions = new RichTextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // MoveTimer
            // 
            MoveTimer.Enabled = true;
            MoveTimer.Interval = 20;
            MoveTimer.Tick += TimerEvent;
            // 
            // shortWarning
            // 
            shortWarning.AutoSize = true;
            shortWarning.Location = new Point(6, 22);
            shortWarning.Name = "shortWarning";
            shortWarning.Size = new Size(101, 19);
            shortWarning.TabIndex = 3;
            shortWarning.TabStop = true;
            shortWarning.Text = "Short Warning";
            shortWarning.UseVisualStyleBackColor = true;
            shortWarning.CheckedChanged += shortWarning_CheckedChanged;
            // 
            // mediumWarning
            // 
            mediumWarning.AutoSize = true;
            mediumWarning.Location = new Point(6, 47);
            mediumWarning.Name = "mediumWarning";
            mediumWarning.Size = new Size(118, 19);
            mediumWarning.TabIndex = 0;
            mediumWarning.TabStop = true;
            mediumWarning.Text = "Medium Warning";
            mediumWarning.UseVisualStyleBackColor = true;
            mediumWarning.CheckedChanged += mediumWarning_CheckedChanged;
            // 
            // longWarning
            // 
            longWarning.AutoSize = true;
            longWarning.Location = new Point(6, 72);
            longWarning.Name = "longWarning";
            longWarning.Size = new Size(100, 19);
            longWarning.TabIndex = 1;
            longWarning.TabStop = true;
            longWarning.Text = "Long Warning";
            longWarning.UseVisualStyleBackColor = true;
            longWarning.CheckedChanged += longWarning_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(shortWarning);
            groupBox1.Controls.Add(longWarning);
            groupBox1.Controls.Add(mediumWarning);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 100);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Warnings";
            // 
            // SpeedButton
            // 
            SpeedButton.ImageAlign = ContentAlignment.TopLeft;
            SpeedButton.Location = new Point(713, 12);
            SpeedButton.Name = "SpeedButton";
            SpeedButton.Size = new Size(75, 23);
            SpeedButton.TabIndex = 4;
            SpeedButton.Text = "Speed: 20";
            SpeedButton.UseVisualStyleBackColor = true;
            SpeedButton.Click += SpeedButton_Click;
            // 
            // GameTimer
            // 
            GameTimer.Interval = 30000;
            GameTimer.Tick += EventGameTimer;
            // 
            // IJKLWinning
            // 
            IJKLWinning.AcceptsTab = true;
            IJKLWinning.BackColor = SystemColors.ButtonFace;
            IJKLWinning.BorderStyle = BorderStyle.None;
            IJKLWinning.Font = new Font("MV Boli", 48F, FontStyle.Regular, GraphicsUnit.Point);
            IJKLWinning.ForeColor = Color.Red;
            IJKLWinning.Location = new Point(83, 157);
            IJKLWinning.Name = "IJKLWinning";
            IJKLWinning.ReadOnly = true;
            IJKLWinning.Size = new Size(629, 105);
            IJKLWinning.TabIndex = 5;
            IJKLWinning.Text = "Player IJKL WINS";
            IJKLWinning.Visible = false;
            // 
            // WASDWinning
            // 
            WASDWinning.BackColor = SystemColors.ButtonFace;
            WASDWinning.BorderStyle = BorderStyle.None;
            WASDWinning.Font = new Font("MV Boli", 48F, FontStyle.Regular, GraphicsUnit.Point);
            WASDWinning.ForeColor = Color.Red;
            WASDWinning.Location = new Point(74, 157);
            WASDWinning.Name = "WASDWinning";
            WASDWinning.Size = new Size(632, 96);
            WASDWinning.TabIndex = 6;
            WASDWinning.Text = "Player WASD WINS";
            WASDWinning.Visible = false;
            // 
            // Instructions
            // 
            Instructions.Font = new Font("MV Boli", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            Instructions.Location = new Point(83, 157);
            Instructions.Name = "Instructions";
            Instructions.Size = new Size(623, 105);
            Instructions.TabIndex = 7;
            Instructions.Text = "Player WASD catch Player IJKL before the timer runs out! ";
            Instructions.Visible = false;
            // 
            // Form1View
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Instructions);
            Controls.Add(WASDWinning);
            Controls.Add(IJKLWinning);
            Controls.Add(SpeedButton);
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            KeyPreview = true;
            Name = "Form1View";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer MoveTimer;
        private RadioButton shortWarning;
        private RadioButton mediumWarning;
        private RadioButton longWarning;
        private GroupBox groupBox1;
        private Button SpeedButton;
        private System.Windows.Forms.Timer GameTimer;
        private RichTextBox IJKLWinning;
        private RichTextBox WASDWinning;
        private RichTextBox Instructions;
    }
}