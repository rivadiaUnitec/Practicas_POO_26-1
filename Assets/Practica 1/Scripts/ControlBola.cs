using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBola : MonoBehaviour
{

    public Rigidbody rb;

    //Variables parqa apuntar
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo= -2f;
    public float limiteDerecho = 2f;



    public float fuerzaDeLanzamiento = 1000f;

    private bool haSidoLanzada = false;

    // TODO: Referencia a la cámara y score
    public CameraFollow cameraFollow;
    public ScoreManager scoreManager;







    // Start is called before the first frame update
    void Start()
    {
        // PISTA: Obtener el componente Rigidbody de esta bola
         rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {       //Expresion:mientras que haSidoLanzada sea falso pues disparar 
        if (haSidoLanzada==false)
        {

            Apuntar();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();
            }

        }
    }

    void Apuntar()
    {
        //1. Leer un input Horozontal de tipo Axis, te permite registrar
        //entradas con la teclas A y D, y Flecha izquierda y Flecha Derecha
        float inputHorizontal = Input.GetAxis("Horizontal");

        //2. mover la bola hacia los lados
        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);

        //3.Delimitar el movimiento de la bola
        Vector3 posicionActual = transform.position;

        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);

        transform.position = posicionActual;
    }


    void Lanzar()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);

        // PISTA: Iniciar seguimiento de la cámara (si existe)
       if (cameraFollow != null) cameraFollow.IniciarSeguimiento();

    }

    void OnCollisionEnter(Collision collision)
    {
        // PISTA: Si colisiona con un pino
        if (collision.gameObject.CompareTag("Pin"))
        {
            // PISTA: Detener seguimiento de cámara (si no es null)
            if (cameraFollow != null) cameraFollow.DetenerSeguimiento();

            // PISTA: Calcular puntaje tras un pequeño retraso
             if (scoreManager != null) Invoke("CalcularPuntaje", 0f);
        }
    }

    void CalcularPuntaje()
    {
        // PISTA: Llamar al ScoreManager para actualizar puntos
         scoreManager.CalcularPuntaje();
    }


}// Bienvenido a la entrada al infierno
