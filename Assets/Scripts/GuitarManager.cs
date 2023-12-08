using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuitarManager : MonoBehaviour
{
    [SerializeField] RawImage guitar;
    [SerializeField] Texture2D happy;
    [SerializeField] Texture2D worried;
    [SerializeField] Texture2D stressed;
    [SerializeField] Texture2D crying;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(GManager.instance.hp >= 75){
            guitar.texture = happy;
        }
        else if(GManager.instance.hp >= 50){
            guitar.texture = worried;
        }
        else if(GManager.instance.hp >= 25){
            guitar.texture = stressed;
        }
        else{
            guitar.texture = crying;
        }
    }
}
