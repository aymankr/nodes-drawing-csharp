
namespace Projet2
{
    partial class ParametresNoeud
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
            this.epaisseur = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.couleur = new System.Windows.Forms.Label();
            this.texte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epaisseur)).BeginInit();
            this.SuspendLayout();
            // 
            // epaisseur
            // 
            this.epaisseur.Location = new System.Drawing.Point(101, 27);
            this.epaisseur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.epaisseur.Name = "epaisseur";
            this.epaisseur.Size = new System.Drawing.Size(67, 22);
            this.epaisseur.TabIndex = 0;
            this.epaisseur.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Epaisseur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Couleur";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(289, 27);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(289, 81);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // couleur
            // 
            this.couleur.AutoSize = true;
            this.couleur.BackColor = System.Drawing.SystemColors.InfoText;
            this.couleur.Location = new System.Drawing.Point(101, 69);
            this.couleur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.couleur.MinimumSize = new System.Drawing.Size(40, 12);
            this.couleur.Name = "couleur";
            this.couleur.Size = new System.Drawing.Size(40, 17);
            this.couleur.TabIndex = 6;
            this.couleur.Click += new System.EventHandler(this.couleur_Click);
            // 
            // texte
            // 
            this.texte.Location = new System.Drawing.Point(101, 107);
            this.texte.Name = "texte";
            this.texte.Size = new System.Drawing.Size(67, 22);
            this.texte.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Texte";
            // 
            // ParametresNoeud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 171);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.texte);
            this.Controls.Add(this.couleur);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.epaisseur);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ParametresNoeud";
            this.Text = "ParametresNoeud";
            ((System.ComponentModel.ISupportInitialize)(this.epaisseur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown epaisseur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label couleur;
        private System.Windows.Forms.TextBox texte;
        private System.Windows.Forms.Label label1;
    }
}