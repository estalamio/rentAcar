namespace Projekat_1
{
    partial class frmDobrodoslice
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
            this.lblDobrodosli = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnKorisnik = new System.Windows.Forms.Button();
            this.lblTipNaloga = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDobrodosli
            // 
            this.lblDobrodosli.AutoSize = true;
            this.lblDobrodosli.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDobrodosli.Location = new System.Drawing.Point(198, 14);
            this.lblDobrodosli.Name = "lblDobrodosli";
            this.lblDobrodosli.Size = new System.Drawing.Size(368, 73);
            this.lblDobrodosli.TabIndex = 0;
            this.lblDobrodosli.Text = "Dobrodosli!";
            // 
            // btnAdmin
            // 
            this.btnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.Location = new System.Drawing.Point(211, 173);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(177, 175);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "ADMINISTRATOR";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnKorisnik
            // 
            this.btnKorisnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKorisnik.Location = new System.Drawing.Point(389, 173);
            this.btnKorisnik.Name = "btnKorisnik";
            this.btnKorisnik.Size = new System.Drawing.Size(177, 175);
            this.btnKorisnik.TabIndex = 2;
            this.btnKorisnik.Text = "KORISNIK";
            this.btnKorisnik.UseVisualStyleBackColor = true;
            this.btnKorisnik.Click += new System.EventHandler(this.btnKorisnik_Click);
            // 
            // lblTipNaloga
            // 
            this.lblTipNaloga.AutoSize = true;
            this.lblTipNaloga.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipNaloga.Location = new System.Drawing.Point(253, 87);
            this.lblTipNaloga.Name = "lblTipNaloga";
            this.lblTipNaloga.Size = new System.Drawing.Size(251, 31);
            this.lblTipNaloga.TabIndex = 3;
            this.lblTipNaloga.Text = "Izaberite tip naloga:";
            // 
            // frmDobrodoslice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTipNaloga);
            this.Controls.Add(this.btnKorisnik);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.lblDobrodosli);
            this.Name = "frmDobrodoslice";
            this.Text = "frmDobrodoslice";
            this.Load += new System.EventHandler(this.frmDobrodoslice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDobrodosli;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnKorisnik;
        private System.Windows.Forms.Label lblTipNaloga;
    }
}