namespace AppUtils.Orders
{
	public static class OrderUtils
	{
		public static string GetOrderCode(string x)
		{
			char[] code = x.ToCharArray();

			char[] charPart = code.AsSpan(0, 5).ToArray();

			int numPart = int.Parse(x[5..]);

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

					return Recur(charPart, numPart, 3);
				}
				else
				{
					numPart = 0;
					charPart[4]++;
					return new string(charPart) + numPart.ToString("00000");
				}
			}
		}

		private static string Recur(char[] charPart, int numPart, int i)
		{
			if (charPart[i] == 'Z')
			{
				charPart[i] = 'A';
				if (i > 0)
				{
					return Recur(charPart, numPart, i - 1);
				}
				else
				{
					if (charPart[0] == 'Z')
					{
						charPart[0] = 'A';
						throw new IndexOutOfRangeException("No more order codes can be created");
					}
					else
					{
						charPart[0]++;
						return new string(charPart) + numPart.ToString("00000");
					}
				}

			}
			else
			{
				charPart[i]++;
				return new string(charPart) + numPart.ToString("00000");
			}
		}
	}
}
