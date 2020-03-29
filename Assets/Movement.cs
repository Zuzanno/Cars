using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class Movement : MonoBehaviour
{
    private CharacterController _charController;
    public float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
            float deltaZ = Input.GetAxis("Vertical") * speed;
            Vector3 movement = new Vector3(0, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);

    }

}

