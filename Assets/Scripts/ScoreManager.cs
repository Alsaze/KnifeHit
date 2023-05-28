
    using System;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.UI;

    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private Text scoreText;

        private void Update()
        {
            scoreText.text = Convert.ToString(Knife.currentScore);
        }
    }