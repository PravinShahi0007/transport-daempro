using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace BLL
{
    public static class sms
    {
        public static string CheckCreditCard()
        {
            try
            {
                string url = @"https://sandbox.bluesnap.com/services/2/transactions";
                string data = @"<card-transaction xmlns='http://ws.plimus.com'>                     
                     <card-transaction-type>AUTH_ONLY</card-transaction-type>
                     <recurring-transaction>ECOMMERCE</recurring-transaction>
                     <soft-descriptor>DescTest</soft-descriptor>
                     <amount>11.00</amount>
                     <currency>USD</currency>
                     <card-holder-info>
                        <first-name>test first name</first-name>
                        <last-name>test last name</last-name>
                    </card-holder-info>
                    <credit-card>
                        <card-number>4012000033330026</card-number>
                        <security-code>111</security-code>
                        <card-type>VISA</card-type>
                        <expiration-month>07</expiration-month>
                        <expiration-year>2016</expiration-year>
                        </credit-card>
                        </card-transaction>'";

                WebRequest myReq = WebRequest.Create(url);
                myReq.Method = "POST";
                myReq.ContentLength = data.Length;
                myReq.ContentType = "Content-Type: application/xml ";
                //myReq.Credentials = new NetworkCredential("API_1434373849261486328218", "Mo0502181968");
                //CredentialCache yourCredentials = new CredentialCache();
                //yourCredentials.Add(new Uri(url), "Basic", new NetworkCredential("API_1434373849261486328218", "Mo0502181968"));
                string usernamePassword = "API_1434373849261486328218:Mo0502181968";
                                             //API_1434373849261486328218
                UTF8Encoding enc = new UTF8Encoding();
                //ASCIIEncoding enc = new ASCIIEncoding();
                myReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(enc.GetBytes(usernamePassword)));
                //myReq.Headers.Add("Authorization", "Basic QVBJXzE0MzQzNzM4NDkyNjE0ODYzMjgyMTg6TW8wNTAyMTgxOTY4");
                //myReq.Headers.Add("Authorization", "Basic dXNlcm5hbWU6cGFzc3dvcmQ=");

                //using (StreamWriter streamWriter = new StreamWriter(myReq.GetRequestStream(), ASCIIEncoding.ASCII))
                //{
                //    streamWriter.Write(data);
                //    streamWriter.Close();
                //}


                using (Stream ds = myReq.GetRequestStream())
                {
                    ds.Write(enc.GetBytes(data), 0, data.Length);
                }


                WebResponse wr = myReq.GetResponse();
                Stream receiveStream = wr.GetResponseStream();
                StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
                string content = reader.ReadToEnd();
                //Response.Write(content);
                return content;
            }
            catch(Exception ex)
            {
                return ex.Message;
            
            }
        }
        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static string GetBalance()
        {
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = (s, cert, chain, ssl) => true; 
                //WebRequest req = WebRequest.Create("http://www.mobily.ws/api/balance.php?mobile=966549249288&password=m0502181968");
                WebRequest req = WebRequest.Create("http://www.hisms.ws/api.php?get_balance&username=966549249288&password=m0502181968");
                WebResponse resp = req.GetResponse();
                Stream s1 = resp.GetResponseStream();
                StreamReader sr = new StreamReader(s1, Encoding.ASCII);
                string doc = sr.ReadToEnd();
                return doc;
            }
            catch { return ""; }
        }

        private static string ConvertToUnicode(string val)
        {
            string msg2 = string.Empty;

            for (int i = 0; i < val.Length; i++)
            {
                msg2 += convertToUnicode(System.Convert.ToChar(val.Substring(i, 1)));
            }

            return msg2;
        }

        private static string convertToUnicode(char ch)
        {
            System.Text.UnicodeEncoding class1 = new System.Text.UnicodeEncoding();
            byte[] msg = class1.GetBytes(System.Convert.ToString(ch));

            return fourDigits(msg[1] + msg[0].ToString("X"));
        }

        private static string fourDigits(string val)
        {
            string result = string.Empty;

            switch (val.Length)
            {
                case 1: result = "000" + val; break;
                case 2: result = "00" + val; break;
                case 3: result = "0" + val; break;
                case 4: result = val; break;
            }

            return result;
        }

        public static string SendMessage(string msg, string sender, string numbers)
        {
            //ServicePointManager.ServerCertificateValidationCallback = (s, cert, chain, ssl) => true; 
            //int temp = '0';
            if (msg.Length > 70) msg = msg.Substring(0, 69);
           // msg = ConvertToUnicode(msg);
            sender = "Naqelat";
            //HttpWebRequest req = (HttpWebRequest)
            //WebRequest.Create("http://www.mobily.ws/api/msgSend.php");
            //WebRequest.Create("http://www.hisms.ws/api.php");
            if (numbers.StartsWith("+")) numbers = numbers.Substring(1, numbers.Length);
            //req.Method = "POST";
            //req.ContentType = "application/x-www-form-urlencoded";
            //string postData = "mobile=966549249288&password=m0502181968" + "&numbers=" + numbers + "&sender=" + sender + "&msg=" + msg + "&applicationType=24&msgId=0";
            //string postData = "send_sms&username=966549249288&password=m0502181968" + "&numbers=" + numbers + "&sender=" + sender + "&msg=" + msg + "&date=24&time=0";
            string postData = "send_sms&username=966549249288&password=m0502181968" + "&numbers=" + numbers + "&sender=" + sender + "&message=" + msg;
            //req.ContentLength = postData.Length;
            WebRequest req = WebRequest.Create("http://www.hisms.ws/api.php?" + postData);
            WebResponse resp = req.GetResponse();
            Stream s1 = resp.GetResponseStream();
            StreamReader sr = new StreamReader(s1, Encoding.ASCII);
            string strResponse;
           
            strResponse = sr.ReadToEnd();

            /*
            //StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.UTF8);
            stOut.Write(postData);
            stOut.Close();
            // Do the request to get the response
            string strResponse;
            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            strResponse = stIn.ReadToEnd();
            stIn.Close();
             */
            return (strResponse.Length>5 ? "1":strResponse);
        }

        public static string ShowResult(string res)
        {
            switch (res)
            {
                case "1": return "لقد تمت العملية بنجاح";
                case "2": return "الرصيد أنتهى ... أشحن رصيدك";
                case "3": return "الرصيد الحالي لا يكفى لأكمال عملية الإرسال ... أشحن رصيدك";
                case "4": return "اسم المستخدم غير صحيح ... تأكد من اسم المستخدم";
                case "5": return "خطأ في كلمة المرور ... تأكد من كلمة المرور";
                case "6": return "صفحة الإرسال لا تجيب في الوقت الحالي ... حاول مرة أخرى";
                case "12": return "الحساب بحاجة الى تحديث بيانات";
                case "13": return "اسم المرسل غير معرف من قبل";
                case "14": return "اسم المرسل غير معرف من قبل";
                //case "15": return "رقم جوال خاطىء تأكد من صحة الارقام بالصيفة 9665123456789";
                case "15": return "رقم جوال خاطىء تأكد من صحة الارقام";
                case "16": return "أدخل اسم المرسل";
                case "17": return "خطأ في نص الرسال ... تأكد من ادخل النص بصورة صحيحة";
                case "-1": return "عطل فني في السيرفر";
                case "-2": return "عطل فني في قاعدة البيانات";
                case "0": return "لم يتم الارسال بعد";
                default: if (string.IsNullOrEmpty(res)) return "";
                         else return res.ToString();
            }
        }



    }
}
