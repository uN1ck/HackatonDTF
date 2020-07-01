using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GearsController : MonoBehaviour
{
    private List<CommonGear> _gears = new List<CommonGear>();
    // Start is called before the first frame update
    void Start()
    {
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/CommonGear.prefab", typeof(GameObject));
        
        for (int i = 0; i < 3; i++)
        {
            var newGear = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
            if (newGear != null)
            {
                newGear.transform.position += Vector3.one * i;
                CommonGear gear = newGear.GetComponent<CommonGear>();
                _gears.Add(gear);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
