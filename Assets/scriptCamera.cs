using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    public GameObject pc;
    //public float offset_y = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Camera seguindo o PC
        Vector3 posicao = new Vector3(pc.transform.position.x, pc.transform.position.y, -10);
        this.transform.position = posicao;    
    }
}
