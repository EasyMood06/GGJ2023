using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Item
{
    public float maxChargeChange = 0.5f;

    public override void OnGet()
    {
        base.OnGet();
        playerController.GetComponent<PlayerCharge>().maxCharge += maxChargeChange;
        playerController.GetComponent<PlayerCharge>().isFull = false;
        playerController.GetComponent<PlayerCharge>().UpdateUI();
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
