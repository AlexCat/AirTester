namespace Tion.MagicAirTester.Contracts
{
    public interface IBreezerState
    {
        int Speed { get; set; }
        bool IsConnected { get; set; }
        void ClearState();
    }
}