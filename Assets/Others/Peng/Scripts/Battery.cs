using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Item
{
    public float maxChargeChange = 1;

    public override void OnGet()
    {
        base.OnGet();
        playerController.GetComponent<PlayerCharge>().maxCharge += maxChargeChange;
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
