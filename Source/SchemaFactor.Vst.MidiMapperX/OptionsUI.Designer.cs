namespace SchemaFactor.Vst.MidiMapperX
{
    partial class OptionsUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsUI));
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.AllThruCheckbox = new System.Windows.Forms.CheckBox();
            this.ThruCheckbox = new System.Windows.Forms.CheckBox();
            this.SysExCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.BackColor = System.Drawing.Color.Red;
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKBtn.Location = new System.Drawing.Point(280, 10);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 28);
            this.OKBtn.TabIndex = 5;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = false;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.Red;
            this.CancelBtn.CausesValidation = false;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Location = new System.Drawing.Point(280, 44);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 28);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            // 
            // AllThruCheckbox
            // 
            this.AllThruCheckbox.AutoSize = true;
            this.AllThruCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.AllThruCheckbox.Font = new System.Drawing.Font("OCR A Extended", 11.25F);
            this.AllThruCheckbox.ForeColor = System.Drawing.Color.White;
            this.AllThruCheckbox.Location = new System.Drawing.Point(15, 37);
            this.AllThruCheckbox.Name = "AllThruCheckbox";
            this.AllThruCheckbox.Size = new System.Drawing.Size(225, 21);
            this.AllThruCheckbox.TabIndex = 9;
            this.AllThruCheckbox.Text = "MIDI Thru on All Notes";
            this.AllThruCheckbox.UseVisualStyleBackColor = false;
            // 
            // ThruCheckbox
            // 
            this.ThruCheckbox.AutoSize = true;
            this.ThruCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.ThruCheckbox.Font = new System.Drawing.Font("OCR A Extended", 11.25F);
            this.ThruCheckbox.ForeColor = System.Drawing.Color.White;
            this.ThruCheckbox.Location = new System.Drawing.Point(15, 12);
            this.ThruCheckbox.Name = "ThruCheckbox";
            this.ThruCheckbox.Size = new System.Drawing.Size(108, 21);
            this.ThruCheckbox.TabIndex = 8;
            this.ThruCheckbox.Text = "MIDI Thru";
            this.ThruCheckbox.UseVisualStyleBackColor = false;
            // 
            // SysExCheckbox
            // 
            this.SysExCheckbox.AutoSize = true;
            this.SysExCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.SysExCheckbox.Checked = true;
            this.SysExCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SysExCheckbox.Enabled = false;
            this.SysExCheckbox.Font = new System.Drawing.Font("OCR A Extended", 11.25F);
            this.SysExCheckbox.ForeColor = System.Drawing.Color.White;
            this.SysExCheckbox.Location = new System.Drawing.Point(15, 63);
            this.SysExCheckbox.Name = "SysExCheckbox";
            this.SysExCheckbox.Size = new System.Drawing.Size(234, 21);
            this.SysExCheckbox.TabIndex = 10;
            this.SysExCheckbox.Text = "Always use SysEx Events";
            this.SysExCheckbox.UseVisualStyleBackColor = false;
            // 
            // OptionsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(376, 134);
            this.Controls.Add(this.SysExCheckbox);
            this.Controls.Add(this.AllThruCheckbox);
            this.Controls.Add(this.ThruCheckbox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsUI";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.CheckBox AllThruCheckbox;
        private System.Windows.Forms.CheckBox ThruCheckbox;
        private System.Windows.Forms.CheckBox SysExCheckbox;
    }
}