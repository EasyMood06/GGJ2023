using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{
    public ItemList itemList;

    public List<GameObject> itemPrefabsLevel1;
    public List<string> itemNamesLevel1;
    public List<Sprite> itemImagesLevel1;

    public List<GameObject> itemPrefabsLevel2;
    public List<string> itemNamesLevel2;
    public List<Sprite> itemImagesLevel2;

    public List<GameObject> itemPrefabsLevel3;
    public List<string> itemNamesLevel3;
    public List<Sprite> itemImagesLevel3;

    private int itemIndex;

    private void Awake()
    {
        //游戏开始时从ItemList里复制一份list到自己这备用
        itemPrefabsLevel1 = new List<GameObject>(itemList.itemPrefabsLevel1);
        itemPrefabsLevel2 = new List<GameObject>(itemList.itemPrefabsLevel2);
        itemPrefabsLevel3 = new List<GameObject>(itemList.itemPrefabsLevel3);

        itemNamesLevel1 = new List<string>(itemList.itemNamesLevel1);
        itemNamesLevel2 = new List<string>(itemList.itemNamesLevel2);
        itemNamesLevel3 = new List<string>(itemList.itemNamesLevel3);

        itemImagesLevel1 = new List<Sprite>(itemList.itemImagesLevel1);
        itemImagesLevel2 = new List<Sprite>(itemList.itemImagesLevel2);
        itemImagesLevel3 = new List<Sprite>(itemList.itemImagesLevel3);
    }

    public void RandomSpawnItems(int itemLevel, int itemIndexInMenu, SmallSpaceship spaceship) 
        // itemLevel = 希望生成的物品稀有度，itemIndexInMenu = 物品在该船菜单的第几个，spaceship = 生成在哪个船
    {
        itemIndex = -1;
        if (itemLevel == 1)
        {
            itemIndex = Random.Range(0, itemPrefabsLevel1.Count);
            Debug.LogError("SpaceshipManager - itemIndex: " + itemIndex);

            spaceship.itemPrefabs[itemIndexInMenu] = itemPrefabsLevel1[itemIndex];
            itemPrefabsLevel1.RemoveAt(itemIndex);

            spaceship.itemNames[itemIndexInMenu] = itemNamesLevel1[itemIndex];
            itemNamesLevel1.RemoveAt(itemIndex);

            spaceship.itemImages[itemIndexInMenu] = itemImagesLevel1[itemIndex];
            itemImagesLevel1.RemoveAt(itemIndex);
        }
        else if (itemLevel == 2)
        {
            itemIndex = Random.Range(0, itemPrefabsLevel2.Count);
            Debug.LogError("SpaceshipManager - itemIndex: " + itemIndex);

            spaceship.itemPrefabs[itemIndexInMenu] = itemPrefabsLevel2[itemIndex];
            itemPrefabsLevel2.RemoveAt(itemIndex);

            spaceship.itemNames[itemIndexInMenu] = itemNamesLevel2[itemIndex];
            itemNamesLevel2.RemoveAt(itemIndex);

            spaceship.itemImages[itemIndexInMenu] = itemImagesLevel2[itemIndex];
            itemImagesLevel2.RemoveAt(itemIndex);

        }
        else if (itemLevel == 3)
        {
            itemIndex = Random.Range(0, itemPrefabsLevel3.Count);
            Debug.LogError("SpaceshipManager - itemIndex: " + itemIndex);

            spaceship.itemPrefabs[itemIndexInMenu] = itemPrefabsLevel3[itemIndex];
            itemPrefabsLevel3.RemoveAt(itemIndex);

            spaceship.itemNames[itemIndexInMenu] = itemNamesLevel3[itemIndex];
            itemNamesLevel3.RemoveAt(itemIndex);

            spaceship.itemImages[itemIndexInMenu] = itemImagesLevel3[itemIndex];
            itemImagesLevel3.RemoveAt(itemIndex);
        }

        else
            Debug.LogError("Item Level should be 1, 2 or 3.");

    }
}
