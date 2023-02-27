using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public Text t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "LeaderBoard: \n 1: " + 
            PlayerPrefs.GetFloat("highScore1", 0) 
            + "\n 2: " + PlayerPrefs.GetFloat("highScore2", 0) 
            + "\n 3: " + PlayerPrefs.GetFloat("highScore3", 0) 
            + "\n 4: " + PlayerPrefs.GetFloat("highScore4", 0) 
            + "\n 5: " + PlayerPrefs.GetFloat("highScore5", 0);
    }
}
