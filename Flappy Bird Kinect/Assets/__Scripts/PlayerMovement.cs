using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 150.0f;
    private SpriteRenderer spr;
    public Sprite upFlap;
    public Sprite downFlap;
    public Sprite midFlap;
    public MenuHandler mh;
    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector2.up * jumpForce);

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            mh.OptionsMenu();

        if (rb.velocity.y > 2)
            rb.velocity = new Vector2(0, 2f);

        UpdateSprite(); // Updates bird sprite depending on rigidbody velocity
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        mh.ShowDeathMenu();
    }

    public void Flap()
    {
        rb.AddForce((Vector2.up * jumpForce) * 2);
    }

    void UpdateSprite()
    {
        if (rb.velocity.y > 0)
            spr.sprite = upFlap;
        else if (rb.velocity.y < 0)
            spr.sprite = downFlap;
        else
            spr.sprite = midFlap;
    }

}
