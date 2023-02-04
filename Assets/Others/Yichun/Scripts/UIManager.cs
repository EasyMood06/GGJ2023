using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas canvas;
    public PlayerController player;
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
        player = FindObjectOfType<PlayerController>();
    }

   public void UpdateItemUI(SmallSpaceship smallSpaceship)
    {

        itemName1.GetComponent<Text>().text = smallSpaceship.itemNames[0];
        itemName2.GetComponent<Text>().text = smallSpaceship.itemNames[1];
        itemName3.GetComponent<Text>().text = smallSpaceship.itemNames[2];

        itemImage1.GetComponent<Image>().sprite = smallSpaceship.itemImages[0];
        itemImage2.GetComponent<Image>().sprite = smallSpaceship.itemImages[1];
        itemImage3.GetComponent<Image>().sprite = smallSpaceship.itemImages[2];

        itemPrefab1 = smallSpaceship.itemPrefabs[0];
        itemPrefab2 = smallSpaceship.itemPrefabs[1];
        itemPrefab3 = smallSpaceship.itemPrefabs[2];

        ItemUI.SetActive(true);

        smalls = smallSpaceship;
        Debug.LogError("Update Item UI");

    }

    public void ResetItemUI()
    {
        itemName1.GetComponent<Text>().text = null;
        itemName2.GetComponent<Text>().text = null;
        itemName3.GetComponent<Text>().text = null;

        itemImage1.GetComponent<Image>().sprite = null;
        itemImage2.GetComponent<Image>().sprite = null;
        itemImage3.GetComponent<Image>().sprite = null;

        itemPrefab1 = null;
        itemPrefab2 = null;
        itemPrefab3 = null;

        smalls = null;
    }

    public void LeaveSmallSpaceship()
    {
        ItemUI.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<PlayerController>().isInSpaceship = false;
        player.GetComponent<PlayerController>().launchable = true;
        smalls.ThrowPlayerAway();
        ResetItemUI();
    }

    public void ChooseItem(int itemIndex) //在菜单选取某个item后item所带的功能生效，且关闭Item选择界面，且不能再次进入
    {
        if(itemIndex == 1)
        {
           //itemPrefab1.GetComponent<Item>().OnGet();
        }
        else if (itemIndex == 2)
        {
            //itemPrefab2.GetComponent<Item>().OnGet();
        }
        else if (itemIndex == 3)
        {
            //itemPrefab3.GetComponent<Item>().OnGet();
        }

        LeaveSmallSpaceship();

    }
}