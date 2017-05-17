namespace Tion.MagicAirTester.Contracts
{
    public interface IMagicAirState
    {
        bool isFound { get; set; }
        void ClearState();
    }
}