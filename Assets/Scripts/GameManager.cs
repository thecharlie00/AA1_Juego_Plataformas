using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAME_MANAGER;
    public bool resetCappy;
    public bool isDead;
    public bool isDestroyed;
    public GameObject _cappy;
    public GameObject[] coins;
    public float numCoins;
    

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
        isDead = false;
        coins = GameObject.FindGameObjectsWithTag("Coin");
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        _cappy = GameObject.FindGameObjectWithTag("Cappy");
        if(_cappy == null){ isDestroyed = true; }
        else { isDestroyed = false; }
        if(numCoins == coins.Length && sceneName != "Win")
        {
            SceneManager.LoadScene("Win");
        }
        
    }
    public void ResetCappy(bool reset)
    {
        resetCappy = reset;
    }
    public void PlayerDead(bool dead)
    {
        isDead = dead;
    }
    public void sumCoins()
    {
        numCoins++;
    }
    public void LoadSceneGame()
    {
        SceneManager.LoadScene("complete_track_demo");
    }
}
