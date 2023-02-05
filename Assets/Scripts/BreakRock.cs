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
                Debug.Log("Breaking!");
                collision.gameObject.transform.position = new Vector3(500, 500, 0);
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
