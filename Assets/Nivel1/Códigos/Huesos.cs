using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Huesos : MonoBehaviour
{
    public static bool huesito;
    

    public AudioSource clip;
    
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //buscar un objeto dentro del mundo q tenga ese scrip
            Destroy(gameObject,0.5f);
            
            clip.Play();
            huesito = true;

        }
    }

}
