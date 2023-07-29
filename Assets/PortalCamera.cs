using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;



    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerOffsetfromPortal = playerCamera.position - otherPortal.position;

        transform.position = portal.position + playerOffsetfromPortal;

        float angulardifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angulardifferenceBetweenPortalRotations, Vector3.up);

        Vector3 newcameradirection = portalRotationDifference * playerCamera.forward;

        transform.rotation = Quaternion.LookRotation(newcameradirection, Vector3.up);
        
    }
}
