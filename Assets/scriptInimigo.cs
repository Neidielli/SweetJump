using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptInimigo : MonoBehaviour
{
    public float vel = 5;
    private Rigidbody2D rbd;
    public LayerMask mask;
    public LayerMask maskPlayer;
    public float distancia = 0.4f;
    public SceneController controller;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rbd.velocity = new Vector2(vel, 0);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.right, distancia, mask);

        if (hit.collider != null)
        {
            vel = vel * -1;
            rbd.velocity = new Vector2(vel, 0);
            transform.Rotate(new Vector2(0, 180));
        }

        RaycastHit2D hitPlayer;
        hitPlayer = Physics2D.Raycast(transform.position, transform.right, distancia, maskPlayer);

        if (hitPlayer.collider != null)
        {
            Destroy(hitPlayer.collider.gameObject);
            controller.EndGame();
        }


    }
}
