using WiW.src.IViews;

namespace WiW.src.Views
{
    public interface BoardView : FormView
    {
        public int SelectedQuery { get; }

        public event EventHandler Yes;
        public event EventHandler No;
        public event EventHandler Paths;
        public event EventHandler Levels;
        public event EventHandler Leafs;
        public event EventHandler Guess;
        public event EventHandler Ask;

        public void UserTurn(string pcQuery);
        public void PcTurn();
        public void PcReply(bool reply);
    }
}
