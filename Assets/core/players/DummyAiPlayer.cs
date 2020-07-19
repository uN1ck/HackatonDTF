using System;
using core.cards;
using UnityEngine;
using Random = UnityEngine.Random;

namespace core
{
    public class DummyAiPlayer : MonoBehaviour, IPlayer
    {
        private GameObject generateCard()
        {
            //TODO: To constant!
            GameObject basicCard = Resources.Load("Stuff/Prefabs/BasicCard") as GameObject;

            GameObject newCard = Instantiate(
                basicCard,
                Vector3.zero,
                Quaternion.identity
            );
            newCard.GetComponent<CardController>().CardType = ActiveCardType;
            return newCard;
        }

        public CardType ActiveCardType
        {
            get => (CardType) Math.Floor(Random.value * 5);
            set { }
        }
    }
}