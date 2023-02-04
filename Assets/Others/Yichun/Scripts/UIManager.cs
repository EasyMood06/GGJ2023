using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas canvas;
    public GameObject ItemUI;
    public GameObject itemName1;
    public GameObject itemImage1;
    public GameObject itemBtn1;

    public GameObject itemName2;
    public GameObject itemImage2;
    public GameObject itemBtn2;

    public GameObject itemName3;
    public GameObject itemImage3;
    public GameObject itemBtn3;

    private GameObject itemPrefab1;
    private GameObject itemPrefab2;
    private GameObject itemPrefab3;

    private SmallSpaceship smalls;
    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
    }

   public void UpdateItemUI(SmallSpaceship smallSpaceship)
    {

        itemName1.GetComponent<Text>().text = smallSpaceship.itemNames[0];
        itemName2.GetComponent<Text>().text = smallSpaceship.itemNames[1];
        itemName3.GetComponent<Text>().text = smallSpaceship.itemNames[2];

        itemImage1.GetComponent<Image>().sprite = smallSpaceship.itemImages[0];
        itemImage2.GetComponent<Image>().sprite = smallSpaceship.itemImages[1];
        itemImage3.GetComponent<Image>().sprite = smallSpaceship.itemImages[2];
        

        ItemUI.SetActive(true);

        smalls = smallSpaceship;
        Debug.LogError("Update Item UI");

    }

    public void LeaveSmallSpaceship()
    {
        ItemUI.SetActive(false);
        Time.timeScale = 1;
        smalls.ThrowPlayerAway();
        smalls = null;
    }

    public void ChooseItem(int itemIndex)
    {
        
    }
}
