namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rtbEmployees = new System.Windows.Forms.RichTextBox();
            this.rtbProfessionsDemand = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGroupSize = new System.Windows.Forms.TextBox();
            this.tbGroupCount = new System.Windows.Forms.TextBox();
            this.rtbGroups = new System.Windows.Forms.RichTextBox();
            this.btnProcessGroups = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.tbGroupSize);
            this.splitContainer1.Panel2.Controls.Add(this.tbGroupCount);
            this.splitContainer1.Panel2.Controls.Add(this.rtbGroups);
            this.splitContainer1.Panel2.Controls.Add(this.btnProcessGroups);
            this.splitContainer1.Size = new System.Drawing.Size(814, 390);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.rtbEmployees);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtbProfessionsDemand);
            this.splitContainer2.Size = new System.Drawing.Size(814, 145);
            this.splitContainer2.SplitterDistance = 413;
            this.splitContainer2.TabIndex = 1;
            // 
            // rtbEmployees
            // 
            this.rtbEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbEmployees.Location = new System.Drawing.Point(0, 0);
            this.rtbEmployees.Name = "rtbEmployees";
            this.rtbEmployees.Size = new System.Drawing.Size(413, 145);
            this.rtbEmployees.TabIndex = 0;
            this.rtbEmployees.Text = "Antony engeener doctor driver\nSam doctor driver\nNick doctor engeener\nJanson drive" +
    "r doctor\nCarl doctor driver\nNico doctor driver\nCisco doctor driver engeener";
            // 
            // rtbProfessionsDemand
            // 
            this.rtbProfessionsDemand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbProfessionsDemand.Location = new System.Drawing.Point(0, 0);
            this.rtbProfessionsDemand.Name = "rtbProfessionsDemand";
            this.rtbProfessionsDemand.Size = new System.Drawing.Size(397, 145);
            this.rtbProfessionsDemand.TabIndex = 0;
            this.rtbProfessionsDemand.Text = "driver\ndoctor\nengeener";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(691, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Розм. груп";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(691, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "К. груп";
            // 
            // tbGroupSize
            // 
            this.tbGroupSize.Location = new System.Drawing.Point(690, 115);
            this.tbGroupSize.Name = "tbGroupSize";
            this.tbGroupSize.Size = new System.Drawing.Size(100, 20);
            this.tbGroupSize.TabIndex = 5;
            this.tbGroupSize.Text = "3";
            // 
            // tbGroupCount
            // 
            this.tbGroupCount.Location = new System.Drawing.Point(691, 78);
            this.tbGroupCount.Name = "tbGroupCount";
            this.tbGroupCount.Size = new System.Drawing.Size(100, 20);
            this.tbGroupCount.TabIndex = 4;
            this.tbGroupCount.Text = "2";
            // 
            // rtbGroups
            // 
            this.rtbGroups.Location = new System.Drawing.Point(12, 3);
            this.rtbGroups.Name = "rtbGroups";
            this.rtbGroups.Size = new System.Drawing.Size(663, 182);
            this.rtbGroups.TabIndex = 2;
            this.rtbGroups.Text = "";
            // 
            // btnProcessGroups
            // 
            this.btnProcessGroups.Location = new System.Drawing.Point(691, 3);
            this.btnProcessGroups.Name = "btnProcessGroups";
            this.btnProcessGroups.Size = new System.Drawing.Size(101, 48);
            this.btnProcessGroups.TabIndex = 3;
            this.btnProcessGroups.Text = "Розрахувати групи";
            this.btnProcessGroups.UseVisualStyleBackColor = true;
            this.btnProcessGroups.Click += new System.EventHandler(this.btnProcessGroups_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 390);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox rtbEmployees;
        private System.Windows.Forms.RichTextBox rtbProfessionsDemand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGroupSize;
        private System.Windows.Forms.TextBox tbGroupCount;
        private System.Windows.Forms.RichTextBox rtbGroups;
        private System.Windows.Forms.Button btnProcessGroups;
    }
}

