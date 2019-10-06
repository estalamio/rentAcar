namespace Projekat_1
{
    partial class frmRezervisanaAuta
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstRezervisanaAuta = new System.Windows.Forms.ListBox();
            this.btnUkiniRezervaciju = new System.Windows.Forms.Button();
            this.btnRezervisiAutomobile = new System.Windows.Forms.Button();
            this.lblVremePristupaAdmina = new System.Windows.Forms.Label();
            this.lblVremePristupa = new System.Windows.Forms.Label();
            this.lblPrezimeAdmina = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.lblImeAdmina = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtRezervisanoAuto = new System.Windows.Forms.TextBox();
            this.lblRezervisanoAuto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trenutne rezervacije:";
            // 
            // lstRezervisanaAuta
            // 
            this.lstRezervisanaAuta.FormattingEnabled = true;
            this.lstRezervisanaAuta.Location = new System.Drawing.Point(12, 56);
            this.lstRezervisanaAuta.Name = "lstRezervisanaAuta";
            this.lstRezervisanaAuta.Size = new System.Drawing.Size(776, 225);
            this.lstRezervisanaAuta.TabIndex = 1;
            this.lstRezervisanaAuta.SelectedIndexChanged += new System.EventHandler(this.lstRezervisanaAuta_SelectedIndexChanged);
            // 
            // btnUkiniRezervaciju
            // 
            this.btnUkiniRezervaciju.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUkiniRezervaciju.Location = new System.Drawing.Point(12, 284);
            this.btnUkiniRezervaciju.Name = "btnUkiniRezervaciju";
            this.btnUkiniRezervaciju.Size = new System.Drawing.Size(389, 70);
            this.btnUkiniRezervaciju.TabIndex = 2;
            this.btnUkiniRezervaciju.Text = "Ukini rezervaciju";
            this.btnUkiniRezervaciju.UseVisualStyleBackColor = true;
            this.btnUkiniRezervaciju.Click += new System.EventHandler(this.btnUkiniRezervaciju_Click);
            // 
            // btnRezervisiAutomobile
            // 
            this.btnRezervisiAutomobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezervisiAutomobile.Location = new System.Drawing.Point(407, 284);
            this.btnRezervisiAutomobile.Name = "btnRezervisiAutomobile";
            this.btnRezervisiAutomobile.Size = new System.Drawing.Size(381, 70);
            this.btnRezervisiAutomobile.TabIndex = 3;
            this.btnRezervisiAutomobile.Text = "Rezervisi automobile";
            this.btnRezervisiAutomobile.UseVisualStyleBackColor = true;
            this.btnRezervisiAutomobile.Click += new System.EventHandler(this.btnRezervisiAutomobile_Click);
            // 
            // lblVremePristupaAdmina
            // 
            this.lblVremePristupaAdmina.AutoSize = true;
            this.lblVremePristupaAdmina.Location = new System.Drawing.Point(108, 617);
            this.lblVremePristupaAdmina.Name = "lblVremePristupaAdmina";
            this.lblVremePristupaAdmina.Size = new System.Drawing.Size(77, 13);
            this.lblVremePristupaAdmina.TabIndex = 119;
            this.lblVremePristupaAdmina.Text = "Vreme pristupa";
            // 
            // lblVremePristupa
            // 
            this.lblVremePristupa.AutoSize = true;
            this.lblVremePristupa.Location = new System.Drawing.Point(9, 617);
            this.lblVremePristupa.Name = "lblVremePristupa";
            this.lblVremePristupa.Size = new System.Drawing.Size(80, 13);
            this.lblVremePristupa.TabIndex = 118;
            this.lblVremePristupa.Text = "Vreme pristupa:";
            // 
            // lblPrezimeAdmina
            // 
            this.lblPrezimeAdmina.AutoSize = true;
            this.lblPrezimeAdmina.Location = new System.Drawing.Point(108, 591);
            this.lblPrezimeAdmina.Name = "lblPrezimeAdmina";
            this.lblPrezimeAdmina.Size = new System.Drawing.Size(81, 13);
            this.lblPrezimeAdmina.TabIndex = 117;
            this.lblPrezimeAdmina.Text = "Prezime admina";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(42, 591);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(47, 13);
            this.label43.TabIndex = 116;
            this.label43.Text = "Prezime:";
            // 
            // lblImeAdmina
            // 
            this.lblImeAdmina.AutoSize = true;
            this.lblImeAdmina.Location = new System.Drawing.Point(108, 568);
            this.lblImeAdmina.Name = "lblImeAdmina";
            this.lblImeAdmina.Size = new System.Drawing.Size(61, 13);
            this.lblImeAdmina.TabIndex = 115;
            this.lblImeAdmina.Text = "Ime admina";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(62, 568);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(27, 13);
            this.label41.TabIndex = 114;
            this.label41.Text = "Ime:";
            // 
            // txtRezervisanoAuto
            // 
            this.txtRezervisanoAuto.Location = new System.Drawing.Point(12, 436);
            this.txtRezervisanoAuto.Name = "txtRezervisanoAuto";
            this.txtRezervisanoAuto.Size = new System.Drawing.Size(389, 20);
            this.txtRezervisanoAuto.TabIndex = 120;
            // 
            // lblRezervisanoAuto
            // 
            this.lblRezervisanoAuto.AutoSize = true;
            this.lblRezervisanoAuto.Location = new System.Drawing.Point(12, 408);
            this.lblRezervisanoAuto.Name = "lblRezervisanoAuto";
            this.lblRezervisanoAuto.Size = new System.Drawing.Size(93, 13);
            this.lblRezervisanoAuto.TabIndex = 121;
            this.lblRezervisanoAuto.Text = "Rezervisano auto:";
            // 
            // frmRezervisanaAuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 660);
            this.Controls.Add(this.lblRezervisanoAuto);
            this.Controls.Add(this.txtRezervisanoAuto);
            this.Controls.Add(this.lblVremePristupaAdmina);
            this.Controls.Add(this.lblVremePristupa);
            this.Controls.Add(this.lblPrezimeAdmina);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.lblImeAdmina);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.btnRezervisiAutomobile);
            this.Controls.Add(this.btnUkiniRezervaciju);
            this.Controls.Add(this.lstRezervisanaAuta);
            this.Controls.Add(this.label1);
            this.Name = "frmRezervisanaAuta";
            this.Text = "frmRezervisanaAuta";
            this.Load += new System.EventHandler(this.frmRezervisanaAuta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstRezervisanaAuta;
        private System.Windows.Forms.Button btnUkiniRezervaciju;
        private System.Windows.Forms.Button btnRezervisiAutomobile;
        private System.Windows.Forms.Label lblVremePristupaAdmina;
        private System.Windows.Forms.Label lblVremePristupa;
        private System.Windows.Forms.Label lblPrezimeAdmina;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label lblImeAdmina;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtRezervisanoAuto;
        private System.Windows.Forms.Label lblRezervisanoAuto;
    }
}