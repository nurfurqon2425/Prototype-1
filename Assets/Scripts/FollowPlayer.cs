using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3();
    private readonly Vector3 offset1 = new Vector3(0, 4, -6);
    private readonly Vector3 offset2 = new Vector3(0, 2, 1);

    // Start is called before the first frame update
    void Start()
    {
        offset = offset1;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //    transform.position = player.transform.position + offset;
    //}

    void LateUpdate()
    {
        //Offset the camera to the player's position
        
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(offset == offset1)
            {
                offset = offset2;
            }
            else
            {
                offset = offset1;
            }

        }
        transform.position = player.transform.position + offset;
    }
}
