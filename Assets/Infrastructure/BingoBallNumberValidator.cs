namespace BrilliantBingo.Code.Infrastructure
{
    public static class BingoBallNumberValidator
    {
        public static bool IsBingoBallNumberValid(int number)
        {
            return number > 0 && number <= 75;
        }
    }
}