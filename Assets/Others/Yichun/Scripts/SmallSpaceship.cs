using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallSpaceship : MonoBehaviour
{
    public GameObject[] itemPrefabs; //������ ���Զ�����
    public string[] itemNames;  //������ ���Զ�����
    public string[] itemInfo;  //������ ���Զ�����
    public Sprite[] itemImages; //������ ���Զ�����
    public int item1Level; //1����Ʒϡ�ж�
    public int item2Level; //2����Ʒϡ�ж�
    public int item3Level; //3����Ʒϡ�ж�
    //public float throwForce = 2;

    public SpaceshipManager spaceshipManager;
    public UIManager uiManager;
    public float isInSpaceshipCD = 2f;
    public bool choosed; //��¼����Ƿ�������ռ�վѡ��������

    private bool isInSpaceship;
    private float initIsInSpaceshipCD = 2f;
    bool isFinded;
    SpaceLines spaceLines;
    private Rigidbody2D playerRB;
    [SerializeField] bool isTheLastSpaceShip;
    CameraFollowing cameraFollowing;
    Sprite openedSprite;
    private void Start()
    {
        isInSpaceship = false;
        isInSpaceshipCD = 2f;
        initIsInSpaceshipCD = isInSpaceshipCD;
        isFinded = false;
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
        uiManager = FindObjectOfType<UIManager>();
        spaceLines = FindObjectOfType<SpaceLines>();
        cameraFollowing = FindObjectOfType<CameraFollowing>();
        openedSprite = Resources.Load<Sprite>("spaceShipOpen");

        if(spaceshipManager) //�����ȡ��Ʒ���÷ɴ���
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

        if(collision.gameObject.GetComponent<PlayerController>())    
        { 
            if(!isFinded)       // player find it at the first time
            {
                isFinded = true;
                if(!isTheLastSpaceShip)     // replace the sprite for small ship
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = openedSprite;
                }
                // tell space line that there is a new spaceship be finded, send the transform
                spaceLines.SendNewFindSpaceShipPosition(transform.position);
                if(isTheLastSpaceShip)
                {
                    // endGame
                    cameraFollowing.EndGame();
                    return;
                }
            }
        }
        if (isInSpaceship) return; //ÿ�ν���ֻ����һ�β˵�
        if (isTheLastSpaceShip) return;

        if (collision.collider.gameObject.GetComponent<PlayerController>()) //player�������С̫�ղ�
        {
            if(choosed) // ������ѡ����Ʒ��̫�ղ�
            {
                GameObject.Find("Player").GetComponent<PlayerController>().isInSpaceship = true;
                isInSpaceship = true;
                playerRB = collision.collider.gameObject.GetComponent<Rigidbody2D>();
                collision.collider.gameObject.GetComponent<SpringJoint2D>().connectedBody = playerRB;
                // UI binding
                uiManager.ShowEmptyShipUI(this);
                Debug.LogError("Enter spaceship again");
                Time.timeScale = 0;
            }
            else //����û��ѡ����Ʒ��̫�ղ�
            {
                GameObject.Find("Player").GetComponent<PlayerController>().isInSpaceship = true;
                isInSpaceship = true;
                playerRB = collision.collider.gameObject.GetComponent<Rigidbody2D>();
                collision.collider.gameObject.GetComponent<SpringJoint2D>().connectedBody = playerRB;
                // UI binding
                uiManager.UpdateItemUI(this);
                Debug.LogError("Enter spaceship for the first time");
                Time.timeScale = 0;
            }
           

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
