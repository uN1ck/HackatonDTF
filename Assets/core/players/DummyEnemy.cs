using System;
using System.Collections.Generic;
using core.cards;
using core.table;
using UnityEngine;
using Random = UnityEngine.Random;

namespace core
{
    public class DummyEnemy : MonoBehaviour, IPlayer
    {
        public List<RowController> rows { set; get; }
        private GameObject selectedCardTemplate;

        private GameObject generateCard()
        {
            GameObject newCard = Instantiate(
                selectedCardTemplate,
                Vector3.zero,
                Quaternion.identity
            );
            newCard.GetComponent<CardController>().CardType = (CardType) Math.Floor(Random.value * 5);
            return newCard;
        }

        public void setActiveCardTemplate(GameObject cardTemplate)
        {
            ///TODO: Implement!
            selectedCardTemplate = cardTemplate;
        }

        public GameObject getActiveCardTemplate()
        {
            ///TODO: Implement!
            return selectedCardTemplate;
        }
    }
}