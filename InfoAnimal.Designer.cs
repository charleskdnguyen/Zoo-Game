namespace TP2
{
    partial class InfoAnimal
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.GbInformationAnimal = new System.Windows.Forms.GroupBox();
            this.BtnSuivant = new System.Windows.Forms.Button();
            this.PicAnimal = new System.Windows.Forms.PictureBox();
            this.LblEnceinteEcrit = new System.Windows.Forms.Label();
            this.LblEnceinte = new System.Windows.Forms.Label();
            this.LblEtatEcrit = new System.Windows.Forms.Label();
            this.LblEtat = new System.Windows.Forms.Label();
            this.LblVieillesseEcrit = new System.Windows.Forms.Label();
            this.LblVieillesse = new System.Windows.Forms.Label();
            this.LblGenreEcrit = new System.Windows.Forms.Label();
            this.LblGenre = new System.Windows.Forms.Label();
            this.LblTypeEcrit = new System.Windows.Forms.Label();
            this.LblType = new System.Windows.Forms.Label();
            this.GbInformationAnimal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAnimal)).BeginInit();
            this.SuspendLayout();
            // 
            // GbInformationAnimal
            // 
            this.GbInformationAnimal.Controls.Add(this.BtnSuivant);
            this.GbInformationAnimal.Controls.Add(this.PicAnimal);
            this.GbInformationAnimal.Controls.Add(this.LblEnceinteEcrit);
            this.GbInformationAnimal.Controls.Add(this.LblEnceinte);
            this.GbInformationAnimal.Controls.Add(this.LblEtatEcrit);
            this.GbInformationAnimal.Controls.Add(this.LblEtat);
            this.GbInformationAnimal.Controls.Add(this.LblVieillesseEcrit);
            this.GbInformationAnimal.Controls.Add(this.LblVieillesse);
            this.GbInformationAnimal.Controls.Add(this.LblGenreEcrit);
            this.GbInformationAnimal.Controls.Add(this.LblGenre);
            this.GbInformationAnimal.Controls.Add(this.LblTypeEcrit);
            this.GbInformationAnimal.Controls.Add(this.LblType);
            this.GbInformationAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbInformationAnimal.Location = new System.Drawing.Point(4, 5);
            this.GbInformationAnimal.Name = "GbInformationAnimal";
            this.GbInformationAnimal.Size = new System.Drawing.Size(267, 246);
            this.GbInformationAnimal.TabIndex = 0;
            this.GbInformationAnimal.TabStop = false;
            this.GbInformationAnimal.Text = "Information de l\'animal";
            // 
            // BtnSuivant
            // 
            this.BtnSuivant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSuivant.Location = new System.Drawing.Point(230, 131);
            this.BtnSuivant.Name = "BtnSuivant";
            this.BtnSuivant.Size = new System.Drawing.Size(30, 22);
            this.BtnSuivant.TabIndex = 2;
            this.BtnSuivant.Text = ">";
            this.BtnSuivant.UseVisualStyleBackColor = true;
            this.BtnSuivant.Click += new System.EventHandler(this.BtnSuivant_click);
            // 
            // PicAnimal
            // 
            this.PicAnimal.Location = new System.Drawing.Point(15, 24);
            this.PicAnimal.Name = "PicAnimal";
            this.PicAnimal.Size = new System.Drawing.Size(67, 61);
            this.PicAnimal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicAnimal.TabIndex = 1;
            this.PicAnimal.TabStop = false;
            // 
            // LblEnceinteEcrit
            // 
            this.LblEnceinteEcrit.AutoSize = true;
            this.LblEnceinteEcrit.Location = new System.Drawing.Point(132, 200);
            this.LblEnceinteEcrit.Name = "LblEnceinteEcrit";
            this.LblEnceinteEcrit.Size = new System.Drawing.Size(58, 22);
            this.LblEnceinteEcrit.TabIndex = 0;
            this.LblEnceinteEcrit.Text = "label1";
            // 
            // LblEnceinte
            // 
            this.LblEnceinte.AutoSize = true;
            this.LblEnceinte.Location = new System.Drawing.Point(11, 200);
            this.LblEnceinte.Name = "LblEnceinte";
            this.LblEnceinte.Size = new System.Drawing.Size(85, 22);
            this.LblEnceinte.TabIndex = 0;
            this.LblEnceinte.Text = "Enceinte:";
            // 
            // LblEtatEcrit
            // 
            this.LblEtatEcrit.AutoSize = true;
            this.LblEtatEcrit.Location = new System.Drawing.Point(132, 172);
            this.LblEtatEcrit.Name = "LblEtatEcrit";
            this.LblEtatEcrit.Size = new System.Drawing.Size(113, 22);
            this.LblEtatEcrit.TabIndex = 0;
            this.LblEtatEcrit.Text = "Faim, 2 jours";
            // 
            // LblEtat
            // 
            this.LblEtat.AutoSize = true;
            this.LblEtat.Location = new System.Drawing.Point(11, 172);
            this.LblEtat.Name = "LblEtat";
            this.LblEtat.Size = new System.Drawing.Size(47, 22);
            this.LblEtat.TabIndex = 0;
            this.LblEtat.Text = "Etat:";
            // 
            // LblVieillesseEcrit
            // 
            this.LblVieillesseEcrit.AutoSize = true;
            this.LblVieillesseEcrit.Location = new System.Drawing.Point(132, 144);
            this.LblVieillesseEcrit.Name = "LblVieillesseEcrit";
            this.LblVieillesseEcrit.Size = new System.Drawing.Size(58, 22);
            this.LblVieillesseEcrit.TabIndex = 0;
            this.LblVieillesseEcrit.Text = "label1";
            // 
            // LblVieillesse
            // 
            this.LblVieillesse.AutoSize = true;
            this.LblVieillesse.Location = new System.Drawing.Point(11, 144);
            this.LblVieillesse.Name = "LblVieillesse";
            this.LblVieillesse.Size = new System.Drawing.Size(91, 22);
            this.LblVieillesse.TabIndex = 0;
            this.LblVieillesse.Text = "Vieillesse:";
            // 
            // LblGenreEcrit
            // 
            this.LblGenreEcrit.AutoSize = true;
            this.LblGenreEcrit.Location = new System.Drawing.Point(132, 116);
            this.LblGenreEcrit.Name = "LblGenreEcrit";
            this.LblGenreEcrit.Size = new System.Drawing.Size(58, 22);
            this.LblGenreEcrit.TabIndex = 0;
            this.LblGenreEcrit.Text = "label1";
            // 
            // LblGenre
            // 
            this.LblGenre.AutoSize = true;
            this.LblGenre.Location = new System.Drawing.Point(11, 116);
            this.LblGenre.Name = "LblGenre";
            this.LblGenre.Size = new System.Drawing.Size(65, 22);
            this.LblGenre.TabIndex = 0;
            this.LblGenre.Text = "Genre:";
            // 
            // LblTypeEcrit
            // 
            this.LblTypeEcrit.AutoSize = true;
            this.LblTypeEcrit.Location = new System.Drawing.Point(132, 88);
            this.LblTypeEcrit.Name = "LblTypeEcrit";
            this.LblTypeEcrit.Size = new System.Drawing.Size(58, 22);
            this.LblTypeEcrit.TabIndex = 0;
            this.LblTypeEcrit.Text = "label1";
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Location = new System.Drawing.Point(11, 88);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(56, 22);
            this.LblType.TabIndex = 0;
            this.LblType.Text = "Type:";
            // 
            // InfoAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GbInformationAnimal);
            this.Name = "InfoAnimal";
            this.Size = new System.Drawing.Size(275, 254);
            this.GbInformationAnimal.ResumeLayout(false);
            this.GbInformationAnimal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAnimal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbInformationAnimal;
        private System.Windows.Forms.PictureBox PicAnimal;
        private System.Windows.Forms.Label LblEnceinteEcrit;
        private System.Windows.Forms.Label LblEnceinte;
        private System.Windows.Forms.Label LblEtatEcrit;
        private System.Windows.Forms.Label LblEtat;
        private System.Windows.Forms.Label LblVieillesseEcrit;
        private System.Windows.Forms.Label LblVieillesse;
        private System.Windows.Forms.Label LblGenreEcrit;
        private System.Windows.Forms.Label LblGenre;
        private System.Windows.Forms.Label LblTypeEcrit;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Button BtnSuivant;
    }
}
