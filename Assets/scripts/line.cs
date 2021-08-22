using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class line : MonoBehaviour
{
  LineRenderer lr;
  public float range;
  public List<Transform> points;
  public List<Transform> players;

    void Start(){
      lr = GetComponent<LineRenderer>();
    }

    void Update(){
      lr.SetPositions(points.ConvertAll(n => n.position).ToArray());
      setDisplay(Vector2.Distance(players[0].position, players[1].position) < range);
    }

     public void setDisplay(bool arg){
       lr.enabled = arg;
       GetComponent<PolygonCollider2D>().enabled = arg;
     }
}
