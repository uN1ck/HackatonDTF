using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public sealed class CommonGear : MonoBehaviour
{
    private Action<Collision2D, CommonGear> _gearCollideHandler;
    public Double AngleSpeed { set; get; } = 1.0;

    //TODO: Move to factory
    public static GameObject Instantiate(Transform parent, Action<Collision2D, CommonGear> gearCollideHandler)
    {
        var prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/CommonGear.prefab", typeof(GameObject));
        var newGear = Instantiate(prefab, Vector3.zero, Quaternion.identity, parent) as GameObject;
        CommonGear gear = newGear.GetComponent<CommonGear>();
        gear._gearCollideHandler = gearCollideHandler;
        return newGear;
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach (ContactPoint2D contact in other.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        _gearCollideHandler.Invoke(other, this);
    }
}
