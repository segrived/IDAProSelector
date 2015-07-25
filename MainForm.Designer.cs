using System.ComponentModel;
using System.Windows.Forms;

namespace IDAProSelector
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_DetectedVersion = new System.Windows.Forms.Label();
            this.tb_SelectedFileName = new System.Windows.Forms.TextBox();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.btn_Start32bit = new System.Windows.Forms.Button();
            this.btn_Start64bit = new System.Windows.Forms.Button();
            this.cb_RunAsAdmin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detected version:";
            // 
            // lbl_DetectedVersion
            // 
            this.lbl_DetectedVersion.AutoSize = true;
            this.lbl_DetectedVersion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_DetectedVersion.Location = new System.Drawing.Point(138, 10);
            this.lbl_DetectedVersion.Name = "lbl_DetectedVersion";
            this.lbl_DetectedVersion.Size = new System.Drawing.Size(80, 21);
            this.lbl_DetectedVersion.TabIndex = 0;
            this.lbl_DetectedVersion.Text = "__version";
            // 
            // tb_SelectedFileName
            // 
            this.tb_SelectedFileName.Location = new System.Drawing.Point(15, 36);
            this.tb_SelectedFileName.Name = "tb_SelectedFileName";
            this.tb_SelectedFileName.Size = new System.Drawing.Size(370, 20);
            this.tb_SelectedFileName.TabIndex = 1;
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.Location = new System.Drawing.Point(393, 36);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(36, 19);
            this.btn_SelectFile.TabIndex = 2;
            this.btn_SelectFile.Text = "...";
            this.btn_SelectFile.UseVisualStyleBackColor = true;
            this.btn_SelectFile.Click += new System.EventHandler(this.btn_SelectFile_Click);
            // 
            // btn_Start32bit
            // 
            this.btn_Start32bit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Start32bit.Location = new System.Drawing.Point(15, 62);
            this.btn_Start32bit.Name = "btn_Start32bit";
            this.btn_Start32bit.Size = new System.Drawing.Size(189, 55);
            this.btn_Start32bit.TabIndex = 3;
            this.btn_Start32bit.Text = "32-bit";
            this.btn_Start32bit.UseVisualStyleBackColor = true;
            this.btn_Start32bit.Click += new System.EventHandler(this.btn_Start32bit_Click);
            // 
            // btn_Start64bit
            // 
            this.btn_Start64bit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Start64bit.Location = new System.Drawing.Point(237, 62);
            this.btn_Start64bit.Name = "btn_Start64bit";
            this.btn_Start64bit.Size = new System.Drawing.Size(189, 55);
            this.btn_Start64bit.TabIndex = 3;
            this.btn_Start64bit.Text = "64-bit";
            this.btn_Start64bit.UseVisualStyleBackColor = true;
            this.btn_Start64bit.Click += new System.EventHandler(this.btn_Start64bit_Click);
            // 
            // cb_RunAsAdmin
            // 
            this.cb_RunAsAdmin.AutoSize = true;
            this.cb_RunAsAdmin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_RunAsAdmin.Location = new System.Drawing.Point(321, 10);
            this.cb_RunAsAdmin.Name = "cb_RunAsAdmin";
            this.cb_RunAsAdmin.Size = new System.Drawing.Size(106, 21);
            this.cb_RunAsAdmin.TabIndex = 4;
            this.cb_RunAsAdmin.Text = "Run as admin";
            this.cb_RunAsAdmin.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 131);
            this.Controls.Add(this.cb_RunAsAdmin);
            this.Controls.Add(this.btn_Start64bit);
            this.Controls.Add(this.btn_Start32bit);
            this.Controls.Add(this.btn_SelectFile);
            this.Controls.Add(this.tb_SelectedFileName);
            this.Controls.Add(this.lbl_DetectedVersion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IDA Pro Runner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label lbl_DetectedVersion;
        private TextBox tb_SelectedFileName;
        private Button btn_SelectFile;
        private Button btn_Start32bit;
        private Button btn_Start64bit;
        private CheckBox cb_RunAsAdmin;
    }
}

