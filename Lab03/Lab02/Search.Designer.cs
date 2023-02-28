namespace Lab03
{
    partial class Search
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
            this.LectureName = new System.Windows.Forms.TextBox();
            this.Filter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sem1 = new System.Windows.Forms.CheckBox();
            this.sem2 = new System.Windows.Forms.CheckBox();
            this.Course = new System.Windows.Forms.Label();
            this.CourseBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.CourseBar)).BeginInit();
            this.SuspendLayout();
            // 
            // LectureName
            // 
            this.LectureName.Location = new System.Drawing.Point(66, 70);
            this.LectureName.Multiline = true;
            this.LectureName.Name = "LectureName";
            this.LectureName.Size = new System.Drawing.Size(242, 44);
            this.LectureName.TabIndex = 1;
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(66, 381);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(239, 46);
            this.Filter.TabIndex = 10;
            this.Filter.Text = "search";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "Lecturer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 32);
            this.label2.TabIndex = 13;
            this.label2.Text = "Semester";
            // 
            // sem1
            // 
            this.sem1.AutoSize = true;
            this.sem1.Location = new System.Drawing.Point(66, 161);
            this.sem1.Name = "sem1";
            this.sem1.Size = new System.Drawing.Size(59, 36);
            this.sem1.TabIndex = 16;
            this.sem1.Text = "1";
            this.sem1.UseVisualStyleBackColor = true;
            // 
            // sem2
            // 
            this.sem2.AutoSize = true;
            this.sem2.Location = new System.Drawing.Point(66, 203);
            this.sem2.Name = "sem2";
            this.sem2.Size = new System.Drawing.Size(59, 36);
            this.sem2.TabIndex = 18;
            this.sem2.Text = "2";
            this.sem2.UseVisualStyleBackColor = true;
            // 
            // Course
            // 
            this.Course.AutoSize = true;
            this.Course.Location = new System.Drawing.Point(66, 257);
            this.Course.Name = "Course";
            this.Course.Size = new System.Drawing.Size(113, 32);
            this.Course.TabIndex = 30;
            this.Course.Text = "Course: 1";
            // 
            // CourseBar
            // 
            this.CourseBar.Location = new System.Drawing.Point(66, 300);
            this.CourseBar.Maximum = 4;
            this.CourseBar.Minimum = 1;
            this.CourseBar.Name = "CourseBar";
            this.CourseBar.Size = new System.Drawing.Size(208, 90);
            this.CourseBar.TabIndex = 29;
            this.CourseBar.Value = 1;
            this.CourseBar.Scroll += new System.EventHandler(this.CourseBar_Scroll);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(392, 501);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.Course);
            this.Controls.Add(this.CourseBar);
            this.Controls.Add(this.sem2);
            this.Controls.Add(this.sem1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LectureName);
            this.Name = "Search";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.CourseBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox LectureName;
        private Button Filter;
        private Label label1;
        private Label label2;
        private CheckBox sem1;
        private CheckBox sem2;
        private Label Course;
        private TrackBar CourseBar;
    }
}