using UnityEngine;

namespace core
{
    public interface Player
    {
        void setActiveCardTemplate(GameObject cardTemplate);

        GameObject getActiveCardTemplate();

    }
}