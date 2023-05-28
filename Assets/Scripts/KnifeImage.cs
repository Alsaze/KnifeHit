using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeImage : MonoBehaviour
{
    [SerializeField] private List<Image> knifeImage = new List<Image>();

    private void Update()
    {
        if (KnifeThrower.currentScoreKnife <= 4 && KnifeThrower.currentScoreKnife >= 0)
        {
            knifeImage[KnifeThrower.currentScoreKnife].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (KnifeThrower.currentScoreKnife == 5)
        {
            foreach (var knife in knifeImage)
            { 
                knife.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}