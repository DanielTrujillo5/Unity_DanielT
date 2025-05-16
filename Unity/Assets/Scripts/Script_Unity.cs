using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Unity : MonoBehaviour
{
    public float posx = 0f;
    public float posy = 9.88f;
    public float posz = 54.11f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Mi nombre es: " + name);
        //Debug.Log("Posici�n en X: " + transform.position.x);
        //Debug.Log("La posici�n actual es: " + transform.position);
        transform.position = new Vector3(posx,posy,posz);
        Debug.Log("Nueva posici�n camara: " + transform.position);
        Debug.Log("Mi nombre es: " + name);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Hello world Unity Engine");
    }
}
