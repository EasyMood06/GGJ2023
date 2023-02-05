using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakRock : MonoBehaviour
{
    public float breakingVelocity = 8f;
    public bool enable = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock" && enable)
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= breakingVelocity)
            {
                collision.gameObject.transform.position = new Vector2(500, 500);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
