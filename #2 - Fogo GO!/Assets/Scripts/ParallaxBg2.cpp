using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Vector2 parallaxEffectMultiplier;
    public bool infiniteHorizontal;
    public bool infiniteVertical;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    
    private float textureUnitSizeX;
    private float textureUnitSizeY;

    private GameObject bg;
    private float bgIniPosX;

    private void Start(){
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;

        // Gabriel's adaptation
        bgIniPosX = gameObject.transform.position.x;
        Debug.Log("First Pos: " + bgIniPosX);

    }

    public void FixedUpdate(){ 

        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        if(infiniteHorizontal){
            if( Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX){
                float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
            }
        }

        if(infiniteVertical){
            if( Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY){
                float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(cameraTransform.position.x, transform.position.y + offsetPositionY);
            }
        }
    }
}
