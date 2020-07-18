using System;
using System.Collections;
using System.Collections.Generic;
using core.cards;
using UnityEngine;



public class OnTableCardController : CardController
{
    
    void Start()
    {
        // Color
        // GetComponent<MeshRenderer>().material.color = this.CardType;
    }
    
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        onMouseDelegate.Invoke(this);
    }
}
