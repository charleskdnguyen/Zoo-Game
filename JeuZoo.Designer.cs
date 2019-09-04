namespace TP2
{
    partial class JeuZoo
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JeuZoo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblNombreDechet = new System.Windows.Forms.Label();
            this.LblDechet = new System.Windows.Forms.Label();
            this.LblNbAnimauxModifier = new System.Windows.Forms.Label();
            this.LblNbAnimaux = new System.Windows.Forms.Label();
            this.LblProfitModifier = new System.Windows.Forms.Label();
            this.LblArgent = new System.Windows.Forms.Label();
            this.LblJourModifier = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.TimerJeu = new System.Windows.Forms.Timer(this.components);
            this.Map = new TP2.Map();
            this.InformationVisiteur = new TP2.InfoVisiteur();
            this.InformationAnimal = new TP2.InfoAnimal();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblNombreDechet);
            this.panel1.Controls.Add(this.LblDechet);
            this.panel1.Controls.Add(this.LblNbAnimauxModifier);
            this.panel1.Controls.Add(this.LblNbAnimaux);
            this.panel1.Controls.Add(this.LblProfitModifier);
            this.panel1.Controls.Add(this.LblArgent);
            this.panel1.Controls.Add(this.LblJourModifier);
            this.panel1.Controls.Add(this.LblDate);
            this.panel1.Location = new System.Drawing.Point(-1, 675);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 56);
            this.panel1.TabIndex = 1;
            // 
            // LblNombreDechet
            // 
            this.LblNombreDechet.AutoSize = true;
            this.LblNombreDechet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreDechet.Location = new System.Drawing.Point(1039, 19);
            this.LblNombreDechet.Name = "LblNombreDechet";
            this.LblNombreDechet.Size = new System.Drawing.Size(20, 22);
            this.LblNombreDechet.TabIndex = 2;
            this.LblNombreDechet.Text = "0";
            // 
            // LblDechet
            // 
            this.LblDechet.AutoSize = true;
            this.LblDechet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDechet.Location = new System.Drawing.Point(848, 19);
            this.LblDechet.Name = "LblDechet";
            this.LblDechet.Size = new System.Drawing.Size(185, 22);
            this.LblDechet.TabIndex = 2;
            this.LblDechet.Text = "Nombres de déchets: ";
            // 
            // LblNbAnimauxModifier
            // 
            this.LblNbAnimauxModifier.AutoSize = true;
            this.LblNbAnimauxModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNbAnimauxModifier.Location = new System.Drawing.Point(772, 19);
            this.LblNbAnimauxModifier.Name = "LblNbAnimauxModifier";
            this.LblNbAnimauxModifier.Size = new System.Drawing.Size(20, 22);
            this.LblNbAnimauxModifier.TabIndex = 2;
            this.LblNbAnimauxModifier.Text = "0";
            // 
            // LblNbAnimaux
            // 
            this.LblNbAnimaux.AutoSize = true;
            this.LblNbAnimaux.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNbAnimaux.Location = new System.Drawing.Point(593, 19);
            this.LblNbAnimaux.Name = "LblNbAnimaux";
            this.LblNbAnimaux.Size = new System.Drawing.Size(173, 22);
            this.LblNbAnimaux.TabIndex = 2;
            this.LblNbAnimaux.Text = "Nombres d\'animaux:";
            // 
            // LblProfitModifier
            // 
            this.LblProfitModifier.AutoSize = true;
            this.LblProfitModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProfitModifier.Location = new System.Drawing.Point(463, 19);
            this.LblProfitModifier.Name = "LblProfitModifier";
            this.LblProfitModifier.Size = new System.Drawing.Size(30, 22);
            this.LblProfitModifier.TabIndex = 2;
            this.LblProfitModifier.Text = "0$";
            // 
            // LblArgent
            // 
            this.LblArgent.AutoSize = true;
            this.LblArgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblArgent.Location = new System.Drawing.Point(395, 19);
            this.LblArgent.Name = "LblArgent";
            this.LblArgent.Size = new System.Drawing.Size(62, 22);
            this.LblArgent.TabIndex = 2;
            this.LblArgent.Text = "Profit: ";
            // 
            // LblJourModifier
            // 
            this.LblJourModifier.AutoSize = true;
            this.LblJourModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJourModifier.Location = new System.Drawing.Point(127, 19);
            this.LblJourModifier.Name = "LblJourModifier";
            this.LblJourModifier.Size = new System.Drawing.Size(45, 22);
            this.LblJourModifier.TabIndex = 2;
            this.LblJourModifier.Text = "Jour";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDate.Location = new System.Drawing.Point(13, 19);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(108, 22);
            this.LblDate.TabIndex = 2;
            this.LblDate.Text = "Jour actuel: ";
            // 
            // TimerJeu
            // 
            this.TimerJeu.Enabled = true;
            this.TimerJeu.Interval = 820;
            this.TimerJeu.Tick += new System.EventHandler(this.TimerJeu_Tick);
            // 
            // Map
            // 
            this.Map.Location = new System.Drawing.Point(-1, -1);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(1568, 732);
            this.Map.TabIndex = 0;
            this.Map.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Map_KeyDown);
            this.Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_MouseDown);
            // 
            // InformationVisiteur
            // 
            this.InformationVisiteur.Location = new System.Drawing.Point(1262, 461);
            this.InformationVisiteur.Name = "InformationVisiteur";
            this.InformationVisiteur.Size = new System.Drawing.Size(275, 184);
            this.InformationVisiteur.TabIndex = 3;
            this.InformationVisiteur.Visible = false;
            // 
            // InformationAnimal
            // 
            this.InformationAnimal.Location = new System.Drawing.Point(1262, 461);
            this.InformationAnimal.Name = "InformationAnimal";
            this.InformationAnimal.Size = new System.Drawing.Size(275, 240);
            this.InformationAnimal.TabIndex = 4;
            this.InformationAnimal.Visible = false;
            // 
            // JeuZoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1552, 731);
            this.Controls.Add(this.InformationAnimal);
            this.Controls.Add(this.InformationVisiteur);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Map);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JeuZoo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoo Tycoon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JeuZoo_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Map Map;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblArgent;
        private System.Windows.Forms.Label LblJourModifier;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label LblNbAnimauxModifier;
        private System.Windows.Forms.Label LblNbAnimaux;
        private System.Windows.Forms.Label LblProfitModifier;
        private System.Windows.Forms.Label LblNombreDechet;
        private System.Windows.Forms.Label LblDechet;
        private System.Windows.Forms.Timer TimerJeu;
        private InfoVisiteur InformationVisiteur;
        private InfoAnimal InformationAnimal;
    }
}

