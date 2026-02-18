using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtaxSignUtil
{
    public class TokenInfo
    {
        public string Type => EtaxSignUtil.Properties.Settings.Default.Token_Type;
        public string Password => EtaxSignUtil.Properties.Settings.Default.Token_Password;
        public string LibPath => EtaxSignUtil.Properties.Settings.Default.Token_LibPath;
        public string Java_ProviderName => EtaxSignUtil.Properties.Settings.Default.Token_ProviderName;
        public string Java_FileName => EtaxSignUtil.Properties.Settings.Default.Java_FileName;
        public string NET_ProviderName => "eToken Base Cryptographic Provider";
        public string NET_ProviderName2 => "Microsoft Base Smart Card Crypto Provider";
        public TokenInfo()
        {
            this.UpgradeSetting();
            this.InitSetting();
        }
        private void UpgradeSetting()
        {
            EtaxSignUtil.Properties.Settings.Default.Reload();
            if (EtaxSignUtil.Properties.Settings.Default.IsUpgrade)
            {
                EtaxSignUtil.Properties.Settings.Default.Upgrade();
                EtaxSignUtil.Properties.Settings.Default.IsUpgrade = false;
                EtaxSignUtil.Properties.Settings.Default.Save();
            }
        }
        private void InitSetting()
        {
            EtaxSignUtil.Properties.Settings.Default.Reload();
            if (String.IsNullOrEmpty(EtaxSignUtil.Properties.Settings.Default.Token_Type))
            {
                EtaxSignUtil.Properties.Settings.Default.Token_Type = "PKCS11";
                EtaxSignUtil.Properties.Settings.Default.Token_ProviderName = "Starkey";
                EtaxSignUtil.Properties.Settings.Default.Token_Password = "";
                EtaxSignUtil.Properties.Settings.Default.Token_LibPath = "C:/Windows/System32/eTPKCS11.dll";
                EtaxSignUtil.Properties.Settings.Default.Java_FileName = "etax-1.0.jar";
                EtaxSignUtil.Properties.Settings.Default.Save();
            }
        }
    }
}
