namespace core.ui.game
{
    public interface InGameUiController
    {
        void HandleRestart();

        void HandleExit();

        void HandleEndTurn();

        void HandleCardClick();
    }
}