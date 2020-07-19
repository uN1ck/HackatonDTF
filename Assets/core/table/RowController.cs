using System;
using core.cards;
using UnityEngine;

namespace core.table
{
    public enum RowState
    {
        SETTING,
        CONFIRM,
        RUN
    }

    public delegate void OnMouseUpDelegate(RowController controller);

    public class RowController : MonoBehaviour
    {
        private Vector3 position;

        private GameObject _topCard;

        public GameObject TopCard
        {
            set
            {
                _topCard = value;
                _topCard.transform.localPosition = new Vector3(position.x, 3, position.y);
            }
            get => _topCard;
        }

        private GameObject _bottomCard;

        public GameObject BottomCard
        {
            set
            {
                _bottomCard = value;
                _bottomCard.transform.localPosition = new Vector3(position.x, 3, position.y);
            }
            get => _bottomCard;
        }

        public RowState RowState { set; get; }

        public OnMouseUpDelegate OnMouseUpDelegate { set; get; }


        private void Start()
        {
            position = transform.position;
        }

        private void Update()
        {
            switch (RowState)
            {
                case RowState.SETTING:
                    handleSetting();
                    break;
                case RowState.CONFIRM:
                    break;
                case RowState.RUN:
                    handleRun();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnMouseUpAsButton()
        {
            OnMouseUpDelegate.Invoke(this);
        }

        //
        // region Custom Handlers
        //

        private void handleRun()
        {
            if (TopCard == null) handleInvalidNextState("Карта оппонета не установлена");
            if (BottomCard == null) handleInvalidNextState("Карта игрока не установлена");

            //TODO: Animate Cards here!

            int result = BottomCard.GetComponent<CardController>().wins(TopCard.GetComponent<CardController>());
            if (result > 0)
            {
                //TODO: PlayerWins
                BottomCard.transform.localPosition += Vector3.up;
            }
            else if (result == 0)
            {
                //TODO: NobodyWins
            }
            else if (result < 0)
            {
                //TODO: OpponentWins
                TopCard.transform.localPosition += Vector3.down;
            }
        }

        private void handleSetting()
        {
            if (TopCard != null)
            {
                var position = transform.position;
                TopCard.transform.localPosition = new Vector3(position.x, 3, position.y);
            }

            if (BottomCard != null)
            {
                var position = transform.position;
                BottomCard.transform.localPosition = new Vector3(position.x, 3, position.y);
            }
        }

        private void handleInvalidNextState(String message)
        {
        }

        //
        // endregion
        //
    }
}