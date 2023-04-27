using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HuesosManager : MonoBehaviour
{
    public TextMeshProUGUI hueso;
    
    private void Start()
    {

        HuesosCollected();
    }
    public void HuesosCollected()
    {
        if (transform.childCount==0)
        {
            Debug.Log("No quedan frutas, VICTORIA");
        }
    }
}
