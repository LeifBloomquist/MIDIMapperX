namespace SchemaFactor.Vst.MidiMapperX
{
    partial class MapNoteDetailsUI
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapNoteDetailsUI));
            this.KeyNameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TriggerNoteNoTxt = new System.Windows.Forms.NumericUpDown();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MIDIBytesOnTxt = new System.Windows.Forms.TextBox();
            this.MIDIBytesOffTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TriggerNoteNoTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(188, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(80, 17);
            label1.TabIndex = 0;
            label1.Text = "Key Name";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // KeyNameTxt
            // 
            this.KeyNameTxt.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyNameTxt.Location = new System.Drawing.Point(276, 12);
            this.KeyNameTxt.Name = "KeyNameTxt";
            this.KeyNameTxt.Size = new System.Drawing.Size(230, 23);
            this.KeyNameTxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(143, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trigger Note#";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "MIDI Data To Send (Note On)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TriggerNoteNoTxt
            // 
            this.TriggerNoteNoTxt.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TriggerNoteNoTxt.Location = new System.Drawing.Point(276, 41);
            this.TriggerNoteNoTxt.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.TriggerNoteNoTxt.Name = "TriggerNoteNoTxt";
            this.TriggerNoteNoTxt.Size = new System.Drawing.Size(53, 23);
            this.TriggerNoteNoTxt.TabIndex = 4;
            // 
            // OKBtn
            // 
            this.OKBtn.BackColor = System.Drawing.Color.Red;
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKBtn.Location = new System.Drawing.Point(522, 10);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 28);
            this.OKBtn.TabIndex = 5;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = false;
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.Red;
            this.CancelBtn.CausesValidation = false;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Location = new System.Drawing.Point(522, 44);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 28);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            // 
            // MIDIBytesOnTxt
            // 
            this.MIDIBytesOnTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.MIDIBytesOnTxt.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIDIBytesOnTxt.Location = new System.Drawing.Point(276, 69);
            this.MIDIBytesOnTxt.Name = "MIDIBytesOnTxt";
            this.MIDIBytesOnTxt.Size = new System.Drawing.Size(230, 23);
            this.MIDIBytesOnTxt.TabIndex = 7;
            this.MIDIBytesOnTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MIDIBytesTxt_KeyPress);
            // 
            // MIDIBytesOffTxt
            // 
            this.MIDIBytesOffTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.MIDIBytesOffTxt.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIDIBytesOffTxt.Location = new System.Drawing.Point(276, 99);
            this.MIDIBytesOffTxt.Name = "MIDIBytesOffTxt";
            this.MIDIBytesOffTxt.Size = new System.Drawing.Size(230, 23);
            this.MIDIBytesOffTxt.TabIndex = 9;
            this.MIDIBytesOffTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MIDIBytesTxt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "MIDI Data To Send (Note Off)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MapNoteDetailsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(612, 134);
            this.Controls.Add(this.MIDIBytesOffTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MIDIBytesOnTxt);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.TriggerNoteNoTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KeyNameTxt);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapNoteDetailsUI";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Note Mapping";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapNoteDetailsUI_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapNoteDetails_FormClosed);
            this.Load += new System.EventHandler(this.MapNoteDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TriggerNoteNoTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox KeyNameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown TriggerNoteNoTxt;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox MIDIBytesOnTxt;
        private System.Windows.Forms.TextBox MIDIBytesOffTxt;
        private System.Windows.Forms.Label label4;
    }
}