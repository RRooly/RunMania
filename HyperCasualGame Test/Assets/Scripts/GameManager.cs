using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Redemarage dans 3, 2, 1");
            StartCoroutine(Restart());
            
        }
        
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Redemarage du niveau");
        SceneManager.LoadScene("Level1");
    }
}
