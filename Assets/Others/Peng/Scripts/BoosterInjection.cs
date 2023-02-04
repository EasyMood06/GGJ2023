using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterInjection : Item
{
    public int healthChange = 1;
    public override void OnGet()
    {
        base.OnGet();
        playerController.GetComponent<PlayerHealth>().ChangeHealth(healthChange, healthChange);
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
