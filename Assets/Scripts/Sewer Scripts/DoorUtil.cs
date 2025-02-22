using System.Collections;
using UnityEngine;
public class DoorUtil : MonoBehaviour
{

    private Camera mainCam;

    [SerializeField]
    private LayerMask LayerMask;

    [SerializeField]
    private PlayerFeedbacks feedback;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(AttempEnter());
        }
    }

    private IEnumerator AttempEnter()
    {

        Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask))
        {
            GameObject door = hit.collider.gameObject;
            Debug.Log(door.name);
            if(door.CompareTag("Door"))
            {
                PlayerMovement.LockPlayer(true);

                if(feedback != null)
                feedback.Invoke("Door Open");

                transform.position = Door.NextRoom.transform.position;

                yield return new WaitForSeconds(0.05f);

                PlayerMovement.LockPlayer(false);
                Debug.Log(Door.NextRoom.gameObject.name);
            }
        }

    }
}
