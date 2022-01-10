using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Input : MonoBehaviour
{
    SerialPort arduinoPort = new SerialPort("COM3", 9600);

    [SerializeField]
    private RotateCannon rotateManager;

    [SerializeField]
    private FireCannon fireManager;

    char character = ' ';



    private void Update()
    {
        if (!arduinoPort.IsOpen)
        {
            arduinoPort.Open();
        }

        ReadInputValues();
    }


    private void ReadInputValues() 
    {
        Debug.Log(arduinoPort.ReadLine());
        int isFiring = int.Parse(arduinoPort.ReadLine().Split(character)[0]);

        int rotation = int.Parse(arduinoPort.ReadLine().Split(character)[1]);


        fireManager.Fire(isFiring);

        rotateManager.Rotate(rotation);
    }
}
