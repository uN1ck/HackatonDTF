using UnityEngine;

namespace core.cards
{
    public class OnTableCardFactory : MonoBehaviour, ICardTemplateFactory
    {
        public GameObject CardTemplate;
        private GameObject CardsRoot;

        private void Start()
        {
            CardsRoot = GameObject.Find("Table");
        }

        public GameObject createTableCardFor(CardType cardType)
        {
            GameObject newOnTableCard =
                Instantiate(CardTemplate, Vector3.zero, Quaternion.identity, CardsRoot.transform);
            OnTableCardController newOnTableCardController = newOnTableCard.GetComponent<OnTableCardController>();
            newOnTableCardController.CardType = cardType;
            newOnTableCardController.stickToMouse();
            //TODO: load image? change material?


            return newOnTableCard;
        }
    }
}