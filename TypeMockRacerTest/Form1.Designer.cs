namespace ThreadLockSimulator
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonDevice1Send = new System.Windows.Forms.Button();
            this.buttonDevice2Send = new System.Windows.Forms.Button();
            this.buttonDisableCooling = new System.Windows.Forms.Button();
            this.buttonEnableCooling = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 277);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Temperature:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(138, 28);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonDevice1Send
            // 
            this.buttonDevice1Send.Location = new System.Drawing.Point(311, 28);
            this.buttonDevice1Send.Name = "buttonDevice1Send";
            this.buttonDevice1Send.Size = new System.Drawing.Size(203, 23);
            this.buttonDevice1Send.TabIndex = 3;
            this.buttonDevice1Send.Text = "Device 1 Send";
            this.buttonDevice1Send.UseVisualStyleBackColor = true;
            this.buttonDevice1Send.Click += new System.EventHandler(this.buttonDevice1Send_Click);
            // 
            // buttonDevice2Send
            // 
            this.buttonDevice2Send.Location = new System.Drawing.Point(311, 57);
            this.buttonDevice2Send.Name = "buttonDevice2Send";
            this.buttonDevice2Send.Size = new System.Drawing.Size(203, 23);
            this.buttonDevice2Send.TabIndex = 4;
            this.buttonDevice2Send.Text = "Device 2 Send";
            this.buttonDevice2Send.UseVisualStyleBackColor = true;
            this.buttonDevice2Send.Click += new System.EventHandler(this.buttonDevice2Send_Click);
            // 
            // buttonDisableCooling
            // 
            this.buttonDisableCooling.Location = new System.Drawing.Point(311, 102);
            this.buttonDisableCooling.Name = "buttonDisableCooling";
            this.buttonDisableCooling.Size = new System.Drawing.Size(203, 23);
            this.buttonDisableCooling.TabIndex = 5;
            this.buttonDisableCooling.Text = "Cooling Off";
            this.buttonDisableCooling.UseVisualStyleBackColor = true;
            this.buttonDisableCooling.Click += new System.EventHandler(this.buttonDisableCooling_Click);
            // 
            // buttonEnableCooling
            // 
            this.buttonEnableCooling.Location = new System.Drawing.Point(311, 131);
            this.buttonEnableCooling.Name = "buttonEnableCooling";
            this.buttonEnableCooling.Size = new System.Drawing.Size(203, 23);
            this.buttonEnableCooling.TabIndex = 6;
            this.buttonEnableCooling.Text = "Cooling On";
            this.buttonEnableCooling.UseVisualStyleBackColor = true;
            this.buttonEnableCooling.Click += new System.EventHandler(this.buttonEnableCooling_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 310);
            this.Controls.Add(this.buttonEnableCooling);
            this.Controls.Add(this.buttonDisableCooling);
            this.Controls.Add(this.buttonDevice2Send);
            this.Controls.Add(this.buttonDevice1Send);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonDevice1Send;
        private System.Windows.Forms.Button buttonDevice2Send;
        private System.Windows.Forms.Button buttonDisableCooling;
        private System.Windows.Forms.Button buttonEnableCooling;
    }
}

