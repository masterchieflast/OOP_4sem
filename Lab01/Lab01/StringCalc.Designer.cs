namespace Lab01
{
    partial class StringCalc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.replaceSubstring = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNewString = new System.Windows.Forms.TextBox();
            this.txtOldString = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtRemoveString = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.findByIndex = new System.Windows.Forms.Button();
            this.butLength = new System.Windows.Forms.Button();
            this.butVowels = new System.Windows.Forms.Button();
            this.butConsonants = new System.Windows.Forms.Button();
            this.butWordsPerLine = new System.Windows.Forms.Button();
            this.butOffers = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.txtResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 156);
            this.panel1.TabIndex = 0;
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(15, 13);
            this.txtResult.Margin = new System.Windows.Forms.Padding(0);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(969, 120);
            this.txtResult.TabIndex = 0;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(20, 67);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(248, 72);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "delete all substring";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // replaceSubstring
            // 
            this.replaceSubstring.Location = new System.Drawing.Point(20, 67);
            this.replaceSubstring.Name = "replaceSubstring";
            this.replaceSubstring.Size = new System.Drawing.Size(248, 72);
            this.replaceSubstring.TabIndex = 2;
            this.replaceSubstring.Text = "replace substring";
            this.replaceSubstring.UseVisualStyleBackColor = true;
            this.replaceSubstring.Click += new System.EventHandler(this.replaceSubstring_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.txtNewString);
            this.panel2.Controls.Add(this.txtOldString);
            this.panel2.Controls.Add(this.replaceSubstring);
            this.panel2.Location = new System.Drawing.Point(15, 186);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 159);
            this.panel2.TabIndex = 3;
            // 
            // txtNewString
            // 
            this.txtNewString.Location = new System.Drawing.Point(168, 27);
            this.txtNewString.Multiline = true;
            this.txtNewString.Name = "txtNewString";
            this.txtNewString.Size = new System.Drawing.Size(100, 31);
            this.txtNewString.TabIndex = 4;
            // 
            // txtOldString
            // 
            this.txtOldString.Location = new System.Drawing.Point(20, 27);
            this.txtOldString.Multiline = true;
            this.txtOldString.Name = "txtOldString";
            this.txtOldString.Size = new System.Drawing.Size(117, 31);
            this.txtOldString.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.txtRemoveString);
            this.panel3.Controls.Add(this.btnRemove);
            this.panel3.Location = new System.Drawing.Point(696, 186);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(288, 159);
            this.panel3.TabIndex = 5;
            // 
            // txtRemoveString
            // 
            this.txtRemoveString.Location = new System.Drawing.Point(20, 27);
            this.txtRemoveString.Multiline = true;
            this.txtRemoveString.Name = "txtRemoveString";
            this.txtRemoveString.Size = new System.Drawing.Size(248, 31);
            this.txtRemoveString.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.txtIndex);
            this.panel4.Controls.Add(this.findByIndex);
            this.panel4.Location = new System.Drawing.Point(353, 186);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(288, 159);
            this.panel4.TabIndex = 6;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(20, 27);
            this.txtIndex.Multiline = true;
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(248, 31);
            this.txtIndex.TabIndex = 3;
            // 
            // findByIndex
            // 
            this.findByIndex.Location = new System.Drawing.Point(20, 67);
            this.findByIndex.Name = "findByIndex";
            this.findByIndex.Size = new System.Drawing.Size(248, 72);
            this.findByIndex.TabIndex = 1;
            this.findByIndex.Text = "find by index";
            this.findByIndex.UseVisualStyleBackColor = true;
            this.findByIndex.Click += new System.EventHandler(this.findByIndex_Click);
            // 
            // butLength
            // 
            this.butLength.Location = new System.Drawing.Point(20, 24);
            this.butLength.Name = "butLength";
            this.butLength.Size = new System.Drawing.Size(142, 96);
            this.butLength.TabIndex = 7;
            this.butLength.Text = "Length";
            this.butLength.UseVisualStyleBackColor = true;
            this.butLength.Click += new System.EventHandler(this.butLength_Click);
            // 
            // butVowels
            // 
            this.butVowels.Location = new System.Drawing.Point(211, 24);
            this.butVowels.Name = "butVowels";
            this.butVowels.Size = new System.Drawing.Size(142, 96);
            this.butVowels.TabIndex = 8;
            this.butVowels.Text = "count vowels";
            this.butVowels.UseVisualStyleBackColor = true;
            this.butVowels.Click += new System.EventHandler(this.butVowels_Click);
            // 
            // butConsonants
            // 
            this.butConsonants.Location = new System.Drawing.Point(403, 24);
            this.butConsonants.Name = "butConsonants";
            this.butConsonants.Size = new System.Drawing.Size(142, 96);
            this.butConsonants.TabIndex = 9;
            this.butConsonants.Text = "count consonants";
            this.butConsonants.UseVisualStyleBackColor = true;
            this.butConsonants.Click += new System.EventHandler(this.butConsonants_Click);
            // 
            // butWordsPerLine
            // 
            this.butWordsPerLine.Location = new System.Drawing.Point(807, 24);
            this.butWordsPerLine.Name = "butWordsPerLine";
            this.butWordsPerLine.Size = new System.Drawing.Size(142, 96);
            this.butWordsPerLine.TabIndex = 10;
            this.butWordsPerLine.Text = "count words per line";
            this.butWordsPerLine.UseVisualStyleBackColor = true;
            this.butWordsPerLine.Click += new System.EventHandler(this.butWordsPerLine_Click);
            // 
            // butOffers
            // 
            this.butOffers.Location = new System.Drawing.Point(604, 24);
            this.butOffers.Name = "butOffers";
            this.butOffers.Size = new System.Drawing.Size(142, 96);
            this.butOffers.TabIndex = 11;
            this.butOffers.Text = "count   offers";
            this.butOffers.UseVisualStyleBackColor = true;
            this.butOffers.Click += new System.EventHandler(this.butOffers_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.butWordsPerLine);
            this.panel5.Controls.Add(this.butOffers);
            this.panel5.Controls.Add(this.butLength);
            this.panel5.Controls.Add(this.butVowels);
            this.panel5.Controls.Add(this.butConsonants);
            this.panel5.Location = new System.Drawing.Point(15, 375);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(969, 145);
            this.panel5.TabIndex = 12;
            // 
            // StringCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(1001, 558);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Name = "StringCalc";
            this.Text = "StringCalc";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button replaceSubstring;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNewString;
        private System.Windows.Forms.TextBox txtOldString;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtRemoveString;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Button findByIndex;
        private System.Windows.Forms.Button butLength;
        private System.Windows.Forms.Button butVowels;
        private System.Windows.Forms.Button butConsonants;
        private System.Windows.Forms.Button butWordsPerLine;
        private System.Windows.Forms.Button butOffers;
        private System.Windows.Forms.Panel panel5;
    }
}