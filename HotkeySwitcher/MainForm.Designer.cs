namespace HotkeySwitcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dgwHotkeySetList = new System.Windows.Forms.DataGridView();
            this.Character = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSetActive = new System.Windows.Forms.Button();
            this.notifyIconHKS = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextmenuTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgwHotkeySetList)).BeginInit();
            this.contextmenuTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwHotkeySetList
            // 
            this.dgwHotkeySetList.AllowUserToAddRows = false;
            this.dgwHotkeySetList.AllowUserToDeleteRows = false;
            this.dgwHotkeySetList.AllowUserToResizeColumns = false;
            this.dgwHotkeySetList.AllowUserToResizeRows = false;
            this.dgwHotkeySetList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwHotkeySetList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgwHotkeySetList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgwHotkeySetList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgwHotkeySetList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwHotkeySetList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Character,
            this.Class,
            this.Description});
            this.dgwHotkeySetList.GridColor = System.Drawing.SystemColors.Control;
            this.dgwHotkeySetList.Location = new System.Drawing.Point(12, 12);
            this.dgwHotkeySetList.MultiSelect = false;
            this.dgwHotkeySetList.Name = "dgwHotkeySetList";
            this.dgwHotkeySetList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgwHotkeySetList.RowHeadersVisible = false;
            this.dgwHotkeySetList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgwHotkeySetList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwHotkeySetList.Size = new System.Drawing.Size(502, 373);
            this.dgwHotkeySetList.TabIndex = 0;
            // 
            // Character
            // 
            this.Character.FillWeight = 10F;
            this.Character.HeaderText = "#";
            this.Character.Name = "Character";
            this.Character.ReadOnly = true;
            // 
            // Class
            // 
            this.Class.FillWeight = 30F;
            this.Class.HeaderText = "Vocation";
            this.Class.Name = "Class";
            this.Class.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.FillWeight = 111.9289F;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(439, 391);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(358, 391);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "Edit";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(277, 391);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSetActive
            // 
            this.btnSetActive.Location = new System.Drawing.Point(12, 391);
            this.btnSetActive.Name = "btnSetActive";
            this.btnSetActive.Size = new System.Drawing.Size(75, 23);
            this.btnSetActive.TabIndex = 4;
            this.btnSetActive.Text = "Set Active";
            this.btnSetActive.UseVisualStyleBackColor = true;
            this.btnSetActive.Click += new System.EventHandler(this.btnSetActive_Click);
            // 
            // notifyIconHKS
            // 
            this.notifyIconHKS.ContextMenuStrip = this.contextmenuTrayMenu;
            this.notifyIconHKS.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconHKS.Icon")));
            this.notifyIconHKS.Text = "HotkeySwitcher";
            this.notifyIconHKS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconHKS_MouseDoubleClick);
            // 
            // contextmenuTrayMenu
            // 
            this.contextmenuTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextmenuTrayMenu.Name = "contextmenuTrayMenu";
            this.contextmenuTrayMenu.Size = new System.Drawing.Size(190, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.showToolStripMenuItem.Text = "Open HotkeySwticher";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 426);
            this.Controls.Add(this.btnSetActive);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgwHotkeySetList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotkeySwitcher";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgwHotkeySetList)).EndInit();
            this.contextmenuTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwHotkeySetList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSetActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Character;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.NotifyIcon notifyIconHKS;
        private System.Windows.Forms.ContextMenuStrip contextmenuTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

