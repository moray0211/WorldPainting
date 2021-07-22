using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeObject : MonoBehaviour 
{
    public Sprite[] imgs;
    
    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer=this.GetComponent<SpriteRenderer>();
    }

    public void changecolor(int color){
        if(spriteRenderer!=null){
            if(color>0){
                spriteRenderer.sprite=imgs[color];
            }
        }else{
            spriteRenderer=this.GetComponent<SpriteRenderer>();
            if(color>0){
                spriteRenderer.sprite=imgs[color];
            }  
        }
    }

}
