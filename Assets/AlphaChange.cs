using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaChange : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = 0.1f;
        alpha = (1 - Player.transform.position.magnitude / 150) * alpha;
        Debug.Log(alpha);
        if (alpha < 0) alpha = 0;
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, alpha);
    }
}
