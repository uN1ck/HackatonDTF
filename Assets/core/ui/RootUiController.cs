using core.cards;
using core.scenes;
using UnityEngine;
using UnityEngine.UI;

namespace core.ui
{
    public class RootUiController : MonoBehaviour
    {
        private Button ExitButton;
        private Button RestartButton;
        private Button EndTurnButton;
        private CardPanelController CardButtonController;
        
        private IScenesManager IScenesManager;
        
        private IGameManager IGameManager;

        private void inject()
        {
            ExitButton = GameObject.FindGameObjectWithTag("ExitButton")?.GetComponent<Button>();
            RestartButton = GameObject.FindGameObjectWithTag("RestartButton")?.GetComponent<Button>();
            EndTurnButton = GameObject.FindGameObjectWithTag("EndTurnButton")?.GetComponent<Button>();
            CardButtonController = GameObject.FindGameObjectWithTag("CardButtonsRow")?.GetComponent<CardPanelController>();
        }
        

        private void Start()
        {
            inject();
            
            ExitButton.onClick.AddListener(handleExitButton);
            RestartButton.onClick.AddListener(handleRestartButton);
            EndTurnButton.onClick.AddListener(handleEndTurnButton);
            
            CardButtonController.OnCardSelect = handleCardSelect;
        }

        private void handleExitButton()
        {
            IScenesManager.loadScene("ExitScene");
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
            //TODO: Selected card instanciate
        }
    }
}