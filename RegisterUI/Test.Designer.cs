namespace RegisterUI
{
    partial class Test
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
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.Label();
            this.getdata = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(23, 24);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(100, 20);
            this.input.TabIndex = 0;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(231, 27);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(628, 305);
            this.output.TabIndex = 3;
            // 
            // getdata
            // 
            this.getdata.Location = new System.Drawing.Point(44, 77);
            this.getdata.Name = "getdata";
            this.getdata.Size = new System.Drawing.Size(75, 23);
            this.getdata.TabIndex = 2;
            this.getdata.Text = "button1";
            this.getdata.UseVisualStyleBackColor = true;
            this.getdata.Click += new System.EventHandler(this.getdata_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 387);
            this.Controls.Add(this.getdata);
            this.Controls.Add(this.output);
            this.Controls.Add(this.input);
            this.Name = "Test";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.Button getdata;
    }
}