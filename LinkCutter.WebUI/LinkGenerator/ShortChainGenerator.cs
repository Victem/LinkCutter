using System.Text;

namespace LinkCutter.WebUI.LinkGenerator
{
    public static class ShortChainGenerator
    {
        private static readonly string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //private static readonly char[] alphabetChars = alphabet.ToCharArray();
        //private static int alphabetLength = alphabet.Length;

        public static string Encode(long input)
        {
             var chars = new Stack<char>();

            if (input == 0)
            {
                return alphabet[0].ToString();
            }

            while (input > 0)
            {
                var part = input % alphabet.Length;
                chars.Push(alphabet[(int)part]);
                input = input / alphabet.Length;
            }

            return new string(chars.ToArray());
        }

        public static long Decode(string input)
        {
            var inputChars = input.ToCharArray();
            var inputCharsLength = inputChars.Length;
            var decoded = (long)0;
            var counter = 1;

            for (int i = 0; i < inputCharsLength; i++)
            {
                var number = alphabet.IndexOf(inputChars[i]) * Math.Pow(alphabet.Length, inputCharsLength - counter);
                decoded += (long)number;
                counter += 1;
            }

            return decoded;
        }
    }
}
