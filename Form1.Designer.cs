namespace Editor_obrázků
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlacitko_ulozit = new System.Windows.Forms.Button();
            this.tlacitko_otevrit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.posuvnik = new System.Windows.Forms.TrackBar();
            this.seznamEfektu = new System.Windows.Forms.ComboBox();
            this.tlacitko_proved = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posuvnik)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tlacitko_ulozit);
            this.groupBox1.Controls.Add(this.tlacitko_otevrit);
            this.groupBox1.Location = new System.Drawing.Point(1332, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ovládání";
            // 
            // tlacitko_ulozit
            // 
            this.tlacitko_ulozit.Enabled = false;
            this.tlacitko_ulozit.Location = new System.Drawing.Point(6, 58);
            this.tlacitko_ulozit.Name = "tlacitko_ulozit";
            this.tlacitko_ulozit.Size = new System.Drawing.Size(124, 31);
            this.tlacitko_ulozit.TabIndex = 3;
            this.tlacitko_ulozit.Text = "Uložit";
            this.tlacitko_ulozit.UseVisualStyleBackColor = true;
            this.tlacitko_ulozit.Click += new System.EventHandler(this.tlacitko_ulozit_Click);
            // 
            // tlacitko_otevrit
            // 
            this.tlacitko_otevrit.Location = new System.Drawing.Point(6, 21);
            this.tlacitko_otevrit.Name = "tlacitko_otevrit";
            this.tlacitko_otevrit.Size = new System.Drawing.Size(124, 31);
            this.tlacitko_otevrit.TabIndex = 2;
            this.tlacitko_otevrit.Text = "Otevřít";
            this.tlacitko_otevrit.UseVisualStyleBackColor = true;
            this.tlacitko_otevrit.Click += new System.EventHandler(this.tlacitko_otevrit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.posuvnik);
            this.groupBox2.Controls.Add(this.seznamEfektu);
            this.groupBox2.Controls.Add(this.tlacitko_proved);
            this.groupBox2.Location = new System.Drawing.Point(1332, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 707);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Efekty";
            // 
            // posuvnik
            // 
            this.posuvnik.Location = new System.Drawing.Point(9, 58);
            this.posuvnik.Maximum = 50;
            this.posuvnik.Name = "posuvnik";
            this.posuvnik.Size = new System.Drawing.Size(121, 56);
            this.posuvnik.TabIndex = 2;
            this.posuvnik.TickFrequency = 10;
            this.posuvnik.Visible = false;
            // 
            // seznamEfektu
            // 
            this.seznamEfektu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seznamEfektu.Enabled = false;
            this.seznamEfektu.FormattingEnabled = true;
            this.seznamEfektu.Items.AddRange(new object[] {
            "Invertovat barvy",
            "Rozmazat",
            "Zesvětlit",
            "Ztmavit"});
            this.seznamEfektu.Location = new System.Drawing.Point(9, 120);
            this.seznamEfektu.Name = "seznamEfektu";
            this.seznamEfektu.Size = new System.Drawing.Size(121, 24);
            this.seznamEfektu.TabIndex = 2;
            this.seznamEfektu.SelectedIndexChanged += new System.EventHandler(this.seznamEfektu_SelectedIndexChanged);
            // 
            // tlacitko_proved
            // 
            this.tlacitko_proved.Enabled = false;
            this.tlacitko_proved.Location = new System.Drawing.Point(9, 21);
            this.tlacitko_proved.Name = "tlacitko_proved";
            this.tlacitko_proved.Size = new System.Drawing.Size(121, 31);
            this.tlacitko_proved.TabIndex = 4;
            this.tlacitko_proved.Text = "Proveď";
            this.tlacitko_proved.UseVisualStyleBackColor = true;
            this.tlacitko_proved.Click += new System.EventHandler(this.tlacitko_proved_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 953);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Editor obrázků";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posuvnik)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button tlacitko_ulozit;
        private System.Windows.Forms.Button tlacitko_otevrit;
        private System.Windows.Forms.Button tlacitko_proved;
        private System.Windows.Forms.ComboBox seznamEfektu;
        private System.Windows.Forms.TrackBar posuvnik;
    }
}

