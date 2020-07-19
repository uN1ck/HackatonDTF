using System;
using core.cards;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class OnTableCardController : CardController
{
    private Boolean isStickedToMouse = false;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (isStickedToMouse)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = _camera.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    private Vector3 screenPoint;
    private Vector3 offset;

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = _camera.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseDown()
    {
        var position = gameObject.transform.position;
        screenPoint = _camera.WorldToScreenPoint(position);

        offset = position -
                 _camera.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseUp()
    {
        freeFromMouse();
    }

    public void stickToMouse()
    {
        isStickedToMouse = true;
    }

    public void freeFromMouse()
    {
        isStickedToMouse = false;
    }
}