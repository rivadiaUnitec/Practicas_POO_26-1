using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantzVsZombies : Item
{
    public override void Recoger()
    {
        score.PuntajeActual++;
        Debug.Log("Nombre de Arcade " + nombreItem + "Año de salida: 2005" + "Dificultad: Alta");
    }
}
