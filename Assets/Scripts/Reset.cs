using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._GAME_MANAGER.isDead)
        {
            Instantiate(player, this.transform.position, this.transform.rotation);
            GameManager._GAME_MANAGER.PlayerDead(false);
        }
    }
}
