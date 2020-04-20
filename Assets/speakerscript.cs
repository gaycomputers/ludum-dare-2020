using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speakerscript : MonoBehaviour
{
    
    public SpriteRenderer speaker;
    public Sprite sprite1;
    public Sprite sprite2;
    public int BumpInterval = 60;
    private int intervalCount = 0;
    private bool sprite2_bool = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        if (intervalCount >= BumpInterval){
            if (sprite2_bool){
                speaker.sprite = sprite2;
                sprite2_bool = false;
            }
            else {
                speaker.sprite = sprite1;
                sprite2_bool = true;
            }
            intervalCount = 0;
        }
        else{
            intervalCount++;
        }
    }
}
