using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFun : Item
{
    public override void OnGet()
    {
        base.OnGet();
        GameObject.Find("Emoji").GetComponent<EmojiShowing>().enable = true;
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
