using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate(PlayerController pc, string itemName)
    {
        switch (itemName){
            case "ExtraRope":
                pc.gameObject.AddComponent<ExtraRope>();
                break;
            case "EnhancedHammer":
                pc.gameObject.AddComponent<EnhancedHammer>();
                break;
            case "EnhancedWinch":
                pc.gameObject.AddComponent<EnhancedWinch>();
                break;
            case "BoosterInjection":
                pc.gameObject.AddComponent<BoosterInjection>();
                break;
            case "Battery":
                pc.gameObject.AddComponent<Battery>();
                break;
            case "SolarPanel":
                pc.gameObject.AddComponent<SolarPanel>();
                break;
        }
    }
}
