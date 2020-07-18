using System;
using System.Collections.Generic;
using System.Linq;
using core.cards;
using UnityEngine;

namespace core.ui
{
    public delegate void OnCardSelect(CardType cardType);

    public class CardPanelController : MonoBehaviour
    {
        public OnCardSelect OnCardSelect;
        public GameObject CardButtonTemplate;
        private List<GameObject> _cardButtonList;

        private void Start()
        {
            _cardButtonList = generateCardButtons();
        }
        
        
        private List<GameObject> generateCardButtons()
        {
            List<GameObject> buttons = new List<GameObject>();
            List<CardType> cardTypes = Enum.GetValues(typeof(CardType)).Cast<CardType>().ToList();

            int step = 100;
            int x = cardTypes.Count / 2 * -step;

            foreach (CardType cardType in cardTypes)
            {
                GameObject newButton = Instantiate(
                    CardButtonTemplate, 
                    new Vector3(0, 0, transform.position.z), 
                    Quaternion.identity,
                    transform);
                CardController cardController = newButton.GetComponent<CardController>();
                cardController.CardType = cardType;
                cardController.onMouseDelegate = OnCardSelect;
                x += step;

                buttons.Add(newButton);
            }

            return buttons;
        }

    }
}