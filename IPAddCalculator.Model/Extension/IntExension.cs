namespace IPAddCalculator.Model.Extension
{
    public static class IntExension
    {
        public static int GetOneCountsForBinary(this int num)
        {
            int count = 0;
            while (num!=0)
            {
                count++;
                num &= num - 1;
            }

            return count;
        }
        
    }
}