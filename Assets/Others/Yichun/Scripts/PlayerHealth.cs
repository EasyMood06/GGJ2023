using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float hitCD = 2f;
    private float initHitCD = 2f;
    private bool isInHitCD;

    private void Start()
    {
        initHitCD = hitCD;
        isInHitCD = false;
        UpdateHealthUI();
    }
    private void Update()
    {
        if(isInHitCD) 
        {
            hitCD -= Time.deltaTime;
            if (hitCD <= 0)
            {
                hitCD = initHitCD;
                isInHitCD = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError("Hit " + collision.name);
        if (isInHitCD) return; //伤害结算CD中玩家不受伤
        if (collision.gameObject.GetComponent<Enemy>())
        {
            health -= collision.gameObject.GetComponent<Enemy>().enemyHit;
            isInHitCD = true;
            UpdateHealthUI();
        }
    }
  
    private void UpdateHealthUI()
    {
        if (health <= 0)
            health = 0;

        if (health > numOfHearts) // 当前health不得超过ui可显示数量上限
            health = numOfHearts;

        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            if (i < numOfHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
