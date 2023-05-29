using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class KnifeThrower : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private GameObject knifePrefab;

    public static int CurrentScoreKnife = 5;

    private void DefaultKnifePosotion()
    {
        float knifePositionY = -3.5f;
        knifePrefab.transform.position = new Vector3(0, knifePositionY, 0);
    }

    private void SpawnKnife()
    {
        if (CurrentScoreKnife>0)
        {
            GameObject newKnife = Instantiate(knifePrefab, knifePrefab.transform.position, quaternion.identity);
            _rigidbody2D = newKnife.GetComponent<Rigidbody2D>();   
        }
    }

    private void Start()
    {
        DefaultKnifePosotion();
    }

    public void ButtonHit()
    {
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
        _rigidbody2D.AddForce(direction * throwForce, ForceMode2D.Impulse); // применить силу броска к Rigidbody
    }

    private void Update()
    {
        InputSystem();
    }
}