using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { Joystick, Button, WASD }

public class TypeController : MonoBehaviour {

    [SerializeField] private Type type = new Type ();
    public float directionX;
    public float directionY;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject button;

    private void Update () {
        if (type == Type.Joystick) {
            button.SetActive (false);
            joystick.SetActive (true);
            directionX = joystick.GetComponent<Joystick> ().Horizontal;
            directionY = joystick.GetComponent<Joystick> ().Vertical;
        } else if (type == Type.Button) {
            joystick.SetActive (false);
            button.SetActive (true);
        } else if (type == Type.WASD) {
            joystick.SetActive (false);
            button.SetActive (false);
            directionX = Input.GetAxis ("Horizontal");
            directionY = Input.GetAxis ("Vertical");
        }
    }
    public void ChangeDirectionX (int buttonDirection) {
        directionX = buttonDirection;
    }
    public void ChangeDirectionY (int buttonDirection) {
        directionY = buttonDirection;
    }

}