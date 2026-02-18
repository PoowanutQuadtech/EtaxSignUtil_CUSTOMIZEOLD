using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EtaxSignUtil
{
    public partial class SettingForm : Form
    {
        public SettingForm(TokenInfo token)
        {
            InitializeComponent();

            this.TextEdit_Type.EditValue = token.Type;
            this.TextEdit_Password.EditValue = token.Password;
            this.TextEdit_Libpath.EditValue = token.LibPath;
            this.TextEdit_ProviderName.EditValue = token.Java_ProviderName;
            this.TextEdit_FileName.EditValue = token.Java_FileName;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BeginInvoke(new MethodInvoker(() => { this.TextEdit_Password.Focus(); }));
        }

        private void SimpleButton_OK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.TextEdit_Password.EditValue.ToString()))
            {
                MessageBox.Show("กรุณาระบุ Token Password");
                return;
            }
            EtaxSignUtil.Properties.Settings.Default.Token_Password = this.TextEdit_Password.EditValue.ToString();
            EtaxSignUtil.Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SimpleButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
