using UnityEngine;

namespace core.cards
{
    public delegate void OnMouseUpDelegate(OnTableCardController controller);

    public abstract class CardController : MonoBehaviour
    {
        public CardType CardType { set; get; }
        public OnMouseUpDelegate onMouseDelegate;

        private static readonly int[,] PlayingTable = new int[5, 5]
        {
            {0, -1, 1, 1, -1},
            {1, 0, -1, -1, 1},
            {-1, 1, 0, 1, -1},
            {-1, 1, -1, 0, 1},
            {1, -1, 1, -1, 0}
        };

        public int wins(CardController opponent)
        {
            return PlayingTable[(int) CardType, (int) opponent.CardType];
        }
    }
}