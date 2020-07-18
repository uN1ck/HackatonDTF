using System;
using System.Collections;
using System.Collections.Generic;
using core.cards;
using UnityEngine;

public delegate void OnMouseUpDelegate(OnTableCardController controller);

public class OnTableCardController : CardController
{


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        onMouseDelegate.Invoke(this);
    }
}
