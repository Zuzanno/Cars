using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cam : MonoBehaviour
{
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    public Movement _mov;

    public enum rotationAxes
    {
        //Given aliases to X and Y cordinates
        keyX = 1,
    }
    public rotationAxes axes = rotationAxes.keyX;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _mov = GetComponent<Movement>();
        if (_mov.speed >= 3.0f)
        {
            if (axes == rotationAxes.keyX)
            {
                //Movimiento en el eje X de la camara
                transform.Rotate(0, Input.GetAxis("Horizontal") * sensitivityHor, 0);
            }
        }
    }
   
}