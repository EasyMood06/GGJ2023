using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "List/ItemList")]
public class ItemList : ScriptableObject
{
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
}
