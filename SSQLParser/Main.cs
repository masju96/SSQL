using System;

//compile with: /unsafe 

namespace SSQLParser
{
    public class Spm
    {
        unsafe static void Main(string[] args)
		{
            int zero = 0;
            int* i = &zero;
            incr(&i);
            System.Console.Write(i);
		}

        unsafe static private void incr(int* i)
        {
            i++;
        }
    }
}
