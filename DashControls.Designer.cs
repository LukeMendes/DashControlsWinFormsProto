
namespace DashControlsWinFormsProto
{
    partial class DashControls
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
            this.Eingabefeld = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Eingabe = new System.Windows.Forms.Label();
            this.Senden = new System.Windows.Forms.Button();
            this.Meldung = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Eingabefeld
            // 
            this.Eingabefeld.Location = new System.Drawing.Point(71, 367);
            this.Eingabefeld.Name = "Eingabefeld";
            this.Eingabefeld.Size = new System.Drawing.Size(250, 23);
            this.Eingabefeld.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(71, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(250, 267);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // Eingabe
            // 
            this.Eingabe.AutoSize = true;
            this.Eingabe.Location = new System.Drawing.Point(71, 346);
            this.Eingabe.Name = "Eingabe";
            this.Eingabe.Size = new System.Drawing.Size(49, 15);
            this.Eingabe.TabIndex = 2;
            this.Eingabe.Text = "Eingabe\r\n";
            // 
            // Senden
            // 
            this.Senden.Location = new System.Drawing.Point(343, 367);
            this.Senden.Name = "Senden";
            this.Senden.Size = new System.Drawing.Size(75, 23);
            this.Senden.TabIndex = 3;
            this.Senden.Text = "senden";
            this.Senden.UseVisualStyleBackColor = true;
            this.Senden.Click += new System.EventHandler(this.Senden_Click);
            // 
            // Meldung
            // 
            this.Meldung.AutoSize = true;
            this.Meldung.Location = new System.Drawing.Point(71, 299);
            this.Meldung.Name = "Meldung";
            this.Meldung.Size = new System.Drawing.Size(0, 15);
            this.Meldung.TabIndex = 4;
            // 
            // DashControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Meldung);
            this.Controls.Add(this.Senden);
            this.Controls.Add(this.Eingabe);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Eingabefeld);
            this.Name = "DashControls";
            this.Text = "DashControls";
            this.Load += new System.EventHandler(this.DashControls_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Eingabefeld;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label Eingabe;
        private System.Windows.Forms.Button Senden;
        private System.Windows.Forms.Label Meldung;
    }
}

