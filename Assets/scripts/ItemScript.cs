using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            SoundEffect.Instance.MakeEatSound();
            Destroy(gameObject);
            GameManager.countEat();
        }
    }

}
