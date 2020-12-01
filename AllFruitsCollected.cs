using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllFruitsCollected : MonoBehaviour
{
    public static int fruitCounter;
    public static int fruitsCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        fruitCounter = gameObject.transform.childCount;
    }

    // Update is called once per frame
    public void allFruitsCollected()
    {
        if (fruitsCollected == fruitCounter) 
        {
            Debug.Log("Victoria shurmano");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
