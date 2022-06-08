namespace ApplicationLayer.Utils.Orders
{
    internal static class OrderUtils
    {
        public static string GetOrderCode(string x)
        {
            char[] code = x.ToCharArray();

            int numPart = int.Parse(code[5..10]);
            char[] charPart = code[0..5];

            if (numPart < 99999)
            {
                numPart++;
                return new string(charPart) + numPart.ToString("00000");
            }
            else
            {
                if (charPart[4] == 'Z')
                {
                    charPart[4] = 'A';

                    if (charPart[3] == 'Z')
                    {
                        charPart[3] = 'A';
                        if (charPart[2] == 'Z')
                        {
                            charPart[2] = 'A';
                            if (charPart[1] == 'Z')
                            {
                                charPart[1] = 'A';
                                if (charPart[0] == 'Z')
                                {
                                    charPart[0] = 'A';
                                    throw new Exception("No more order codes can be created");
                                }
                                else
                                {
                                    charPart[0]++;
                                    return new string(charPart) + numPart.ToString("00000");
                                }
                            }
                            else
                            {
                                charPart[1]++;
                                return new string(charPart) + numPart.ToString("00000");
                            }
                        }
                        else
                        {
                            charPart[2]++;
                            return new string(charPart) + numPart.ToString("00000");
                        }
                    }
                    else
                    {
                        charPart[3]++;
                        return new string(charPart) + numPart.ToString("00000");
                    }
                }
                else
                {
                    numPart = 0;
                    charPart[4]++;
                    return new string(charPart) + numPart.ToString("00000");
                }
            }
        }
    }
}
