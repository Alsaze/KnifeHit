using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Knife : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField]private GameObject enemySpawner;
    private EnemySpawner _enemySpawner;

    public static int CurrentScore;
    private void Start()
    {
        _enemySpawner = enemySpawner.GetComponent<EnemySpawner>();

        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidbody2D.velocity = Vector2.zero; // Останавливаем движение ножа
        _rigidbody2D.isKinematic = true; // Отключаем физику после столкновения
        transform.SetParent(collision.collider.transform); // Делаем столкнувшийся объект родительским для ножа
        
        HitChecker(collision);
    }

    private void HitChecker(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            CurrentScore++;
        }

        if (collision.gameObject.tag=="Knife")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            KnifeThrower.CurrentScoreKnife = 5;
            CurrentScore = 0;
            _enemySpawner.lvl = 0;
        }   
    }
}