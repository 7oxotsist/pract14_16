using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObj : MonoBehaviour
{
    public float ySensitivity = 300f;
    public float frontOpenPosLimit = 45;
    public float backOpenPosLimit = 45;

    public GameObject door;
    public GameObject frontDoorCollider;
    public GameObject backDoorCollider;

    bool moveDoor = false;
    DoorCollision doorCollision = DoorCollision.NONE;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(doorMover());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            

            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.collider.gameObject == frontDoorCollider)
                {
                    moveDoor = true;
                    
                    doorCollision = DoorCollision.FRONT;
                }
                else if (hitInfo.collider.gameObject == backDoorCollider)
                {
                    moveDoor = true;
                    
                    doorCollision = DoorCollision.BACK;
                }
                else
                {
                    doorCollision = DoorCollision.NONE;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveDoor = false;
            
        }
    }

    IEnumerator doorMover()
    {
        bool stoppedBefore = false;
        float yRot = 0;

        while (true)
        {
            if (moveDoor)
            {
                stoppedBefore = false;
               

                yRot += Input.GetAxis("Mouse X") * ySensitivity * Time.deltaTime;


                
                if (doorCollision == DoorCollision.FRONT)
                {                    
                    yRot = Mathf.Clamp(yRot, -frontOpenPosLimit, 0);
                    Debug.Log(yRot);
                    transform.localEulerAngles = new Vector3(0, -yRot, 0);
                }
                else if (doorCollision == DoorCollision.BACK)
                {
                    
                    yRot = Mathf.Clamp(yRot, 0, backOpenPosLimit);
                    Debug.Log(yRot);
                    transform.localEulerAngles = new Vector3(0, yRot, 0);
                }
            }
            else
            {
                if (!stoppedBefore)
                {
                    stoppedBefore = true;
                    
                }
            }

            yield return null;
        }

    }


    enum DoorCollision
    {
        NONE, FRONT, BACK
    }
}