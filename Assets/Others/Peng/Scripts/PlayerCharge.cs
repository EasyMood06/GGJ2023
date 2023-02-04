using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharge:MonoBehaviour
{
    public float maxCharge = 1;
    public float currentCharge = 1;
    public float chargeRecoverSpeed = 0.5f;
    public bool isFull;

    private void Update()
    {
        if (!isFull)
        {
            Recover();
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
}
