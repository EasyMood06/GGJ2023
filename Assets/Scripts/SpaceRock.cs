using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRock : MonoBehaviour
{
    Vector2 force = new Vector2(0,1000);
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
