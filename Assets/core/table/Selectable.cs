using UnityEngine;

namespace core.table
{
    public class Selectable : MonoBehaviour
    {
        public Color mouseOverColor;
        public Color mouseDownColor;
        public Color selectedColor;
        public Color originalColor;

        private MeshRenderer m_Renderer;

        private void Start()
        {
            m_Renderer = GetComponent<MeshRenderer>();
        }

        private void OnMouseUp()
        {
            m_Renderer.material.color = selectedColor;
        }

        private void OnMouseDown()
        {
            m_Renderer.material.color = mouseDownColor;
        }

        private void OnMouseOver()
        {
            m_Renderer.material.color = mouseOverColor;
        }

        private void OnMouseExit()
        {
            m_Renderer.material.color = originalColor;
        }
    }
}