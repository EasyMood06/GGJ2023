using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    public GameObject Final;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dis = Final.transform.position - transform.position;
        if (dis.x < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Vector2.Angle(new Vector2(0, 1), Final.transform.position - transform.position)), 0.05f);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -Vector2.Angle(new Vector2(0, 1), Final.transform.position - transform.position)), 0.05f);
        }
    }
}
