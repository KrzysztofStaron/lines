using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Joystick moveJoystick;
    public Transform secoundPlayer;

    void Start(){
      rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
      Vector2 movement = new Vector3(moveJoystick.Horizontal, moveJoystick.Vertical) * speed * Time.fixedDeltaTime;
      rb.MovePosition(transform.position + toVector3(movement));
      if (secoundPlayer.position.x - transform.position.x < 0) {
        transform.localScale = new Vector3(-1,1,1);
      } else {
        transform.localScale = new Vector3(1,1,1);
      }
    }

    Vector3 toVector3(Vector2 v){
      return new Vector3(v.x, v.y, 0);
    }

}
