using System;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    
    [SerializeField]private GameObject enemySpawner;
    private EnemySpawner _enemySpawner;
    private void Update()
    {
        Rotation();
    }

    private void Start()
    {
        _enemySpawner = enemySpawner.GetComponent<EnemySpawner>();
    }

    private void Rotation()
    {
        float rotationSpeed = 100;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        KnifeThrower.currentScoreKnife -= 1;
        
        if (KnifeThrower.currentScoreKnife == 0)
        {
            _enemySpawner.lvl++;
            Destroy(enemy);
            _enemySpawner.Spawn();
            KnifeThrower.currentScoreKnife = 5;
        }
    }
}