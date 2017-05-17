namespace Tion.MagicAirTester.Contracts
{
    public class MagicAirBS310State : IMagicAirState
    {
        public bool isFound { get; set; }
        public void ClearState()
        {
            isFound = false;
        }
    }
}