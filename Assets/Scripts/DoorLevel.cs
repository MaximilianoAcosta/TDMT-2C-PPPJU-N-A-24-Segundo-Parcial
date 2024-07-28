using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorLevel : MonoBehaviour
{
    [SerializeField] GameObject DoorUp;
    [SerializeField] GameObject DoorDown;

    [SerializeField] int ammountOfButtons;

    float DoorSpeed = 0;


    private void FixedUpdate()
    {
        DoorUp.transform.position += DoorSpeed * Time.deltaTime * Vector3.up;
        DoorDown.transform.position += DoorSpeed * Time.deltaTime * Vector3.down;
    }
    public void OpenDoor()
    {
        if(ConsoleDoorButton.ButtonsPressed >= ammountOfButtons)
        {
            StartCoroutine(MoveDoor());
        }
    }
    private IEnumerator MoveDoor()
    {
        DoorSpeed = 5;
        yield return new WaitForSeconds(DoorSpeed);
        DoorSpeed = 0;
    }
}
