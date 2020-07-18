using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GearsController : MonoBehaviour
{
    private List<CommonGear> _gears = new List<CommonGear>();
    private List<Pair<CommonGear, CommonGear>> chains = new List<Pair<CommonGear, CommonGear>>();

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            var gear = CommonGear.Instantiate(transform, handleCollide);
            gear.transform.position = Vector3.one * (0.5f * i);
            _gears.Add(gear.GetComponent<CommonGear>());
        }
    }


    void handleCollide(Collision2D collision, CommonGear source)
    {
        Debug.Log("Collision done!");
    }


    // Update is called once per frame
    void Update()
    {
    }
}

internal class Pair<L, R>
{
    public L left { set; get; }

    public R right { set; get; }
}