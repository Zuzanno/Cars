using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 0;
    public enum rotationAxes
    {
        //Given aliases to X and Y cordinates
        mouseXandY = 0,
        mouseX = 1,
        mouseY = 2
    }
    public rotationAxes axes = rotationAxes.mouseXandY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if (axes == rotationAxes.mouseX)
            {
                //Movimiento en el eje X de la camara
                transform.Rotate(0, Input.GetAxis("Horizontal") * sensitivityHor, 0);
            }
            else if (axes == rotationAxes.mouseY)
            {
                //Movimiento en el eje Y de la camara 
                _rotationX -= Input.GetAxis("Vertical") * sensitivityVert;
                //Clamp method limits variables to assigned numbers
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            else
            {
                _rotationX -= Input.GetAxis("Horizontal") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                float delta = Input.GetAxis("Vertical") * sensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

                //delta is the amount to change the rotation by.
                //Increment the rotation angle by delta.

            }
        }
    }