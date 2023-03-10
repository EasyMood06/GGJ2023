using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError("Hit " + collision.collider.name);
        if (isInHitCD) return; //�˺�����CD����Ҳ�����
        if (collision.collider.gameObject.GetComponent<Enemy>())
        {
            health -= collision.collider.gameObject.GetComponent<Enemy>().enemyHit;
            isInHitCD = true;
            UpdateHealthUI();
        }
    }
  
    private void UpdateHealthUI()
    {
        if (health <= 0)
        {    
            health = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (health > numOfHearts) // ��ǰhealth���ó���ui����ʾ��������
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

    public void ChangeHealth(int h, int numberOfHearts)
    {
        health += h;
        numOfHearts += numberOfHearts;
        UpdateHealthUI();
    }
}
