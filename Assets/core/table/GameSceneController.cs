using core.cards;

namespace core.table
{
    public interface GameSceneController
    {
        void SpawnNewCard(CardType cardType);

        void SelectRow(RowController selectedRow);
    }
}