﻿using UnityEngine;
using System.Collections;

public class OverheadHealthbarController : MonoBehaviour
{
    SpriteRenderer rend;
    
    public Sprite[] healthbarSprites;
    GameControl gameCtrl;
    PlayerController playerCtrl;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        playerCtrl = GetComponentInParent<PlayerController>();
        gameCtrl = GameObject.Find("GameController").GetComponent<GameControl>();
    }
    void Update()
    {

        switch (gameCtrl.gameState)
        {
            case "live-end":
                rend.sprite = healthbarSprites[healthbarSprites.Length - 1];
                break;

            default:
                float hpPerc = ((float)playerCtrl.health / playerCtrl.maxHealth) * 100f;

                float indexDivider = 100 / (healthbarSprites.Length - 1);
                int spriteIndex = (int)((hpPerc + 2.5f) / indexDivider);
                rend.sprite = healthbarSprites[spriteIndex];
                // look at active character.
                transform.LookAt(gameCtrl.activeInst.transform);
                break;
        }
        
        
    }
}
