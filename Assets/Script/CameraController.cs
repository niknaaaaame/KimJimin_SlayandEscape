using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5f;
    public Vector3 offset = new Vector3(0, 3f, 0);

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
            targetPosition += offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        }
        
    }
}
