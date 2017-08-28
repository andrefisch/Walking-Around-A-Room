using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    
    public GameObject player;
    private Vector3 offset;

	void Start () 
    {
		offset = transform.position - player.transform.position;
	}
	
    // runs every frame but is guaranteed to run after all items have been processed in update. this ensures player has already moved for that frame
	void LateUpdate () 
    {
		transform.position = player.transform.position + offset;
	}
}
