using System;
using System.Runtime.InteropServices;
using Boo.Lang;
using UnityEngine;

namespace core.table
{
    public class TableController : MonoBehaviour
    {
        //TODO: Init somehow!
        private List<GameObject> _players = new List<GameObject>();

        private readonly List<GameObject> _rows = new List<GameObject>();

        private const int TABLE_SIZE = 7;
        public GameObject rowTemplate;

        private void Start()
        {
            //TODO: Initialize players here
            
            for (int i = 0; i < TABLE_SIZE; i++)
            {
                GameObject newRow = Instantiate(rowTemplate, new Vector3(i, -1, 0), Quaternion.identity);
                //Initializing row here?
                newRow.GetComponent<RowController>().RowState = RowState.SETTING;
                _rows.Add(newRow);
            }
        }

        private void Update()
        {
            throw new NotImplementedException();
        }
    }
}