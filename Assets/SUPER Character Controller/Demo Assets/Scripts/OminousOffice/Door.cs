using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;

public class Door : MonoBehaviour, IInteractable
{   
    public float openAngle = -105;
    public bool reverse, doorOpen = false;
    public bool lockedDoor = false;

    public bool Interact(){
        if (lockedDoor)
        {
            //Play a locked Audio
        }
        else
        {
            if(!doorOpen){
                reverse = false;
                doorOpen = true;
                StartCoroutine(OpenDoor());
                return true;
            }
            else
            {
                reverse = true;
                doorOpen = false;
                StartCoroutine(OpenDoor());
            }
        }
        return false;
    }

    IEnumerator OpenDoor(){
        float alpha = 0, newY =transform.localEulerAngles.y+  (reverse? -openAngle: openAngle);
        while(alpha <1){
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0,newY,0),alpha);
            alpha+= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        //Destroy(this);
        yield return null;
    }
}
