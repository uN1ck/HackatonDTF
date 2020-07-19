using core.cards;
using core.scenes;
using core.utils;
using UnityEngine;
using UnityEngine.UI;

namespace core.ui
{
    //Граница между UI и самой игрой
    public class RootUiController : InjectableMonoBehaviour
    {
        [UnityInject("ExitButton")]
        private Button ExitButton;
        [UnityInject("RestartButton")]
        private Button RestartButton;
        [UnityInject("EndTurnButton")]
        private Button EndTurnButton;
        [UnityInject("CardButtonController")]
        private CardPanelController CardButtonController;

        private IScenesManager IScenesManager;

        private IGameManager IGameManager;
        

        public override void PostStart()
        {
            ExitButton.onClick.AddListener(handleExitButton);
            RestartButton.onClick.AddListener(handleRestartButton);
            EndTurnButton.onClick.AddListener(handleEndTurnButton);

            CardButtonController.OnCardSelect = handleCardSelect;
        }

        private void handleExitButton()
        {
            IScenesManager.loadScene("MainMenuScene");
        }

        private void handleRestartButton()
        {
            IGameManager.restartGame();
        }

        private void handleEndTurnButton()
        {
            IGameManager.endTurn();
        }

        private void handleCardSelect(CardType cardType)
        {
            IGameManager.getCurrentPlayer().ActiveCardType = cardType;
        }
    }
}