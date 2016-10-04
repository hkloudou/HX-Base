﻿namespace Aisino.FTaxBase
{
    using ns2;
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class SignSvrAPI : ISignAPI
    {
        public SignSvrAPI()
        {
            
        }

        public int CloseDevice(IntPtr intptr_0)
        {
            if (intptr_0 != IntPtr.Zero)
            {
                Crypt_Logout(intptr_0);
                Crypt_CloseDevice(intptr_0);
                intptr_0 = IntPtr.Zero;
            }
            return 0;
        }

        [DllImport("AuthClt.dll")]
        public static extern int Crypt_CloseDevice(IntPtr intptr_0);
        [DllImport("AuthClt.dll")]
        public static extern int Crypt_Login(IntPtr intptr_0, string string_0);
        [DllImport("AuthClt.dll")]
        public static extern int Crypt_Logout(IntPtr intptr_0);
        [DllImport("AuthClt.dll")]
        public static extern int Crypt_OpenDevice(ref IntPtr intptr_0, string string_0 = "slot1", string string_1 = "authclt", uint uint_0 = 0x604, uint uint_1 = 0);
        [DllImport("AuthClt.dll")]
        public static extern int Crypt_ReadCert(IntPtr intptr_0, uint uint_0, byte[] byte_0, ref uint uint_1);
        [DllImport("AuthClt.dll")]
        public static extern int Crypt_SignData(IntPtr intptr_0, byte[] byte_0, uint uint_0, uint uint_1, ref DATE_TIME date_TIME_0, uint uint_2, byte[] byte_1, ref uint uint_3);
        [DllImport("AuthClt.dll")]
        public static extern int Crypt_VerifySignedData(IntPtr intptr_0, byte[] byte_0, uint uint_0, uint uint_1, byte[] byte_1, uint uint_2, byte[] byte_2, uint uint_3);
        public int GetCertInfo(IntPtr intptr_0, CertInfo certInfo_0)
        {
            Class20.smethod_1("=========================读取证书信息开始==========================");
            int num = 0;
            certInfo_0.Nsrsbh = string.Empty;
            certInfo_0.Qsrq = string.Empty;
            certInfo_0.Jzrq = string.Empty;
            if (intptr_0 == IntPtr.Zero)
            {
                Class20.smethod_1("=========================句柄为空==========================");
                return 0x25;
            }
            byte[] buffer2 = new byte[0x2800];
            uint num4 = 0x2800;
            num = Crypt_ReadCert(intptr_0, 2, buffer2, ref num4);
            if (num != 0)
            {
                Class20.smethod_1(string.Format("调用证书接口读取证书{0}", num));
                return num;
            }
            uint num2 = 0;
            uint num3 = 50;
            byte[] buffer = new byte[50];
            num = GetCertInfo(num4, buffer2, 0x47, ref num2, ref num3, buffer);
            if (num != 0)
            {
                Class20.smethod_1(string.Format("获取证书中的税号 {0}", num));
                return num;
            }
            certInfo_0.Nsrsbh = Encoding.GetEncoding("GBK").GetString(buffer, 0, (int) num3);
            uint num5 = 50;
            byte[] buffer3 = new byte[50];
            num = GetCertInfo(num4, buffer2, 0x15, ref num2, ref num5, buffer3);
            if (num != 0)
            {
                Class20.smethod_1(string.Format("获取证书证书起始时间 {0}", num));
                return num;
            }
            certInfo_0.Qsrq = Encoding.GetEncoding("GBK").GetString(buffer3, 0, (int) num5);
            uint num6 = 50;
            byte[] buffer4 = new byte[50];
            num = GetCertInfo(num4, buffer2, 0x16, ref num2, ref num6, buffer4);
            if (num != 0)
            {
                Class20.smethod_1(string.Format("获取证书证书无效时间 {0}", num));
                return num;
            }
            certInfo_0.Jzrq = Encoding.GetEncoding("GBK").GetString(buffer4, 0, (int) num6);
            Class20.smethod_1("=========================读取证书信息结束==========================");
            return num;
        }

        [DllImport("decodecert.dll")]
        public static extern int GetCertInfo(uint uint_0, byte[] byte_0, uint uint_1, ref uint uint_2, ref uint uint_3, byte[] byte_1);
        public int OpenDevice(ref IntPtr intptr_0, string string_0, string string_1, string string_2)
        {
            int num = -1;
            string str = string.Empty;
            string invSignServer = CommonTool.GetInvSignServer();
            if (!string.IsNullOrWhiteSpace(invSignServer))
            {
                foreach (string str3 in invSignServer.Split(new char[] { ';' }))
                {
                    string[] strArray3 = str3.Split(new char[] { '=' });
                    if (strArray3[0].Trim() == string_1)
                    {
                        str = strArray3[1];
                        break;
                    }
                }
            }
            if (string.Empty.Equals(str))
            {
                str = "slot1";
            }
            num = Crypt_OpenDevice(ref intptr_0, str, string_2, 0x604, 0);
            Class20.smethod_1(string.Format("打开设备,返回值：{0},句柄：{1}", num, (IntPtr) intptr_0));
            if (num == 0)
            {
                num = Crypt_Login(intptr_0, string_0);
            }
            return num;
        }

        public int SignData(IntPtr intptr_0, string string_0, string string_1, out string string_2)
        {
            string_2 = "";
            if (intptr_0 == IntPtr.Zero)
            {
                return 0x25;
            }
            int num = Crypt_Login(intptr_0, string_1);
            if (num != 0)
            {
                Class20.smethod_2(string.Format("签名时登录密码:{0}", string_1));
                return num;
            }
            byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(string_0);
            byte[] buffer = new byte[0x400];
            uint num2 = 0x400;
            DATE_TIME date_time = new DATE_TIME();
            int num3 = Crypt_SignData(intptr_0, bytes, (uint) bytes.Length, 6, ref date_time, 0, buffer, ref num2);
            if (num3 != 0)
            {
                Class20.smethod_1("=============================SignData：返回值=============================" + num3);
                return num3;
            }
            string_2 = Convert.ToBase64String(buffer, 0, (int) num2);
            return num3;
        }

        public int VerifySignedData(IntPtr intptr_0, string string_0, string string_1)
        {
            if (intptr_0 == IntPtr.Zero)
            {
                return 0x25;
            }
            byte[] buffer = Convert.FromBase64String(string_1);
            byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(string_0);
            Class20.smethod_1("VerifySignedData验证前");
            int num = Crypt_VerifySignedData(intptr_0, buffer, (uint) buffer.Length, 0, bytes, (uint) bytes.Length, null, 0);
            Class20.smethod_1("VerifySignedData验证后，方法结束" + num);
            return num;
        }
    }
}

