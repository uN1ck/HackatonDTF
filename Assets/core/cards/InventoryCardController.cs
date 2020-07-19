using UnityEngine;
using UnityEngine.UI;

namespace core.cards
{
    public class InventoryCardController : CardController
    {
        public CardType cardType;
        private ICardTemplateFactory CardFactory;
        
        private void Start()
        {
            CardFactory = GetComponent<OnTableCardFactory>();
            GetComponent<Button>().onClick.AddListener(onClick);
        }

        private void onClick()
        {
            GameObject newCard = CardFactory.createTableCardFor(cardType);
        }
    }
}