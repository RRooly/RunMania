using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public Text pointsText;
    public Text highScore;
    public static float score = 0;
    public float actualScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actualScore = (int)score;
        pointsText.text = actualScore.ToString(); 
        

        //Permet de sauvegarder le meilleur score effectué
        if (actualScore > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", actualScore);
            highScore.text = actualScore.ToString();
        }
    }

    public void UpdateScore()
    {
        
    }
}
