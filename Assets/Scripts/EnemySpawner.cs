using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy0;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    [SerializeField] private GameObject boss;

    public int lvl=0;

    private void Start()
    {
        lvl = 0;
        Spawn();
    }

    public void Spawn()
    {
        if (lvl==0)
        {
            Instantiate(enemy0, enemy0.transform.position, Quaternion.identity);
        }
        
        if (lvl==1)
        {
            Instantiate(enemy1, enemy1.transform.position, Quaternion.identity);
        }
        
        if (lvl==2)
        {
            Instantiate(enemy2, enemy2.transform.position, Quaternion.identity);
        }
        
        if (lvl==3)
        {
            Instantiate(enemy3, enemy3.transform.position, Quaternion.identity);
        }
        
        if (lvl==4)
        {
            Instantiate(boss, boss.transform.position, Quaternion.identity);
            lvl = 0;
        }
    }
}