using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionHandler : MonoBehaviour
{
    private ScoreController sc;

    void Start()
    {
        sc = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            sc.IncrementScore();
    }
}
