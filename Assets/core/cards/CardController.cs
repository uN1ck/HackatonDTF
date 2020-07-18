using UnityEngine;

namespace core.cards
{
    public class CardController : MonoBehaviour
    {
        public CardType CardType;
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
            return PlayingTable[(int)this.CardType, (int)opponent.CardType];
        }
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}