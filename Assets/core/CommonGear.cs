using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public sealed class CommonGear : MonoBehaviour
{
    private Transform _transform;
    private GearsController _gearsController;
    private Action<Collision> _gearCollideHandler;

    public static GameObject Instantiate(Transform parent, Action<Collision> gearCollideHandler)
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
        _transform = gameObject.transform;
        _gearsController = _transform.GetComponentInParent<GearsController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        _gearCollideHandler.Invoke(other);
    }
}
