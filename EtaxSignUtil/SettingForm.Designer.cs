namespace EtaxSignUtil
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.TextEdit_Type = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.TextEdit_Password = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.TextEdit_Libpath = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.TextEdit_ProviderName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.TextEdit_FileName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.SimpleButton_OK = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.SimpleButton_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Libpath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_ProviderName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_FileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.AllowCustomizationMenu = false;
            this.layoutControl.Controls.Add(this.SimpleButton_Cancel);
            this.layoutControl.Controls.Add(this.SimpleButton_OK);
            this.layoutControl.Controls.Add(this.TextEdit_FileName);
            this.layoutControl.Controls.Add(this.TextEdit_ProviderName);
            this.layoutControl.Controls.Add(this.TextEdit_Libpath);
            this.layoutControl.Controls.Add(this.TextEdit_Password);
            this.layoutControl.Controls.Add(this.TextEdit_Type);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(411, 187);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(411, 187);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // TextEdit_Type
            // 
            this.TextEdit_Type.Location = new System.Drawing.Point(88, 7);
            this.TextEdit_Type.Name = "TextEdit_Type";
            this.TextEdit_Type.Properties.ReadOnly = true;
            this.TextEdit_Type.Size = new System.Drawing.Size(316, 20);
            this.TextEdit_Type.StyleController = this.layoutControl;
            this.TextEdit_Type.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TextEdit_Type;
            this.layoutControlItem1.CustomizationFormText = "Token Type";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(401, 24);
            this.layoutControlItem1.Text = "Token Type";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(78, 13);
            // 
            // TextEdit_Password
            // 
            this.TextEdit_Password.Location = new System.Drawing.Point(88, 31);
            this.TextEdit_Password.Name = "TextEdit_Password";
            this.TextEdit_Password.Properties.PasswordChar = '*';
            this.TextEdit_Password.Size = new System.Drawing.Size(316, 20);
            this.TextEdit_Password.StyleController = this.layoutControl;
            this.TextEdit_Password.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.TextEdit_Password;
            this.layoutControlItem2.CustomizationFormText = "Token Password";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(401, 24);
            this.layoutControlItem2.Text = "Token Password";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(78, 13);
            // 
            // TextEdit_Libpath
            // 
            this.TextEdit_Libpath.Location = new System.Drawing.Point(88, 55);
            this.TextEdit_Libpath.Name = "TextEdit_Libpath";
            this.TextEdit_Libpath.Properties.ReadOnly = true;
            this.TextEdit_Libpath.Size = new System.Drawing.Size(316, 20);
            this.TextEdit_Libpath.StyleController = this.layoutControl;
            this.TextEdit_Libpath.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.TextEdit_Libpath;
            this.layoutControlItem3.CustomizationFormText = "Library Path";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(401, 24);
            this.layoutControlItem3.Text = "Library Path";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(78, 13);
            // 
            // TextEdit_ProviderName
            // 
            this.TextEdit_ProviderName.Location = new System.Drawing.Point(88, 79);
            this.TextEdit_ProviderName.Name = "TextEdit_ProviderName";
            this.TextEdit_ProviderName.Properties.ReadOnly = true;
            this.TextEdit_ProviderName.Size = new System.Drawing.Size(316, 20);
            this.TextEdit_ProviderName.StyleController = this.layoutControl;
            this.TextEdit_ProviderName.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.TextEdit_ProviderName;
            this.layoutControlItem4.CustomizationFormText = "Provider Name";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(401, 24);
            this.layoutControlItem4.Text = "Provider Name";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(78, 13);
            // 
            // TextEdit_FileName
            // 
            this.TextEdit_FileName.Location = new System.Drawing.Point(88, 103);
            this.TextEdit_FileName.Name = "TextEdit_FileName";
            this.TextEdit_FileName.Properties.ReadOnly = true;
            this.TextEdit_FileName.Size = new System.Drawing.Size(316, 20);
            this.TextEdit_FileName.StyleController = this.layoutControl;
            this.TextEdit_FileName.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.TextEdit_FileName;
            this.layoutControlItem5.CustomizationFormText = "File Name";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(401, 24);
            this.layoutControlItem5.Text = "File Name";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(78, 13);
            // 
            // SimpleButton_OK
            // 
            this.SimpleButton_OK.Location = new System.Drawing.Point(7, 158);
            this.SimpleButton_OK.Name = "SimpleButton_OK";
            this.SimpleButton_OK.Size = new System.Drawing.Size(196, 22);
            this.SimpleButton_OK.StyleController = this.layoutControl;
            this.SimpleButton_OK.TabIndex = 9;
            this.SimpleButton_OK.Text = "Save";
            this.SimpleButton_OK.Click += new System.EventHandler(this.SimpleButton_OK_Click);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.SimpleButton_OK;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 151);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(200, 26);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // SimpleButton_Cancel
            // 
            this.SimpleButton_Cancel.Location = new System.Drawing.Point(207, 158);
            this.SimpleButton_Cancel.Name = "SimpleButton_Cancel";
            this.SimpleButton_Cancel.Size = new System.Drawing.Size(197, 22);
            this.SimpleButton_Cancel.StyleController = this.layoutControl;
            this.SimpleButton_Cancel.TabIndex = 10;
            this.SimpleButton_Cancel.Text = "Cancel";
            this.SimpleButton_Cancel.Click += new System.EventHandler(this.SimpleButton_Cancel_Click);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.SimpleButton_Cancel;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(200, 151);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(201, 26);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(401, 31);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 187);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Token Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Libpath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_ProviderName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_FileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit TextEdit_Type;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton SimpleButton_Cancel;
        private DevExpress.XtraEditors.SimpleButton SimpleButton_OK;
        private DevExpress.XtraEditors.TextEdit TextEdit_FileName;
        private DevExpress.XtraEditors.TextEdit TextEdit_ProviderName;
        private DevExpress.XtraEditors.TextEdit TextEdit_Libpath;
        private DevExpress.XtraEditors.TextEdit TextEdit_Password;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}