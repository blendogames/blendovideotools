namespace blendovideotools
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_extension = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_framerate = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_height = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_width = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyLineToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 61);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox_extension);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(552, 35);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File converter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "New file extension:";
            // 
            // textBox_extension
            // 
            this.textBox_extension.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_extension.Location = new System.Drawing.Point(108, 6);
            this.textBox_extension.Name = "textBox_extension";
            this.textBox_extension.Size = new System.Drawing.Size(50, 23);
            this.textBox_extension.TabIndex = 0;
            this.textBox_extension.Text = "png";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.textBox_framerate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(552, 35);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Framerate converter";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "New framerate:";
            // 
            // textBox_framerate
            // 
            this.textBox_framerate.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_framerate.Location = new System.Drawing.Point(91, 6);
            this.textBox_framerate.Name = "textBox_framerate";
            this.textBox_framerate.Size = new System.Drawing.Size(50, 23);
            this.textBox_framerate.TabIndex = 1;
            this.textBox_framerate.Text = "30";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.textBox_height);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBox_width);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(552, 35);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Resize";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(304, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Note: it is ok to leave one field empty";
            // 
            // textBox_height
            // 
            this.textBox_height.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_height.Location = new System.Drawing.Point(186, 6);
            this.textBox_height.Name = "textBox_height";
            this.textBox_height.Size = new System.Drawing.Size(50, 23);
            this.textBox_height.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Height:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Width:";
            // 
            // textBox_width
            // 
            this.textBox_width.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_width.Location = new System.Drawing.Point(47, 7);
            this.textBox_width.Name = "textBox_width";
            this.textBox_width.Size = new System.Drawing.Size(50, 23);
            this.textBox_width.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 88);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(556, 304);
            this.listBox1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLineToClipboardToolStripMenuItem,
            this.copyAllToClipboardToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(243, 70);
            // 
            // copyLineToClipboardToolStripMenuItem
            // 
            this.copyLineToClipboardToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyLineToClipboardToolStripMenuItem.Image")));
            this.copyLineToClipboardToolStripMenuItem.Name = "copyLineToClipboardToolStripMenuItem";
            this.copyLineToClipboardToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.copyLineToClipboardToolStripMenuItem.Text = "Copy selected lines to clipboard";
            this.copyLineToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyLineToClipboardToolStripMenuItem_Click);
            // 
            // copyAllToClipboardToolStripMenuItem
            // 
            this.copyAllToClipboardToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyAllToClipboardToolStripMenuItem.Image")));
            this.copyAllToClipboardToolStripMenuItem.Name = "copyAllToClipboardToolStripMenuItem";
            this.copyAllToClipboardToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.copyAllToClipboardToolStripMenuItem.Text = "Copy entire log to clipboard";
            this.copyAllToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyAllToClipboardToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearAllToolStripMenuItem.Image")));
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.clearAllToolStripMenuItem.Text = "Clear log";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blendo Video Tools";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_extension;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_framerate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyLineToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAllToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_height;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_width;
    }
}

