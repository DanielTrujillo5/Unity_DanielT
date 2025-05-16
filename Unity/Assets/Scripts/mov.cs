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

    private Vector3 tamañoOriginal;
    private bool tamañoModificado = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tamañoOriginal = transform.localScale;
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

        // Límite del escenario
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
        if (other.CompareTag("PowerUpTamaño")) // al tocar el objeto este desaparece y le da la funcion de cambiar tamaño
        {
            StartCoroutine(CambiarTamañoTemporal());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator CambiarTamañoTemporal()
    {
        if (!tamañoModificado)
        {
            tamañoModificado = true;
            transform.localScale *= 2f;  // Aumenta el tamaño
            yield return new WaitForSeconds(5f);  // colocar el tiempo que queremos que dure el power up 
            transform.localScale = tamañoOriginal;
            tamañoModificado = false;
        }
    }
}

//Daniel Trujillo 222034031