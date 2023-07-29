using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;

    private bool playerisoverlapping = false;
   
    // Update is called once per frame
    void Update()
    {
        if(playerisoverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotproduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotproduct<0f)
            {
                float rotationDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffSet = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffSet;

                playerisoverlapping = false;
            }
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            playerisoverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            playerisoverlapping = false;
        }
    }


}
