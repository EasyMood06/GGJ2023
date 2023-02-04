using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShowing : MonoBehaviour
{
    public bool enable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1);
        }
        else
        {
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0);
        }
    }
}
