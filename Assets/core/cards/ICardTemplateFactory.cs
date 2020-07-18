using UnityEngine;

namespace core.cards
{
    public interface ICardTemplateFactory
    {
        GameObject createTableCardFor(CardType cardType);
    }
}