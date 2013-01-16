namespace SchemaFactor.Vst.MidiMapperX
{
    partial class MidiNoteMapperUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MidiNoteMapperUI));
            this.MapListVw = new BufferedListView(); //System.Windows.Forms.ListView();
            this.KeyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TriggerNoteNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SendingMIDIBytesOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SendingMIDIBytesOff = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.AboutBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MapListVw
            // 
            this.MapListVw.BackColor = System.Drawing.Color.Black;
            this.MapListVw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.KeyName,
            this.TriggerNoteNo,
            this.SendingMIDIBytesOn,
            this.SendingMIDIBytesOff});
            this.MapListVw.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapListVw.ForeColor = System.Drawing.Color.White;
            this.MapListVw.FullRowSelect = true;
            this.MapListVw.GridLines = true;
            this.MapListVw.HideSelection = false;
            this.MapListVw.Location = new System.Drawing.Point(5, 6);
            this.MapListVw.MultiSelect = false;
            this.MapListVw.Name = "MapListVw";
            this.MapListVw.Size = new System.Drawing.Size(870, 431);
            this.MapListVw.TabIndex = 0;
            this.MapListVw.UseCompatibleStateImageBehavior = false;
            this.MapListVw.View = System.Windows.Forms.View.Details;
            this.MapListVw.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.MapListVw_ColumnClick);
            this.MapListVw.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.MapListVw_ColumnWidthChanged);
            this.MapListVw.Resize += new System.EventHandler(this.MapListVw_Resize);
            // 
            // KeyName
            // 
            this.KeyName.Text = "Key Name";
            this.KeyName.Width = 223;
            // 
            // TriggerNoteNo
            // 
            this.TriggerNoteNo.Text = "Note#";
            this.TriggerNoteNo.Width = 70;
            // 
            // SendingMIDIBytesOn
            // 
            this.SendingMIDIBytesOn.Text = "MIDI Data To Send (On)";
            this.SendingMIDIBytesOn.Width = 256;
            // 
            // SendingMIDIBytesOff
            // 
            this.SendingMIDIBytesOff.Text = "MIDI Data To Send (Off)";
            this.SendingMIDIBytesOff.Width = 280;
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.Red;
            this.AddBtn.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.Location = new System.Drawing.Point(4, 440);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(85, 23);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "Add...";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.BackColor = System.Drawing.Color.Red;
            this.EditBtn.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.Location = new System.Drawing.Point(94, 440);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(85, 23);
            this.EditBtn.TabIndex = 2;
            this.EditBtn.Text = "Edit...";
            this.EditBtn.UseVisualStyleBackColor = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.Red;
            this.DeleteBtn.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.Location = new System.Drawing.Point(184, 440);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(85, 23);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.Text = "Delete...";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // DebugLabel
            // 
            this.DebugLabel.BackColor = System.Drawing.Color.DarkGray;
            this.DebugLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DebugLabel.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugLabel.ForeColor = System.Drawing.Color.Black;
            this.DebugLabel.Location = new System.Drawing.Point(237, 156);
            this.DebugLabel.Name = "DebugLabel";
            this.DebugLabel.Size = new System.Drawing.Size(425, 136);
            this.DebugLabel.TabIndex = 4;
            this.DebugLabel.Text = "Debug Data";
            this.DebugLabel.Visible = false;
            // 
            // AboutBtn
            // 
            this.AboutBtn.BackColor = System.Drawing.Color.Red;
            this.AboutBtn.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutBtn.Location = new System.Drawing.Point(792, 441);
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(85, 23);
            this.AboutBtn.TabIndex = 5;
            this.AboutBtn.Text = "About...";
            this.AboutBtn.UseVisualStyleBackColor = false;
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(703, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Options...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.OptionsBtn_Click);
            // 
            // MidiNoteMapperUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AboutBtn);
            this.Controls.Add(this.DebugLabel);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.MapListVw);
            this.Name = "MidiNoteMapperUI";
            this.Size = new System.Drawing.Size(880, 467);
            this.Load += new System.EventHandler(this.MidiNoteMapperUI_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MidiNoteMapperUI_MouseDoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.ListView MapListVw;
        private BufferedListView MapListVw;
        private System.Windows.Forms.ColumnHeader TriggerNoteNo;
        private System.Windows.Forms.ColumnHeader KeyName;
        private System.Windows.Forms.ColumnHeader SendingMIDIBytesOn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Label DebugLabel;
        private System.Windows.Forms.Button AboutBtn;
        private System.Windows.Forms.ColumnHeader SendingMIDIBytesOff;
        private System.Windows.Forms.Button button1;

    }
}
