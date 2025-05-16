using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    public float horizontalInput;
    public float verticalInput;

    public GameObject bala;
    public GameObject bala2;

    public bool cambiaObjeto = false;

    private float run = 2f; // correr

    public float fuerzaSalto = 23f; //fuerza del salto (dependiendo de la gravedad, debemos aumentarla)
    private Rigidbody rb;
    private bool enSuelo = true;

    private Vector3 tama�oOriginal;
    private bool tama�oModificado = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tama�oOriginal = transform.localScale;
    }

    void Update()
    {
        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? speed * run : speed;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CambiaMiObjeto();
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * velocidadActual * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * velocidadActual * verticalInput);

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }

        // L�mite del escenario
        if (transform.position.x < -15f) transform.position = new Vector3(-15f, transform.position.y, transform.position.z);
        if (transform.position.x > 9f) transform.position = new Vector3(9f, transform.position.y, transform.position.z);
        if (transform.position.z < -23f) transform.position = new Vector3(transform.position.x, transform.position.y, -23f);
        if (transform.position.z > 22f) transform.position = new Vector3(transform.position.x, transform.position.y, 22f);
    }

    private void CambiaMiObjeto()
    {
        GameObject objeto = cambiaObjeto ? bala2 : bala;
        Instantiate(objeto, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            enSuelo = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUpTama�o")) // al tocar el objeto este desaparece y le da la funcion de cambiar tama�o
        {
            StartCoroutine(CambiarTama�oTemporal());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator CambiarTama�oTemporal()
    {
        if (!tama�oModificado)
        {
            tama�oModificado = true;
            transform.localScale *= 2f;  // Aumenta el tama�o
            yield return new WaitForSeconds(5f);  // colocar el tiempo que queremos que dure el power up 
            transform.localScale = tama�oOriginal;
            tama�oModificado = false;
        }
    }
}

//Daniel Trujillo 222034031