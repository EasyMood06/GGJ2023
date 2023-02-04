using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakRock : MonoBehaviour
{
    public float breakingVelocity = 8f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= breakingVelocity)
            {
                Debug.Log("Breaking!");
                collision.gameObject.SetActive(false);
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
