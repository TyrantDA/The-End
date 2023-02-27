using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnButtonPress()
    {
        Debug.Log("next scene");
        SceneManager.LoadScene("SampleScene");
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("highScore1");
        PlayerPrefs.DeleteKey("highScore2");
        PlayerPrefs.DeleteKey("highScore3");
        PlayerPrefs.DeleteKey("highScore4");
        PlayerPrefs.DeleteKey("highScore5");
    }

    public void turnOnOff()
    {
        int hold = PlayerPrefs.GetInt("OnOff", 0);

        if(hold == 0)
        {
            PlayerPrefs.SetInt("OnOff", 1);
        }
        else if (hold == 1)
        {
            PlayerPrefs.SetInt("OnOff", 0);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
