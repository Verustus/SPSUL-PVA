namespace GUI_1 {
    partial class Form1 {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent() {
            this.fightButton = new System.Windows.Forms.Button();
            this.shufflePlayersButton = new System.Windows.Forms.Button();
            this.playerGroup = new System.Windows.Forms.Panel();
            this.playerA = new System.Windows.Forms.Label();
            this.playerB = new System.Windows.Forms.Label();
            this.playerGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // fightButton
            // 
            this.fightButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fightButton.AutoSize = true;
            this.fightButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fightButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fightButton.Location = new System.Drawing.Point(347, 385);
            this.fightButton.Name = "fightButton";
            this.fightButton.Padding = new System.Windows.Forms.Padding(40, 10, 40, 10);
            this.fightButton.Size = new System.Drawing.Size(120, 43);
            this.fightButton.TabIndex = 0;
            this.fightButton.Text = "Fight";
            this.fightButton.UseVisualStyleBackColor = true;
            this.fightButton.Click += new System.EventHandler(this.FightClick);
            // 
            // shufflePlayersButton
            // 
            this.shufflePlayersButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.shufflePlayersButton.AutoSize = true;
            this.shufflePlayersButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.shufflePlayersButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.shufflePlayersButton.Location = new System.Drawing.Point(325, 336);
            this.shufflePlayersButton.Name = "shufflePlayersButton";
            this.shufflePlayersButton.Padding = new System.Windows.Forms.Padding(40, 10, 40, 10);
            this.shufflePlayersButton.Size = new System.Drawing.Size(167, 43);
            this.shufflePlayersButton.TabIndex = 1;
            this.shufflePlayersButton.Text = "Shuffle Players";
            this.shufflePlayersButton.UseVisualStyleBackColor = true;
            this.shufflePlayersButton.Click += new System.EventHandler(this.ShufflePlayers);
            // 
            // playerGroup
            // 
            this.playerGroup.Controls.Add(this.playerA);
            this.playerGroup.Controls.Add(this.playerB);
            this.playerGroup.Location = new System.Drawing.Point(101, 66);
            this.playerGroup.Name = "playerGroup";
            this.playerGroup.Size = new System.Drawing.Size(600, 50);
            this.playerGroup.TabIndex = 5;
            // 
            // playerA
            // 
            this.playerA.AutoSize = true;
            this.playerA.Dock = System.Windows.Forms.DockStyle.Left;
            this.playerA.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.playerA.Location = new System.Drawing.Point(0, 0);
            this.playerA.Name = "playerA";
            this.playerA.Size = new System.Drawing.Size(200, 32);
            this.playerA.TabIndex = 4;
            this.playerA.Text = "Shuffle please";
            this.playerA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // playerB
            // 
            this.playerB.AutoSize = true;
            this.playerB.Dock = System.Windows.Forms.DockStyle.Right;
            this.playerB.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.playerB.Location = new System.Drawing.Point(400, 0);
            this.playerB.Name = "playerB";
            this.playerB.Size = new System.Drawing.Size(200, 32);
            this.playerB.TabIndex = 3;
            this.playerB.Text = "Shuffle please";
            this.playerB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playerGroup);
            this.Controls.Add(this.shufflePlayersButton);
            this.Controls.Add(this.fightButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Resize += new System.EventHandler(this.OnResize);
            this.playerGroup.ResumeLayout(false);
            this.playerGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fightButton;
        private System.Windows.Forms.Button shufflePlayersButton;
        private System.Windows.Forms.Panel playerGroup;
        private System.Windows.Forms.Label playerA;
        private System.Windows.Forms.Label playerB;
    }
}

