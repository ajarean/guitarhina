using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private float Speed = 3;
    [SerializeField] private int num = 0;
    private Renderer rend;
    private float alpha = 0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!(rend.material.color.a <= 0)){
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);
        }
        if(num==1){
            if(Input.GetKeyDown(KeyCode.D)){
                colorChange();
            }
        }
        if(num==2){
            if(Input.GetKeyDown(KeyCode.F)){
                colorChange();
            }
        }
        if(num==3){
            if(Input.GetKeyDown(KeyCode.J)){
                colorChange();
            }
        }
        if(num==4){
            if(Input.GetKeyDown(KeyCode.K)){
                colorChange();
            }
        }
        alpha -= Speed * Time.deltaTime;
    }

    void colorChange(){
        alpha = 0.3f;
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);
    }
}
