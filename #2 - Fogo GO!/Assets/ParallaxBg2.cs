using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBg2 : MonoBehaviour
{
    public Vector2 parallaxEffectMultiplier;
    public bool infiniteHorizontal;
    public bool infiniteVertical;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    
    private float textureUnitSizeX;
    private float textureUnitSizeY;

    // Adaptation: dont let parallax work until passing a delimiter (distance).
    public GameObject player;
    private float bgIniPosX;
    private bool check;

    private void Start(){

        // Gabriel's adaptation
        bgIniPosX = gameObject.transform.position.x;
        check = false;


        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;


    }

    public void FixedUpdate(){ 

        if(player.transform.position.x < bgIniPosX && !check){
            //Debug.Log("aborting...");
            return;
        }else if(!check){
            cameraTransform = Camera.main.transform;
            lastCameraPosition = cameraTransform.position;
            
            check = true;
        }

        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        if(infiniteHorizontal){
            if( Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX){
                float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                
                if(cameraTransform.position.x + offsetPositionX < bgIniPosX){
                    offsetPositionX = - cameraTransform.position.x + bgIniPosX;
                }
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
            }
        }
    }
}
