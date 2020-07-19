using System.Collections.Generic;
using UnityEngine;

namespace core.table
{
    public class TableController : MonoBehaviour
    {
        private const int TABLE_SIZE = 7;

        public GameObject rowTemplate;
        public GameObject playerTemplate;

        //TODO: Init somehow!
        private List<GameObject> _players = new List<GameObject>();
        private readonly List<GameObject> _rows = new List<GameObject>();
        private RowController _selectedRow;
        private IPlayer _currentPlayer;

        private void Start()
        {
            initializeRows();
        }
        
        // private void initializePlayers()
        // {
        //     GameObject player1 = Instantiate(playerTemplate, Vector3.zero, Quaternion.identity, transform);
        //     player1.AddComponent<RealPlayer>();
        //     _players.Add(player1);
        //     
        //     GameObject player2 = Instantiate(playerTemplate, Vector3.zero, Quaternion.identity, transform);
        //     player2.AddComponent<DummyAiPlayer>();
        //     _players.Add(player2);
        // }

        private void initializeRows()
        {
            for (int i = 0; i < TABLE_SIZE; i++)
            {
                //Positioning by relative center: (part of table) * (index) - centering + padding
                float currentX = (0.8f / TABLE_SIZE) * i - 0.5f + 0.1f + (0.8f / TABLE_SIZE / 2) ;

                //Initializing row here
                GameObject newRow = Instantiate(rowTemplate, Vector3.zero, Quaternion.identity, transform);

                newRow.transform.localScale = new Vector3(0.1f, 0.6f, 1);
                newRow.transform.localPosition = new Vector3(currentX, 0.05f, -1);
                newRow.GetComponent<RowController>().RowState = RowState.SETTING;
                newRow.GetComponent<RowController>().OnMouseUpDelegate = onClickRow;

                _rows.Add(newRow);
            }
        }

        private void onClickRow(RowController row)
        {
            _selectedRow = row;
            if (_currentPlayer != null)
            {
                //TODO: 
                // row.BottomCard = _currentPlayer.ActiveCardType();
            }
        }
    }
}