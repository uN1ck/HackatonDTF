using UnityEngine;

namespace core
{
    public interface IPlayer
    {
        void setActiveCardTemplate(GameObject cardTemplate);

        GameObject getActiveCardTemplate();

    }
}