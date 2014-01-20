namespace SchemaFactor.Vst.MidiMapperX
{
    partial class MainWindow
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
            this.AboutButton = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.NotePanel = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.MIDIDataOff = new System.Windows.Forms.Label();
            this.MIDIDataOn = new System.Windows.Forms.Label();
            this.MapName = new System.Windows.Forms.Label();
            this.NoteNumber = new System.Windows.Forms.Label();
            this.NoteMapTabButton = new System.Windows.Forms.Button();
            this.CCMapTabButton = new System.Windows.Forms.Button();
            this.ModeButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Mode = new System.Windows.Forms.Label();
            this.NotePanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AboutButton
            // 
            this.AboutButton.BackColor = System.Drawing.Color.Red;
            this.AboutButton.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AboutButton.Location = new System.Drawing.Point(917, 461);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(98, 26);
            this.AboutButton.TabIndex = 11;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = false;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.BackColor = System.Drawing.Color.Red;
            this.OptionsButton.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsButton.Location = new System.Drawing.Point(918, 429);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(96, 26);
            this.OptionsButton.TabIndex = 12;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = false;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // NotePanel
            // 
            this.NotePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NotePanel.Controls.Add(this.MainPanel);
            this.NotePanel.Controls.Add(this.MIDIDataOff);
            this.NotePanel.Controls.Add(this.MIDIDataOn);
            this.NotePanel.Controls.Add(this.MapName);
            this.NotePanel.Controls.Add(this.NoteNumber);
            this.NotePanel.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotePanel.Location = new System.Drawing.Point(3, 3);
            this.NotePanel.Name = "NotePanel";
            this.NotePanel.Size = new System.Drawing.Size(910, 484);
            this.NotePanel.TabIndex = 15;
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.BackColor = System.Drawing.Color.Black;
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPanel.Controls.Add(this.DebugLabel);
            this.MainPanel.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainPanel.Location = new System.Drawing.Point(-2, 24);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(910, 458);
            this.MainPanel.TabIndex = 9;
            // 
            // DebugLabel
            // 
            this.DebugLabel.BackColor = System.Drawing.Color.DarkGray;
            this.DebugLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DebugLabel.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugLabel.ForeColor = System.Drawing.Color.Black;
            this.DebugLabel.Location = new System.Drawing.Point(101, 33);
            this.DebugLabel.Name = "DebugLabel";
            this.DebugLabel.Size = new System.Drawing.Size(539, 188);
            this.DebugLabel.TabIndex = 5;
            this.DebugLabel.Text = "Debug Data";
            // 
            // MIDIDataOff
            // 
            this.MIDIDataOff.BackColor = System.Drawing.Color.Black;
            this.MIDIDataOff.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIDIDataOff.ForeColor = System.Drawing.Color.White;
            this.MIDIDataOff.Location = new System.Drawing.Point(583, 9);
            this.MIDIDataOff.Name = "MIDIDataOff";
            this.MIDIDataOff.Size = new System.Drawing.Size(300, 22);
            this.MIDIDataOff.TabIndex = 7;
            this.MIDIDataOff.Text = "MIDI Data to Send (Note Off)";
            // 
            // MIDIDataOn
            // 
            this.MIDIDataOn.BackColor = System.Drawing.Color.Black;
            this.MIDIDataOn.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIDIDataOn.ForeColor = System.Drawing.Color.White;
            this.MIDIDataOn.Location = new System.Drawing.Point(284, 9);
            this.MIDIDataOn.Name = "MIDIDataOn";
            this.MIDIDataOn.Size = new System.Drawing.Size(300, 22);
            this.MIDIDataOn.TabIndex = 8;
            this.MIDIDataOn.Text = "MIDI Data to Send (Note On)";
            // 
            // MapName
            // 
            this.MapName.BackColor = System.Drawing.Color.Black;
            this.MapName.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapName.ForeColor = System.Drawing.Color.White;
            this.MapName.Location = new System.Drawing.Point(75, 9);
            this.MapName.Name = "MapName";
            this.MapName.Size = new System.Drawing.Size(210, 22);
            this.MapName.TabIndex = 10;
            this.MapName.Text = "Map Name";
            // 
            // NoteNumber
            // 
            this.NoteNumber.BackColor = System.Drawing.Color.Black;
            this.NoteNumber.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteNumber.ForeColor = System.Drawing.Color.White;
            this.NoteNumber.Location = new System.Drawing.Point(21, 9);
            this.NoteNumber.Margin = new System.Windows.Forms.Padding(0);
            this.NoteNumber.Name = "NoteNumber";
            this.NoteNumber.Size = new System.Drawing.Size(51, 22);
            this.NoteNumber.TabIndex = 11;
            this.NoteNumber.Text = "Note#";
            this.NoteNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NoteMapTabButton
            // 
            this.NoteMapTabButton.BackColor = System.Drawing.Color.Red;
            this.NoteMapTabButton.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteMapTabButton.ForeColor = System.Drawing.Color.Black;
            this.NoteMapTabButton.Location = new System.Drawing.Point(918, 108);
            this.NoteMapTabButton.Name = "NoteMapTabButton";
            this.NoteMapTabButton.Size = new System.Drawing.Size(97, 26);
            this.NoteMapTabButton.TabIndex = 12;
            this.NoteMapTabButton.Text = "Note Maps";
            this.NoteMapTabButton.UseVisualStyleBackColor = false;
            // 
            // CCMapTabButton
            // 
            this.CCMapTabButton.BackColor = System.Drawing.Color.Red;
            this.CCMapTabButton.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCMapTabButton.ForeColor = System.Drawing.Color.Black;
            this.CCMapTabButton.Location = new System.Drawing.Point(918, 149);
            this.CCMapTabButton.Name = "CCMapTabButton";
            this.CCMapTabButton.Size = new System.Drawing.Size(97, 26);
            this.CCMapTabButton.TabIndex = 12;
            this.CCMapTabButton.Text = "CC Maps";
            this.CCMapTabButton.UseVisualStyleBackColor = false;
            // 
            // ModeButton
            // 
            this.ModeButton.BackColor = System.Drawing.Color.Red;
            this.ModeButton.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ModeButton.Location = new System.Drawing.Point(918, 61);
            this.ModeButton.Name = "ModeButton";
            this.ModeButton.Size = new System.Drawing.Size(97, 26);
            this.ModeButton.TabIndex = 16;
            this.ModeButton.Text = "Run Mode";
            this.ModeButton.UseVisualStyleBackColor = false;
            this.ModeButton.Click += new System.EventHandler(this.ModeButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(918, 213);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 26);
            this.button3.TabIndex = 12;
            this.button3.Text = "Copy Map";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(918, 254);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 26);
            this.button4.TabIndex = 12;
            this.button4.Text = "Paste Map";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // Mode
            // 
            this.Mode.BackColor = System.Drawing.Color.Black;
            this.Mode.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mode.ForeColor = System.Drawing.Color.White;
            this.Mode.Location = new System.Drawing.Point(941, 36);
            this.Mode.Margin = new System.Windows.Forms.Padding(0);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(51, 22);
            this.Mode.TabIndex = 17;
            this.Mode.Text = "Mode";
            this.Mode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.ModeButton);
            this.Controls.Add(this.NotePanel);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.CCMapTabButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.NoteMapTabButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.Size = new System.Drawing.Size(1021, 491);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.NotePanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.Panel NotePanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label MIDIDataOff;
        private System.Windows.Forms.Label MIDIDataOn;
        private System.Windows.Forms.Label MapName;
        private System.Windows.Forms.Label NoteNumber;
        private System.Windows.Forms.Button NoteMapTabButton;
        private System.Windows.Forms.Button CCMapTabButton;
        private System.Windows.Forms.Button ModeButton;
        private System.Windows.Forms.Label DebugLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label Mode;

    }
}

