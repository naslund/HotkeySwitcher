namespace HotkeySwitcher
{
    partial class HotkeySetForm
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
            this.grpAddNewSet = new System.Windows.Forms.GroupBox();
            this.rbtnImport = new System.Windows.Forms.RadioButton();
            this.rbtnCurrentlyActive = new System.Windows.Forms.RadioButton();
            this.txtChosenFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbVocation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ofdChooseFile = new System.Windows.Forms.OpenFileDialog();
            this.rbtnDontChange = new System.Windows.Forms.RadioButton();
            this.grpAddNewSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAddNewSet
            // 
            this.grpAddNewSet.Controls.Add(this.rbtnDontChange);
            this.grpAddNewSet.Controls.Add(this.rbtnImport);
            this.grpAddNewSet.Controls.Add(this.rbtnCurrentlyActive);
            this.grpAddNewSet.Controls.Add(this.txtChosenFile);
            this.grpAddNewSet.Controls.Add(this.label3);
            this.grpAddNewSet.Controls.Add(this.cmbVocation);
            this.grpAddNewSet.Controls.Add(this.label2);
            this.grpAddNewSet.Controls.Add(this.btnChooseFile);
            this.grpAddNewSet.Controls.Add(this.label1);
            this.grpAddNewSet.Controls.Add(this.txtInfo);
            this.grpAddNewSet.Location = new System.Drawing.Point(12, 12);
            this.grpAddNewSet.Name = "grpAddNewSet";
            this.grpAddNewSet.Size = new System.Drawing.Size(248, 148);
            this.grpAddNewSet.TabIndex = 0;
            this.grpAddNewSet.TabStop = false;
            this.grpAddNewSet.Text = "Add New Set";
            // 
            // rbtnImport
            // 
            this.rbtnImport.AutoSize = true;
            this.rbtnImport.Location = new System.Drawing.Point(78, 71);
            this.rbtnImport.Name = "rbtnImport";
            this.rbtnImport.Size = new System.Drawing.Size(54, 17);
            this.rbtnImport.TabIndex = 3;
            this.rbtnImport.TabStop = true;
            this.rbtnImport.Text = "Import";
            this.rbtnImport.UseVisualStyleBackColor = true;
            this.rbtnImport.CheckedChanged += new System.EventHandler(this.rbtnImport_CheckedChanged);
            // 
            // rbtnCurrentlyActive
            // 
            this.rbtnCurrentlyActive.AutoSize = true;
            this.rbtnCurrentlyActive.Location = new System.Drawing.Point(168, 97);
            this.rbtnCurrentlyActive.Name = "rbtnCurrentlyActive";
            this.rbtnCurrentlyActive.Size = new System.Drawing.Size(74, 17);
            this.rbtnCurrentlyActive.TabIndex = 6;
            this.rbtnCurrentlyActive.TabStop = true;
            this.rbtnCurrentlyActive.Text = "From Tibia";
            this.rbtnCurrentlyActive.UseVisualStyleBackColor = true;
            this.rbtnCurrentlyActive.CheckedChanged += new System.EventHandler(this.rbtnCurrentlyActive_CheckedChanged);
            // 
            // txtChosenFile
            // 
            this.txtChosenFile.Location = new System.Drawing.Point(78, 120);
            this.txtChosenFile.Name = "txtChosenFile";
            this.txtChosenFile.ReadOnly = true;
            this.txtChosenFile.Size = new System.Drawing.Size(164, 20);
            this.txtChosenFile.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vocation:";
            // 
            // cmbVocation
            // 
            this.cmbVocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVocation.FormattingEnabled = true;
            this.cmbVocation.Location = new System.Drawing.Point(78, 41);
            this.cmbVocation.Name = "cmbVocation";
            this.cmbVocation.Size = new System.Drawing.Size(164, 21);
            this.cmbVocation.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File:";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(142, 68);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(100, 23);
            this.btnChooseFile.TabIndex = 4;
            this.btnChooseFile.Text = "Choose File...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Info:";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(78, 15);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(164, 20);
            this.txtInfo.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(104, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(185, 166);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ofdChooseFile
            // 
            this.ofdChooseFile.FileName = "Tibia.cfg";
            // 
            // rbtnDontChange
            // 
            this.rbtnDontChange.AutoSize = true;
            this.rbtnDontChange.Location = new System.Drawing.Point(72, 97);
            this.rbtnDontChange.Name = "rbtnDontChange";
            this.rbtnDontChange.Size = new System.Drawing.Size(90, 17);
            this.rbtnDontChange.TabIndex = 5;
            this.rbtnDontChange.TabStop = true;
            this.rbtnDontChange.Text = "Don\'t Change";
            this.rbtnDontChange.UseVisualStyleBackColor = true;
            this.rbtnDontChange.CheckedChanged += new System.EventHandler(this.rbtnDontChange_CheckedChanged);
            // 
            // HotkeySetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 200);
            this.Controls.Add(this.grpAddNewSet);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotkeySetForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotkeySetForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HotkeySetForm_FormClosing);
            this.grpAddNewSet.ResumeLayout(false);
            this.grpAddNewSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddNewSet;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.ComboBox cmbVocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog ofdChooseFile;
        private System.Windows.Forms.TextBox txtChosenFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton rbtnImport;
        private System.Windows.Forms.RadioButton rbtnCurrentlyActive;
        private System.Windows.Forms.RadioButton rbtnDontChange;
    }
}