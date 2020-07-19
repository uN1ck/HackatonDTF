using core.cards;
using UnityEngine;

namespace core
{
    public interface IPlayer
    {
        CardType ActiveCardType { set; get; }
    }
}