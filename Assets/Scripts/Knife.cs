using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Knife : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField]private GameObject enemySpawner;
    private EnemySpawner _enemySpawner;

    public static int currentScore;
    private void Start()
    {
        _enemySpawner = enemySpawner.GetComponent<EnemySpawner>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero; // Останавливаем движение ножа
        rb.isKinematic = true; // Отключаем физику после столкновения
        transform.SetParent(collision.collider.transform); // Делаем столкнувшийся объект родительским для ножа
        
        HitChecker(collision);
    }

    private void HitChecker(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentScore++;
        }

        if (collision.gameObject.tag=="Knife")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            KnifeThrower.currentScoreKnife = 5;
            currentScore = 0;
            _enemySpawner.lvl = 0;
        }   
    }
}