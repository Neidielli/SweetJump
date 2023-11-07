 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    private Rigidbody2D rbd;
    private Animator anim;
    public float vel = 5;
    public float pulo = 250;
    public bool chao = false;
    private bool direita = true;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>();
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

        // Lógica da maquina de estados
        if (x == 0)
            anim.SetBool("parado", true);
        else
            anim.SetBool("parado", false);

        // Lógica de rotação do personagem
        if (direita && x < 0 || !direita && x > 0)
        {
            direita = !direita;
            transform.Rotate(new Vector2(0, 180));
        }
            
        if (chao)
            velY = 0;
        else
            velY = rbd.velocity.y;

        rbd.velocity = new Vector2(x * vel, velY);

        if(Input.GetKeyDown(KeyCode.Space) && chao)
        {
            chao = false;
            transform.parent = null;
            rbd.AddForce(new Vector2(0, pulo));
        }

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -transform.up, 1f, mask);
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }
            
    }

}
