using System;
using System.Collections.Generic;
using System.Linq;
using core.cards;
using core.table;
using UnityEngine;

namespace core.ui
{
    public class CardPanelController : MonoBehaviour
    {
        public GameObject cardTemplate;

        private void Start()
        {
            
        }

        private GameObject getCardMaterialByType(CardType cardType)
        {
            return cardTemplate;
        }
    }
}