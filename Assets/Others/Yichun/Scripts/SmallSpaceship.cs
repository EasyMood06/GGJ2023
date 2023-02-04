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
    private bool isInSpaceship;
    private bool throwed;
    private Rigidbody2D playerRB;
    private void Start()
    {
        isInSpaceship = false;
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
        uiManager = FindObjectOfType<UIManager>();

        if(spaceshipManager) //�����ȡ��Ʒ���÷ɴ���
        {
            spaceshipManager.RandomSpawnItems(item1Level, 0, this);
            spaceshipManager.RandomSpawnItems(item2Level, 1, this);
            spaceshipManager.RandomSpawnItems(item3Level, 2, this);
            Debug.LogError("Complete spaceship item random spawn");
            
        }
    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (isInSpaceship) return; //ÿ�ν���ֻ����һ�β˵�
        if (collision.gameObject.GetComponent<PlayerController>()) //player�������С̫�ղ�
        {
            GameObject.Find("Player").GetComponent<PlayerController>().isInSpaceship = true;
            isInSpaceship = true;
            playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            collision.gameObject.GetComponent<SpringJoint2D>().connectedBody = playerRB;
            // UI binding
            uiManager.UpdateItemUI(this);
            Debug.LogError("Enter spaceship");
            Time.timeScale = 0;

        }
    }

    private void OnCollisionExit2D(Collider2D collision)
    {
        isInSpaceship = false;
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