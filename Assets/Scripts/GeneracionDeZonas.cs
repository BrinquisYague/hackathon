using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeCubos : MonoBehaviour
{
    public GameObject cuboPrefab; // El prefab del cubo que se generará
    public Transform esfera; // La esfera alrededor de la cual se generarán los cubos
    public float radioEsfera = 1.0f; // El radio de la esfera
    public int cantidadDeCubos = 20; // La cantidad de cubos a generar

    void Start()
    {
        GenerarCubos();
    }

    void GenerarCubos()
    {
        for (int i = 0; i < cantidadDeCubos; i++)
        {
            // Generar una posición aleatoria en la superficie de la esfera
            Vector3 posicionAleatoria = Random.onUnitSphere * radioEsfera;

            // Instanciar un cubo en la posición aleatoria
            GameObject cubo = Instantiate(cuboPrefab, posicionAleatoria, Quaternion.identity);

            // Alinear el cubo con la superficie de la esfera
            cubo.transform.LookAt(esfera.position);

            // Escalar el cubo para que esté al 50% dentro de la esfera
            float escala = Random.Range(0.5f, 1.0f);
            cubo.transform.localScale = new Vector3(escala, escala, escala);
        }
    }
}
