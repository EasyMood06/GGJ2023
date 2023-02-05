using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRockDanger : SpaceRock
{

    public override void InitializeSprite()
    {
        spriteArray = Resources.LoadAll<Sprite>("SpaceTrash");
        spriteRenderer = GetComponent<SpriteRenderer>();
        int rand_index = (int)Random.Range(0,2);
        spriteRenderer.sprite = spriteArray[rand_index];
        spriteRenderer.color = new Color(1, 0.8f, 0.8f, 1);
    }
}
