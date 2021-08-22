using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour
{
    public line line;

    void Update()
    {
      Vector3 difference = new Vector2(line.players[0].position.x - line.players[1].position.x, line.players[0].position.y - line.players[1].position.y) / 2;
      transform.position = new Vector3(line.players[0].position.x, line.players[0].position.y, transform.position.z) - difference;
    }
}
