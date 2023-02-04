using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightlyLight : Item
{
    public override void OnGet()
    {
        base.OnGet();
        playerController.GetComponent<Rigidbody2D>().mass = playerController.GetComponent<Rigidbody2D>().mass / 2;
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
