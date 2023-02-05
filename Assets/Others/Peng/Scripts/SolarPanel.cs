using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : Item
{
    public float maxChargeChange = 1;
    public float RecoverSpeedChange = 0.1f;

    public override void OnGet()
    {
        base.OnGet();
        playerController.GetComponent<PlayerCharge>().maxCharge += maxChargeChange;
        playerController.GetComponent<PlayerCharge>().chargeRecoverSpeed += RecoverSpeedChange;
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
