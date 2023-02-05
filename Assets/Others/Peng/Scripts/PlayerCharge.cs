using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharge:MonoBehaviour
{
    public float maxCharge = 1;
    public float currentCharge = 1;
    public float chargeRecoverSpeed = 0.5f;
    public bool isFull;
    public RectTransform chargeTransform;
    public RectTransform chargeBgTransform;

    private void Update()
    {
        if (!isFull)
        {
            Recover();
            UpdateUI();
        }
    }

    public void Recover()
    {
        currentCharge += chargeRecoverSpeed * Time.deltaTime;
        if (currentCharge > maxCharge)
        {
            currentCharge = maxCharge;
            isFull = true;
        }
        else
        {
            isFull = false;
        }
    }
    public void RestoreAllCharge()
    {
        currentCharge = maxCharge;
    }

    public void CostCharge(float f)
    {
        if (f <= currentCharge)
        {
            currentCharge -= f;
            isFull = false;
        }
    }

    public void UpdateUI()
    {
        chargeTransform.sizeDelta = new Vector2(currentCharge * 30, 20);
        chargeBgTransform.sizeDelta = new Vector2(maxCharge * 30, 20);
    }
}
