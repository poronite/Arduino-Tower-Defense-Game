using UnityEngine;
using System.IO.Ports;
using System.Linq;

public class PlayerInput : MonoBehaviour
{
    private string inputMethod;

    SerialPort arduinoPort;

    [SerializeField]
    private RotateCannon rotateManager;

    [SerializeField]
    private FireCannon fireManager;

    char character = ' ';

    private void Awake()
    {
        bool portExists = SerialPort.GetPortNames().Any(name => name == "COM3");

        if (portExists)
        {
            arduinoPort = new SerialPort("COM3", 9600);
            inputMethod = "Arduino";
        }
        else
        {
            inputMethod = "Keyboard";
        }
        
    }

    private void Update()
    {
        CurrentInputMethod();
    }


    private void CurrentInputMethod()
    {
        switch (inputMethod)
        {
            case "Arduino":
                if (!arduinoPort.IsOpen)
                {
                    arduinoPort.Open();
                }
                ReadInputValuesArduino();
                break;
            case "Keyboard":
                ReadInputValuesKeyboard();
                break;
            default:
                break;
        }
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

    private void ReadInputValuesArduino()
    {
        //Debug.Log(arduinoPort.ReadLine());

        int isFiring = int.Parse(arduinoPort.ReadLine().Split(character)[0]);

        int rotation = int.Parse(arduinoPort.ReadLine().Split(character)[1]);

        fireManager.Fire(isFiring);

        rotateManager.Rotate(rotation);
    }
}
