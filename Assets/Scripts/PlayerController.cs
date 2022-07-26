using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private Camera cam;
    public LayerMask movementLayerMask;
    public float maxMovementDistance = 100f;
    private PlayerMotor playerMotor;

    void Start()
    {
        cam = Camera.main;
        playerMotor = GetComponent<PlayerMotor>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxMovementDistance, movementLayerMask))
            {
                playerMotor.MoveToPoint(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxMovementDistance))
            {
                // playerMotor.MoveToPoint(hit.point);
            }
        }
    }
}
