using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private int speed;
    [SerializeField] private int jump;
    private bool ground;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    [SerializeField] private Joystick joystick;

    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
        cc = GetComponent<CapsuleCollider2D>();
    }
    private void Update () {
        rb.velocity = new Vector2 (joystick.Horizontal * speed, rb.velocity.y);
        if (joystick.Vertical >= 0.5f)
            Jump ();
            
        Flip ();
    }
    private void Jump () {
       if (ground == true)
            rb.AddForce (transform.up * jump, ForceMode2D.Impulse);
        
    }
    private void Flip () {
        if (joystick.Horizontal > 0)
            transform.localRotation = Quaternion.Euler (0, 180, 0);
        else if (joystick.Horizontal < 0)
            transform.localRotation = Quaternion.Euler (0, 0, 0);
    }
    private void OnTriggerStay2D (Collider2D other) {
        if (other.tag == "ground")
            ground = true;

        if(other.tag == "ladder"){
            rb.gravityScale = 0;
            rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);   
            cc.isTrigger = true;     
        }
    }
    private void OnTriggerExit2D (Collider2D other) {
        if (other.tag == "ground")
            ground = false;
        if(other.tag == "ladder"){
            rb.gravityScale = 1;
            cc.isTrigger = false;
        }
    }
}