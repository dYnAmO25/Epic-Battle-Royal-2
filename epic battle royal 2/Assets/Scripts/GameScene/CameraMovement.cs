using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] int iSense;
    [SerializeField] int iMaxRotation;
    [SerializeField] int iMinRotation;

    [SerializeField] float[] fZoom;
    [SerializeField] GameObject goCamera;

    int iCurrentZoom = 2;

    float fxRotate;
    float fyRotate;

    public GameObject goTargetObject;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;

            fxRotate += (Input.GetAxis("Mouse X") * Time.deltaTime * iSense);
            fyRotate += (Input.GetAxis("Mouse Y") * Time.deltaTime * iSense * -1);

            fyRotate = Mathf.Min(iMinRotation, Mathf.Max(iMaxRotation, fyRotate));

            transform.rotation = Quaternion.Euler(fyRotate, fxRotate, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        //Zooms
        if (Input.mouseScrollDelta.y > 0 && iCurrentZoom > 0)
        {
            iCurrentZoom--;
        }
        else if (Input.mouseScrollDelta.y < 0 && iCurrentZoom < fZoom.Length - 1)
        {
            iCurrentZoom++;
        }

        goCamera.transform.localPosition = new Vector3(0, 0, fZoom[iCurrentZoom]);

        //Target Tracking
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = goCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    goTargetObject = hit.collider.gameObject;
                }
            }
        }

        if (goTargetObject != null)
        {
            transform.position = goTargetObject.transform.position;
        }
        else
        {
            goTargetObject = GetNearestGameObject();
        }
    }

    GameObject GetNearestGameObject()
    {
        GameObject[] goPlayers = GameObject.FindGameObjectsWithTag("Player");

        GameObject goClosest = gameObject;
        float fDistance = 10000;

        for (int i = 0; i < goPlayers.Length; i++)
        {
            if (Vector3.Distance(transform.position, goPlayers[i].transform.position) < fDistance)
            {
                fDistance = Vector3.Distance(transform.position, goPlayers[i].transform.position);
                goClosest = goPlayers[i];
            }
        }

        return goClosest;
    }
}
