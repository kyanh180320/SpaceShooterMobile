using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreRegistration : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        TextMeshProUGUI textForRegistration = GetComponent<TextMeshProUGUI>();  
        EndGameManager.endGameManager.RegisterScoreText(textForRegistration);
        textForRegistration.text = "Score : 0";
    }
}
