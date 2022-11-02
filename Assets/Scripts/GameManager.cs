using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAME_MANAGER;
    public bool resetCappy;

    private void Awake()
    {
        if (_GAME_MANAGER != null && _GAME_MANAGER != this)
        {
            Destroy(_GAME_MANAGER);

        }
        else
        {
            _GAME_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        resetCappy = true;   
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    public void ResetCappy(bool reset)
    {
        resetCappy = reset;
    }
}
