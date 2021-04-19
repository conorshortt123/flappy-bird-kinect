using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    public float speed = -2f;
    public ScoreController sc;
    private float score;

    private void Start()
    {
        sc = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreController>();
    }

    void Update()
    {
        score = sc.GetScore();
        gameObject.transform.position += new Vector3(Time.deltaTime * (speed - (score / 10)), 0, 0);
    }
}
