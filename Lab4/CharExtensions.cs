namespace Lab4
{
    public static class CharExtensions
    {
        public static bool IsTerminal(this char s)
        {
            return s switch
            {
                'a' => true,
                '+' => true,
                '-' => true,
                '*' => true,
                '/' => true,
                '(' => true,
                ')' => true,
                _ => false
            };
        }
    }
}