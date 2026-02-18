namespace EtaxSignUtil
{
    partial class SignETAXForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignETAXForm));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSignPDF = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPreview = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonPreview = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.ButtonSettingToken = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonTestReport = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.CheckEdit_AutoSendMail = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItemAutoSendMail = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_AutoSendMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAutoSendMail)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.AllowCustomizationMenu = false;
            this.layoutControl.Controls.Add(this.CheckEdit_AutoSendMail);
            this.layoutControl.Controls.Add(this.btnExit);
            this.layoutControl.Controls.Add(this.btnSignPDF);
            this.layoutControl.Controls.Add(this.gridControl);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 22);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(484, 339);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(244, 310);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(233, 22);
            this.btnExit.StyleController = this.layoutControl;
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSignPDF
            // 
            this.btnSignPDF.Location = new System.Drawing.Point(7, 310);
            this.btnSignPDF.Name = "btnSignPDF";
            this.btnSignPDF.Size = new System.Drawing.Size(233, 22);
            this.btnSignPDF.StyleController = this.layoutControl;
            this.btnSignPDF.TabIndex = 5;
            this.btnSignPDF.Text = "Sign ETAX";
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(7, 7);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonPreview});
            this.gridControl.Size = new System.Drawing.Size(470, 276);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnDate,
            this.gridColumnUser,
            this.gridColumnPreview});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnID
            // 
            this.gridColumnID.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnID.Caption = "No.";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.OptionsColumn.AllowEdit = false;
            this.gridColumnID.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnID.OptionsFilter.AllowFilter = false;
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            this.gridColumnID.Width = 55;
            // 
            // gridColumnDate
            // 
            this.gridColumnDate.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnDate.Caption = "วันที่";
            this.gridColumnDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnDate.FieldName = "LastUpdated";
            this.gridColumnDate.Name = "gridColumnDate";
            this.gridColumnDate.OptionsColumn.AllowEdit = false;
            this.gridColumnDate.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnDate.OptionsFilter.AllowFilter = false;
            this.gridColumnDate.Visible = true;
            this.gridColumnDate.VisibleIndex = 1;
            this.gridColumnDate.Width = 150;
            // 
            // gridColumnUser
            // 
            this.gridColumnUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnUser.Caption = "โดย";
            this.gridColumnUser.FieldName = "UpdatedUser";
            this.gridColumnUser.Name = "gridColumnUser";
            this.gridColumnUser.OptionsColumn.AllowEdit = false;
            this.gridColumnUser.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnUser.OptionsFilter.AllowFilter = false;
            this.gridColumnUser.Visible = true;
            this.gridColumnUser.VisibleIndex = 2;
            this.gridColumnUser.Width = 120;
            // 
            // gridColumnPreview
            // 
            this.gridColumnPreview.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnPreview.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnPreview.ColumnEdit = this.repositoryItemButtonPreview;
            this.gridColumnPreview.Name = "gridColumnPreview";
            this.gridColumnPreview.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnPreview.OptionsFilter.AllowFilter = false;
            this.gridColumnPreview.Visible = true;
            this.gridColumnPreview.VisibleIndex = 3;
            this.gridColumnPreview.Width = 114;
            // 
            // repositoryItemButtonPreview
            // 
            this.repositoryItemButtonPreview.AutoHeight = false;
            this.repositoryItemButtonPreview.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "PDF", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "XML", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.repositoryItemButtonPreview.Name = "repositoryItemButtonPreview";
            this.repositoryItemButtonPreview.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.CustomizationFormText = "layoutControlGroup";
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItemAutoSendMail});
            this.layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup.Size = new System.Drawing.Size(484, 339);
            this.layoutControlGroup.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup.Text = "layoutControlGroup";
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(474, 280);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnSignPDF;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 303);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(237, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnExit;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(237, 303);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(237, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.Controller = this.barAndDockingController;
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonSettingToken,
            this.ButtonTestReport});
            this.barManager.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonSettingToken),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonTestReport)});
            this.bar1.Text = "Tools";
            // 
            // ButtonSettingToken
            // 
            this.ButtonSettingToken.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ButtonSettingToken.Appearance.Options.UseFont = true;
            this.ButtonSettingToken.Caption = "ตั้งค่า Token";
            this.ButtonSettingToken.Id = 0;
            this.ButtonSettingToken.Name = "ButtonSettingToken";
            this.ButtonSettingToken.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonSettingToken_ItemClick);
            // 
            // ButtonTestReport
            // 
            this.ButtonTestReport.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ButtonTestReport.Appearance.Options.UseFont = true;
            this.ButtonTestReport.Caption = "Test Form";
            this.ButtonTestReport.Id = 1;
            this.ButtonTestReport.Name = "ButtonTestReport";
            this.ButtonTestReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barAndDockingController
            // 
            this.barAndDockingController.PaintStyleName = "Office2003";
            this.barAndDockingController.PropertiesBar.AllowLinkLighting = false;
            // 
            // CheckEdit_AutoSendMail
            // 
            this.CheckEdit_AutoSendMail.EditValue = true;
            this.CheckEdit_AutoSendMail.Location = new System.Drawing.Point(7, 287);
            this.CheckEdit_AutoSendMail.MenuManager = this.barManager;
            this.CheckEdit_AutoSendMail.Name = "CheckEdit_AutoSendMail";
            this.CheckEdit_AutoSendMail.Properties.Caption = "Send Mail";
            this.CheckEdit_AutoSendMail.Size = new System.Drawing.Size(470, 19);
            this.CheckEdit_AutoSendMail.StyleController = this.layoutControl;
            this.CheckEdit_AutoSendMail.TabIndex = 7;
            // 
            // layoutControlItemAutoSendMail
            // 
            this.layoutControlItemAutoSendMail.Control = this.CheckEdit_AutoSendMail;
            this.layoutControlItemAutoSendMail.CustomizationFormText = "layoutControlItemAutoSendMail";
            this.layoutControlItemAutoSendMail.Location = new System.Drawing.Point(0, 280);
            this.layoutControlItemAutoSendMail.Name = "layoutControlItemAutoSendMail";
            this.layoutControlItemAutoSendMail.Size = new System.Drawing.Size(474, 23);
            this.layoutControlItemAutoSendMail.Text = "layoutControlItemAutoSendMail";
            this.layoutControlItemAutoSendMail.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemAutoSendMail.TextToControlDistance = 0;
            this.layoutControlItemAutoSendMail.TextVisible = false;
            // 
            // SignETAXForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignETAXForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign ETAX";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_AutoSendMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAutoSendMail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnSignPDF;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPreview;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonPreview;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUser;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem ButtonSettingToken;
        private DevExpress.XtraBars.BarButtonItem ButtonTestReport;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.CheckEdit CheckEdit_AutoSendMail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemAutoSendMail;
    }
}