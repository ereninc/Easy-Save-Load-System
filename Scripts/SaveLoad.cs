using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public TextMeshProUGUI textVal;
    int val = 0;
    public void Save()
    {
        PlayerPrefs.SetInt("Value", val);
    }

    public void Load()
    {
        val = PlayerPrefs.GetInt("Value", 0);
        if(PlayerPrefs.HasKey("Value"))
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            if(currentIndex == val)
            {

            }
            else
            {
                SceneManager.LoadScene(val);
            }
        }
        textVal.text = val.ToString();
    }

    public void Delete()
    {
        val = 0;
    }

    public void IncreaseValue()
    {
        val++;
        textVal.text = val.ToString();
    }

    public void DecreaseValue()
    {
        if(val <= 0)
        {
            val = 0;
            textVal.text = val.ToString();
        }
        else 
        {
            val--;
            textVal.text = val.ToString();
        }
    }

    public void OnAwake()
    {
        Delete();
        Load();
    }
    
    public void Start()
    {
        Delete();
        Load();
    }

    public void Update()
    {
        Save();
    }
}
