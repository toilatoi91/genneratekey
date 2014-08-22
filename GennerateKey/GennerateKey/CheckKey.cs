

using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace GennerateKey
{
  public class CheckKey
  {
    private static string LK = "";
    private static bool bExit;
    public static string mac = "";

    static CheckKey()
    {
    }

    public static string GetProductNo()
    {
      return CheckKey.GetProductNo(DateTime.Now.Second.ToString());
    }

    public static void SetKey(string key)
    {
      CheckKey.LK = key;
    }

    public static bool CheckLicense()
    {
      if (CheckKey.CheckValidLicense(CheckKey.LK))
        return true;
      Console.Write("Key không hợp lệ, mã máy là: " + CheckKey.GetProductNo());
      return false;
    }

    private static string GetMacAdd()
    {
      //try
      //{
      //  string str = "";
      //  using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True").Get().GetEnumerator())
      //  {
      //    if (enumerator.MoveNext())
      //        str = enumerator.Current["MacAddress"].ToString().Replace(":", "").Replace("9", "0").Replace("8", "9").Replace("7", "8").Replace("6", "7").Replace("5", "6").Replace("4", "5").Replace("3", "4").Replace("2", "3").Replace("1", "2").Replace("0", "1");
      //  }
      //  return str;
      //}
      //catch (Exception ex)
      //{
      //  return "";
      //}

        // hàm mới 

        ManagementObjectCollection mbsList = null;
        ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
        mbsList = mbs.Get();
        string id = "";
        foreach (ManagementObject mo in mbsList)
        {
            id = mo["ProcessorID"].ToString();
        }
        ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
        ManagementObjectCollection moc = mos.Get();
        string motherBoard = "";
        foreach (ManagementObject mo in moc)
        {
            motherBoard = (string)mo["SerialNumber"];
        }
        return (id + motherBoard).Replace("9", "0").Replace("8", "9").Replace("7", "8").Replace("6", "7").Replace("5", "6").Replace("4", "5").Replace("3", "4").Replace("2", "3").Replace("1", "2").Replace("0", "1");
    }

    private static string GetProductNo(string ss)
    {
        if (ss.Length == 1)
            ss = ss + 1;
      string str1 = CheckKey.MD5Encrypt(mac);
      string str2 = CheckKey.MD5Encrypt(str1.Replace(str1[1], ss[0]).Replace(str1[3], ss[1])).Substring(16).ToUpper();
      return str2.Substring(0, 4) + "-" + str2.Substring(4, 4) + "-" + str2.Substring(8, 4).Replace(str2[10], ss[0]).Replace(str2[11], ss[1]) + "-" + str2.Substring(12, 4);
    }

    public static string GetLicenseKey(string ss)
    {
      string str = CheckKey.MD5Encrypt(CheckKey.MD5Encrypt(CheckKey.GetProductNo(ss).Replace("-", "")).Substring(0, 20)).Substring(16).ToUpper();
      return str.Substring(0, 4).Replace(str[1], ss[0]).Replace(str[3], ss[1]) + "-" + str.Substring(4, 4) + "-" + str.Substring(8, 4) + "-" + str.Substring(12, 4);
    }
    public static string GetLicenseKey2(string ss)
    {
        string str = CheckKey.MD5Encrypt(CheckKey.MD5Encrypt(ss.Replace("-", "")).Substring(0, 20)).Substring(16).ToUpper();
        return str.Substring(0, 4).Replace(str[1], ss[0]).Replace(str[3], ss[1]) + "-" + str.Substring(4, 4) + "-" + str.Substring(8, 4) + "-" + str.Substring(12, 4);
    }

    public static bool CheckValidLicense(string sLicenseKey)
    {
      return sLicenseKey.Length >= 4 && sLicenseKey == CheckKey.GetLicenseKey(sLicenseKey[1].ToString() + sLicenseKey[3].ToString());
    }

    private static string MD5Encrypt(string str)
    {
      string str1 = "";
      MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
      byte[] bytes = Encoding.UTF8.GetBytes(str);
      byte[] hash = cryptoServiceProvider.ComputeHash(bytes);
      cryptoServiceProvider.Clear();
      for (int index = 0; index < hash.Length; ++index)
        str1 = str1 + hash[index].ToString("x").PadLeft(2, '0');
      return str1;
    }
  }
}
