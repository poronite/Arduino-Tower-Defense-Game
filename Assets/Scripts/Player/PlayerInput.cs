using UnityEngine;
using System.IO.Ports;

public class PlayerInput : MonoBehaviour
{
    SerialPort arduinoPort = new SerialPort("COM3", 9600);

    [SerializeField]
    private RotateCannon rotateManager;

    [SerializeField]
    private FireCannon fireManager;

    char character = ' ';

    private void Update()
    {
        ReadInputValuesKeyboard();

            //if (!arduinoPort.IsOpen)
            //{
            //    arduinoPort.Open();
            //}
            //ReadInputValues();
    }

    private void ReadInputValuesKeyboard()
    {
        if(Input.GetKey(KeyCode.W))
        rotateManager.RotateKeyboard(100 * Time.deltaTime);

        if(Input.GetKey(KeyCode.E))
            rotateManager.RotateKeyboard(-100 * Time.deltaTime);

        if(Input.GetKey(KeyCode.Q))
        fireManager.Fire(0);
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
