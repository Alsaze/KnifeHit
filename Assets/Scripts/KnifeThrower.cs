using System;
using Unity.Mathematics;
using UnityEngine;

public class KnifeThrower : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject KnifePrefab;

    public static int currentScoreKnife = 5;

    private void DefaultKnifePosotion()
    {
        float knifePositionY = -3.5f;
        KnifePrefab.transform.position = new Vector3(0, knifePositionY, 0);
    }

    private void SpawnKnife()
    {
        if (currentScoreKnife>0)
        {
            GameObject newKnife = Instantiate(KnifePrefab, KnifePrefab.transform.position, quaternion.identity);
            rb = newKnife.GetComponent<Rigidbody2D>();   
        }
    }

    private void Start()
    {
        DefaultKnifePosotion();
    }

    public void ButtonHit()
    {
        Debug.Log("Button Hit");
        SpawnKnife();
        ThrowKnife();
    }
    private void InputSystem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnKnife();
            ThrowKnife();
        }
    }

    private void ThrowKnife()
    {
        float throwForce = 15f;
        Vector2 direction = new Vector2(0, 1); // направление броска
        rb.AddForce(direction * throwForce, ForceMode2D.Impulse); // применить силу броска к Rigidbody
    }

    private void Update()
    {
        InputSystem();
    }
}