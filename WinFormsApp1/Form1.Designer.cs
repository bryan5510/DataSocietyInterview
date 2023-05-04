namespace WinFormsApp1
{
    partial class Form1
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
            LabLat = new Label();
            LabLon = new Label();
            TxtLat = new TextBox();
            TxtLon = new TextBox();
            BtnGetTemp = new Button();
            LblTemp = new Label();
            SuspendLayout();
            // 
            // LabLat
            // 
            LabLat.AutoSize = true;
            LabLat.Location = new Point(12, 31);
            LabLat.Name = "LabLat";
            LabLat.Size = new Size(84, 25);
            LabLat.TabIndex = 0;
            LabLat.Text = "Latitude: ";
            // 
            // LabLon
            // 
            LabLon.AutoSize = true;
            LabLon.Location = new Point(12, 76);
            LabLon.Name = "LabLon";
            LabLon.Size = new Size(101, 25);
            LabLon.TabIndex = 1;
            LabLon.Text = "Longitude: ";
            // 
            // TxtLat
            // 
            TxtLat.Location = new Point(119, 28);
            TxtLat.Name = "TxtLat";
            TxtLat.Size = new Size(150, 31);
            TxtLat.TabIndex = 2;
            TxtLat.TextChanged += TxtLat_TextChanged;
            TxtLat.Validating += Lat_Validating;
            // 
            // TxtLon
            // 
            TxtLon.Location = new Point(119, 76);
            TxtLon.Name = "TxtLon";
            TxtLon.Size = new Size(150, 31);
            TxtLon.TabIndex = 3;
            TxtLon.Validating += Lon_Validating;
            // 
            // BtnGetTemp
            // 
            BtnGetTemp.Location = new Point(119, 128);
            BtnGetTemp.Name = "BtnGetTemp";
            BtnGetTemp.Size = new Size(158, 34);
            BtnGetTemp.TabIndex = 4;
            BtnGetTemp.Text = "Fetch Weather";
            BtnGetTemp.UseVisualStyleBackColor = true;
            BtnGetTemp.Click += BtnGetTemp_Click;
            // 
            // LblTemp
            // 
            LblTemp.AutoSize = true;
            LblTemp.Location = new Point(119, 180);
            LblTemp.Name = "LblTemp";
            LblTemp.Size = new Size(0, 25);
            LblTemp.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LblTemp);
            Controls.Add(BtnGetTemp);
            Controls.Add(TxtLon);
            Controls.Add(TxtLat);
            Controls.Add(LabLon);
            Controls.Add(LabLat);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabLat;
        private Label LabLon;
        private TextBox TxtLat;
        private TextBox TxtLon;
        private Button BtnGetTemp;
        private Label LblTemp;
    }
}