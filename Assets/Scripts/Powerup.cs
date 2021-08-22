﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]  // 0 = Triple Shot; 1 = Speed; 2 = Shields
    private int powerupID;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Vector3.down * Time.deltaTime);
        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive(); break;
                    case 1:
                        player.SpeedBoostActive(); break;
                    case 2:
                        player.ShieldsActive(); break;
                    default:
                        Debug.LogError("Unknown powerupID = " + powerupID); break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
