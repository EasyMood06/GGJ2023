using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{
    public ItemList itemList;

    public List<GameObject> itemPrefabsLevel1;
    public List<string> itemNamesLevel1;
    public List<string> itemInfoLevel1;
    public List<Sprite> itemImagesLevel1;

    public List<GameObject> itemPrefabsLevel2;
    public List<string> itemNamesLevel2;
    public List<string> itemInfoLevel2;
    public List<Sprite> itemImagesLevel2;

    public List<GameObject> itemPrefabsLevel3;
    public List<string> itemNamesLevel3;
    public List<string> itemInfoLevel3;
    public List<Sprite> itemImagesLevel3;

    private int itemIndex1;
    private int itemIndex2;
    private int itemIndex3;

    private int[] itemIndexRecord; //用于记录取到的item分别是原list的第几个元素
    private int[] itemLevelRecord; //用于记录取到的item分别在哪一个list

    private void Awake()
    {
        itemIndexRecord = new int[3];
        itemLevelRecord = new int[3];

        //游戏开始时从ItemList里复制一份list到自己这备用
        itemPrefabsLevel1 = new List<GameObject>(itemList.itemPrefabsLevel1);
        itemPrefabsLevel2 = new List<GameObject>(itemList.itemPrefabsLevel2);
        itemPrefabsLevel3 = new List<GameObject>(itemList.itemPrefabsLevel3);

        itemNamesLevel1 = new List<string>(itemList.itemNamesLevel1);
        itemNamesLevel2 = new List<string>(itemList.itemNamesLevel2);
        itemNamesLevel3 = new List<string>(itemList.itemNamesLevel3);

        itemInfoLevel1 = new List<string>(itemList.itemInfoLevel1);
        itemInfoLevel2 = new List<string>(itemList.itemInfoLevel2);
        itemInfoLevel3 = new List<string>(itemList.itemInfoLevel3);

        itemImagesLevel1 = new List<Sprite>(itemList.itemImagesLevel1);
        itemImagesLevel2 = new List<Sprite>(itemList.itemImagesLevel2);
        itemImagesLevel3 = new List<Sprite>(itemList.itemImagesLevel3);
    }

    public void RandomSpawnItems(int itemLevel, int itemIndexInMenu, SmallSpaceship spaceship) 
        // itemLevel = 希望生成的物品稀有度，itemIndexInMenu = 物品在该船菜单的第几个，spaceship = 生成在哪个船
    {
        itemIndex1 = -1;
        itemIndex2 = -1;
        itemIndex3 = -1;

        if (itemLevel == 1)
        {
            itemIndex1 = Random.Range(0, itemPrefabsLevel1.Count);
            Debug.LogError("SpaceshipManager - itemIndex: " + itemIndex1);

            spaceship.itemPrefabs[itemIndexInMenu] = itemPrefabsLevel1[itemIndex1];
            itemPrefabsLevel1.RemoveAt(itemIndex1);

            spaceship.itemNames[itemIndexInMenu] = itemNamesLevel1[itemIndex1];
            itemNamesLevel1.RemoveAt(itemIndex1);

            spaceship.itemInfo[itemIndexInMenu] = itemInfoLevel1[itemIndex1];
            itemInfoLevel1.RemoveAt(itemIndex1);

            spaceship.itemImages[itemIndexInMenu] = itemImagesLevel1[itemIndex1];
            itemImagesLevel1.RemoveAt(itemIndex1);
        }
        else if (itemLevel == 2)
        {
            itemIndex2 = Random.Range(0, itemPrefabsLevel2.Count);
            Debug.LogError("SpaceshipManager - itemIndex: " + itemIndex2);

            spaceship.itemPrefabs[itemIndexInMenu] = itemPrefabsLevel2[itemIndex2];
            itemPrefabsLevel2.RemoveAt(itemIndex2);

            spaceship.itemNames[itemIndexInMenu] = itemNamesLevel2[itemIndex2];
            itemNamesLevel2.RemoveAt(itemIndex2);

            spaceship.itemInfo[itemIndexInMenu] = itemInfoLevel2[itemIndex2];
            itemInfoLevel2.RemoveAt(itemIndex2);

            spaceship.itemImages[itemIndexInMenu] = itemImagesLevel2[itemIndex2];
            itemImagesLevel2.RemoveAt(itemIndex2);

        }
        else if (itemLevel == 3)
        {
            itemIndex3 = Random.Range(0, itemPrefabsLevel3.Count);
            Debug.LogError("SpaceshipManager - itemIndex: " + itemIndex3);

            spaceship.itemPrefabs[itemIndexInMenu] = itemPrefabsLevel3[itemIndex3];
            itemPrefabsLevel3.RemoveAt(itemIndex3);

            spaceship.itemNames[itemIndexInMenu] = itemNamesLevel3[itemIndex3];
            itemNamesLevel3.RemoveAt(itemIndex3);

            spaceship.itemInfo[itemIndexInMenu] = itemInfoLevel3[itemIndex3];
            itemInfoLevel3.RemoveAt(itemIndex3);

            spaceship.itemImages[itemIndexInMenu] = itemImagesLevel3[itemIndex3];
            itemImagesLevel3.RemoveAt(itemIndex3);
        }

        else
            Debug.LogError("Item Level should be 1, 2 or 3.");

    }

    public void ChooseItem(int itemIndexInMenu, SmallSpaceship smallSpaceship)
    {
        //if(itemIndexInMenu == 1)
        

    }
}
