using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortalKombat : Item
{
    public override void Recoger()
    {
        score.PuntajeActual += 10;
        Debug.Log("Nombre de Arcade " + nombreItem + "Año de salida: 1992");
        Destroy(gameObject);
    }
}
