using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallSpaceship : MonoBehaviour
{
    public GameObject[] itemPrefabs; //不用填 会自动生成
    public string[] itemNames;  //不用填 会自动生成
    public string[] itemInfo;  //不用填 会自动生成
    public Sprite[] itemImages; //不用填 会自动生成
    public int item1Level; //1号物品稀有度
    public int item2Level; //2号物品稀有度
    public int item3Level; //3号物品稀有度
    //public float throwForce = 2;

    public SpaceshipManager spaceshipManager;
    public UIManager uiManager;
    public float isInSpaceshipCD = 2f;

    private bool isInSpaceship;
    private float initIsInSpaceshipCD = 2f;
    private Rigidbody2D playerRB;
    private void Start()
    {
        isInSpaceship = false;
        isInSpaceshipCD = 2f;
        initIsInSpaceshipCD = isInSpaceshipCD;
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
        uiManager = FindObjectOfType<UIManager>();

        if(spaceshipManager) //随机抽取物品到该飞船上
        {
            spaceshipManager.RandomSpawnItems(item1Level, 0, this);
            spaceshipManager.RandomSpawnItems(item2Level, 1, this);
            spaceshipManager.RandomSpawnItems(item3Level, 2, this);
            Debug.LogError("Complete spaceship item random spawn");
            
        }
    }

    private void Update()
    {
        if (isInSpaceship)
        {
            isInSpaceshipCD -= Time.deltaTime;
            if (isInSpaceshipCD <= 0)
            {
                isInSpaceshipCD = initIsInSpaceshipCD;
                isInSpaceship = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isInSpaceship) return; //每次进入只触发一次菜单
        if (collision.collider.gameObject.GetComponent<PlayerController>()) //player来到这个小太空舱
        {
            GameObject.Find("Player").GetComponent<PlayerController>().isInSpaceship = true;
            isInSpaceship = true;
            playerRB = collision.collider.gameObject.GetComponent<Rigidbody2D>();
            collision.collider.gameObject.GetComponent<SpringJoint2D>().connectedBody = playerRB;
            // UI binding
            uiManager.UpdateItemUI(this);
            Debug.LogError("Enter spaceship");
            Time.timeScale = 0;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    public void ThrowPlayerAway()
    {
        if(playerRB)
        {
            //playerRB.AddForce((this.transform.position - playerRB.gameObject.transform.position) * throwForce, ForceMode2D.Impulse);
            playerRB = null;
        }
       
    }


}
