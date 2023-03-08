namespace CharInString
{
    public class CharInStringService
    {
        public static int GetCharAmount(string str, char c)
        {
            var qty = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    qty ++;
            }
            return qty;
        }
    }
}
