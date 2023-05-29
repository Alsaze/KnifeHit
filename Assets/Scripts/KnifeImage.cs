using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeImage : MonoBehaviour
{
    [SerializeField] private List<Image> knifeImage = new List<Image>();

    private void Update()
    {
        if (KnifeThrower.CurrentScoreKnife <= 4 && KnifeThrower.CurrentScoreKnife >= 0)
        {
            knifeImage[KnifeThrower.CurrentScoreKnife].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (KnifeThrower.CurrentScoreKnife == 5)
        {
            foreach (var knife in knifeImage)
            { 
                knife.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}