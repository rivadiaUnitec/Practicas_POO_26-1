using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{

    public GameObject[] luces;

    public Score score;

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
        //En vez de buscar por etiqueta ahora vas a busca por tipo de componente heredado

        Item itemRecodigo = other.GetComponent<Item>();

        if (itemRecodigo != null) {
            
            itemRecodigo.Recoger();
        
        }



        if (other.CompareTag("arcade"))
        {
            // luz.SetActive(true); //aqui el comportamient es individual por objeto

            foreach (var luz in luces) {

                luz.SetActive(true); //Al esta dentro de un bucle aplica a todos los
                //objetos del grupo
            }


            Debug.Log("Hecha una ficha");
        }

        if (other.CompareTag("item"))
        {
            score.CalcularPuntaje();
            other.gameObject.SetActive(false);
            Debug.Log("Obtuviste un PejeDolar");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("arcade"))
        {
            // luz.SetActive(false);

            foreach (var luz in luces)
            {

                luz.SetActive(false); //Al esta dentro de un bucle aplica a todos los
                //objetos del grupo
            }
            Debug.Log("Game Over: regresa cuando quieras");
        }
    }

}//Puerta al infierno
