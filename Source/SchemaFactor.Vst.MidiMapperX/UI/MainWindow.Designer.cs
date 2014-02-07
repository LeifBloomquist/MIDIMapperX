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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Mode = new System.Windows.Forms.Label();
            this.RunModeButton = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.NotePanel = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.MIDIDataCC = new System.Windows.Forms.Label();
            this.MIDIDataOff = new System.Windows.Forms.Label();
            this.MIDIDataOn = new System.Windows.Forms.Label();
            this.MapName = new System.Windows.Forms.Label();
            this.NoteNumber = new System.Windows.Forms.Label();
            this.AboutButton = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.EditModeButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.NotePanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Mode
            // 
            this.Mode.BackColor = System.Drawing.Color.Transparent;
            this.Mode.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mode.ForeColor = System.Drawing.Color.White;
            this.Mode.Location = new System.Drawing.Point(915, 34);
            this.Mode.Margin = new System.Windows.Forms.Padding(0);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(87, 20);
            this.Mode.TabIndex = 34;
            this.Mode.Text = "Mode";
            this.Mode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // RunModeButton
            // 
            this.RunModeButton.BackColor = System.Drawing.Color.Red;
            this.RunModeButton.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunModeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RunModeButton.Location = new System.Drawing.Point(914, 54);
            this.RunModeButton.Name = "RunModeButton";
            this.RunModeButton.Size = new System.Drawing.Size(87, 26);
            this.RunModeButton.TabIndex = 35;
            this.RunModeButton.Text = "Run";
            this.RunModeButton.UseVisualStyleBackColor = false;
            this.RunModeButton.Click += new System.EventHandler(this.RunModeButton_Click);
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(315, 7);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(340, 29);
            this.Logo.TabIndex = 37;
            this.Logo.TabStop = false;
            this.Logo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Debug_DoubleClick);
            // 
            // NotePanel
            // 
            this.NotePanel.BackColor = System.Drawing.Color.Transparent;
            this.NotePanel.Controls.Add(this.MainPanel);
            this.NotePanel.Controls.Add(this.MIDIDataCC);
            this.NotePanel.Controls.Add(this.MIDIDataOff);
            this.NotePanel.Controls.Add(this.MIDIDataOn);
            this.NotePanel.Controls.Add(this.MapName);
            this.NotePanel.Controls.Add(this.NoteNumber);
            this.NotePanel.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotePanel.Location = new System.Drawing.Point(-1, 31);
            this.NotePanel.Name = "NotePanel";
            this.NotePanel.Size = new System.Drawing.Size(910, 484);
            this.NotePanel.TabIndex = 36;
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.BackColor = System.Drawing.Color.Black;
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPanel.Controls.Add(this.DebugLabel);
            this.MainPanel.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainPanel.Location = new System.Drawing.Point(-1, 24);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(908, 460);
            this.MainPanel.TabIndex = 9;
            // 
            // DebugLabel
            // 
            this.DebugLabel.BackColor = System.Drawing.Color.Black;
            this.DebugLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DebugLabel.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugLabel.ForeColor = System.Drawing.Color.Lime;
            this.DebugLabel.Location = new System.Drawing.Point(210, 25);
            this.DebugLabel.Name = "DebugLabel";
            this.DebugLabel.Size = new System.Drawing.Size(539, 188);
            this.DebugLabel.TabIndex = 5;
            this.DebugLabel.Text = "Debug Data";
            this.DebugLabel.Visible = false;
            // 
            // MIDIDataCC
            // 
            this.MIDIDataCC.BackColor = System.Drawing.Color.Transparent;
            this.MIDIDataCC.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIDIDataCC.ForeColor = System.Drawing.Color.White;
            this.MIDIDataCC.Location = new System.Drawing.Point(655, 8);
            this.MIDIDataCC.Name = "MIDIDataCC";
            this.MIDIDataCC.Size = new System.Drawing.Size(225, 22);
            this.MIDIDataCC.TabIndex = 12;
            this.MIDIDataCC.Text = "Data to Send (CC)";
            // 
            // MIDIDataOff
            // 
            this.MIDIDataOff.BackColor = System.Drawing.Color.Transparent;
            this.MIDIDataOff.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIDIDataOff.ForeColor = System.Drawing.Color.White;
            this.MIDIDataOff.Location = new System.Drawing.Point(431, 8);
            this.MIDIDataOff.Name = "MIDIDataOff";
            this.MIDIDataOff.Size = new System.Drawing.Size(225, 22);
            this.MIDIDataOff.TabIndex = 7;
            this.MIDIDataOff.Text = "Data to Send (Note Off)";
            // 
            // MIDIDataOn
            // 
            this.MIDIDataOn.BackColor = System.Drawing.Color.Transparent;
            this.MIDIDataOn.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIDIDataOn.ForeColor = System.Drawing.Color.White;
            this.MIDIDataOn.Location = new System.Drawing.Point(207, 8);
            this.MIDIDataOn.Name = "MIDIDataOn";
            this.MIDIDataOn.Size = new System.Drawing.Size(225, 22);
            this.MIDIDataOn.TabIndex = 8;
            this.MIDIDataOn.Text = "Data to Send (Note On)";
            // 
            // MapName
            // 
            this.MapName.BackColor = System.Drawing.Color.Transparent;
            this.MapName.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapName.ForeColor = System.Drawing.Color.White;
            this.MapName.Location = new System.Drawing.Point(46, 8);
            this.MapName.Name = "MapName";
            this.MapName.Size = new System.Drawing.Size(162, 22);
            this.MapName.TabIndex = 10;
            this.MapName.Text = "Map Name";
            // 
            // NoteNumber
            // 
            this.NoteNumber.BackColor = System.Drawing.Color.Transparent;
            this.NoteNumber.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteNumber.ForeColor = System.Drawing.Color.White;
            this.NoteNumber.Location = new System.Drawing.Point(-6, 8);
            this.NoteNumber.Margin = new System.Windows.Forms.Padding(0);
            this.NoteNumber.Name = "NoteNumber";
            this.NoteNumber.Size = new System.Drawing.Size(51, 22);
            this.NoteNumber.TabIndex = 11;
            this.NoteNumber.Text = "Map#";
            this.NoteNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AboutButton
            // 
            this.AboutButton.BackColor = System.Drawing.Color.Red;
            this.AboutButton.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AboutButton.Location = new System.Drawing.Point(914, 479);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(87, 26);
            this.AboutButton.TabIndex = 38;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = false;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.BackColor = System.Drawing.Color.Red;
            this.OptionsButton.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsButton.Location = new System.Drawing.Point(914, 447);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(87, 26);
            this.OptionsButton.TabIndex = 39;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = false;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // EditModeButton
            // 
            this.EditModeButton.BackColor = System.Drawing.Color.Red;
            this.EditModeButton.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditModeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EditModeButton.Location = new System.Drawing.Point(914, 86);
            this.EditModeButton.Name = "EditModeButton";
            this.EditModeButton.Size = new System.Drawing.Size(87, 26);
            this.EditModeButton.TabIndex = 44;
            this.EditModeButton.Text = "Edit";
            this.EditModeButton.UseVisualStyleBackColor = false;
            this.EditModeButton.Click += new System.EventHandler(this.EditModeButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(915, 424);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Info";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.EditModeButton);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.NotePanel);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.RunModeButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.Size = new System.Drawing.Size(1017, 512);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.NotePanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Mode;
        private System.Windows.Forms.Button RunModeButton;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel NotePanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label DebugLabel;
        private System.Windows.Forms.Label MIDIDataOff;
        private System.Windows.Forms.Label MIDIDataOn;
        private System.Windows.Forms.Label MapName;
        private System.Windows.Forms.Label NoteNumber;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.Button EditModeButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MIDIDataCC;


    }
}

