using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colectables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión con: " + other.name);
        mov bala = GetComponent<mov>();
        bala.cambiaObjeto = true;
        Destroy(this.gameObject);
    }

}
