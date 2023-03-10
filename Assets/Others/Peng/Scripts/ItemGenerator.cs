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
                pc.GetComponent<ExtraRope>().OnGet();
                break;
            case "EnhancedHammer":
                pc.gameObject.AddComponent<EnhancedHammer>();
                pc.GetComponent<EnhancedHammer>().OnGet();
                break;
            case "EnhancedWinch":
                pc.gameObject.AddComponent<EnhancedWinch>();
                pc.GetComponent<EnhancedWinch>().OnGet();
                break;
            case "BoosterInjection":
                pc.gameObject.AddComponent<BoosterInjection>();
                pc.GetComponent<BoosterInjection>().OnGet();
                break;
            case "Battery":
                pc.gameObject.AddComponent<Battery>();
                pc.GetComponent<Battery>().OnGet();
                break;
            case "SolarPanel":
                pc.gameObject.AddComponent<SolarPanel>();
                pc.GetComponent<SolarPanel>().OnGet();
                break;
            case "DrillShoes":
                GameObject.Find("Player").GetComponent<BreakRock>().enable = true;
                break;
            case "StarMap":
                GameObject.Find("Main Camera").transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "RotatingFun":
                GameObject.Find("Main Camera").transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "LightlyLight":
                pc.GetComponent<LightlyLight>().OnGet();
                break;
            case "HeavilyHeavy":
                pc.GetComponent<HeavilyHeavy>().OnGet();
                break;
        }
    }
}
