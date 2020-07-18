using core.cards;

public class OnTableCardController : CardController
{
    
    void Start()
    {

    }
    
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        onMouseDelegate.Invoke(this.CardType);
    }
}
