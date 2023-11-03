 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float vel = 5;
    public float pulo = 250;
    public bool chao = false;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        chao = true;
        transform.parent = collision.transform;
    }

    // Quando sai do chão, o chão é falso
    private void OnCollisionExit2D(Collision2D collision)
    {
        chao = false;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float velY;
        if (chao)
            velY = 0;
        else
            velY = rbd.velocity.y;

        rbd.velocity = new Vector2(x * vel, velY);

        if(Input.GetKeyDown(KeyCode.Space) && chao)
        {
            chao = false;
            rbd.AddForce(new Vector2(0, pulo));
        }
    }

}
