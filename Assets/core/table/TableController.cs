using System.Collections.Generic;
using UnityEngine;

namespace core.table
{
    public class TableController : MonoBehaviour
    {
        private const int TABLE_SIZE = 7;

        public GameObject rowTemplate;

        //TODO: Init somehow!
        private List<GameObject> _players = new List<GameObject>();
        private readonly List<GameObject> _rows = new List<GameObject>();
        private RowController _selectedRow;
        private Player _currentPlayer;

        private void Start()
        {
            //TODO: Initialize players here

            for (int i = 0; i < TABLE_SIZE; i++)
            {
                //Positioning by relative center: (part of table) * (index) - centering + padding
                float currentX = (0.8f / TABLE_SIZE) * i - 0.45f + 0.1f;

                //Initializing row here
                GameObject newRow = Instantiate(rowTemplate, Vector3.zero, Quaternion.identity, transform);

                newRow.transform.localScale = new Vector3(0.1f, 0.8f, 1);
                newRow.transform.localPosition = new Vector3(currentX, 0, -1);
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
                row.BottomCard = _currentPlayer.getActiveCardTemplate();
            }
        }

        private void Update()
        {
        }
    }
}