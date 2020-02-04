using System;
using System.Text;

namespace Vernam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            String str = "Hello, World!";
            VernamResponse response = Encode(str);
            Console.WriteLine(Decode(response));
        }

        public static VernamResponse Encode(String str)
        {
            StringBuilder encoded = new StringBuilder();
            String otp = GenerateOTP(str.Length);

            for (int i = 0; i < str.Length; i++)
            {
                encoded.Append((char)(str[i] ^ otp[i]));
            }

            return new VernamResponse
            {
                OTP = otp,
                EncodedMessage = encoded.ToString()
            };
        }

        public static String Decode(VernamResponse response)
        {
            StringBuilder decoded = new StringBuilder();

            for (int i = 0; i < response.EncodedMessage.Length; i++)
            {
                decoded.Append((char)(response.EncodedMessage[i] ^ response.OTP[i]));
            }

            return decoded.ToString();
        }

        public static String GenerateOTP(int length)
        {
            StringBuilder otp = new StringBuilder();
            Random r = new Random();
            byte[] bytes = new byte[length];

            for (int i = 0; i < length; i++)
            {
                r.NextBytes(bytes);
                char c = (char)bytes[i];
                otp.Append(c);
            }

            return otp.ToString();
        }

    }

}
