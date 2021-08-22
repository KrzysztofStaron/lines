using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(PolygonCollider2D))]
public class lineCollider : MonoBehaviour
{
    public LineRenderer lr;
    public PolygonCollider2D polygonCollider;
    List<Vector2> colliderPoints = new List<Vector2>();

    void Update()
    {
      Vector3[] positions = GetPositions();
      if (positions.Count() >= 2) {
        int numberOfLines = positions.Length - 1;
        polygonCollider.pathCount = numberOfLines;
        for (int i = 0; i < numberOfLines; i++) {
          List<Vector2> currentPositions = new List<Vector2> {
            positions[i],
            positions[i+1]
          };
          List<Vector2> currentColliderPoints = CalculateColliderPoints(currentPositions);
          polygonCollider.SetPath(i, currentColliderPoints.ConvertAll(p => (Vector2)transform.InverseTransformPoint(p)));
        }
      } else {
        polygonCollider.pathCount = 0;
      }
    }


    List<Vector2> CalculateColliderPoints(List<Vector2> positions){
      float width = lr.startWidth;

      float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
      float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
      float deltaY = (width / 2f) * (1 / Mathf.Pow(1 + m * m, 0.5f));

      Vector2[] offsets = new Vector2[2];
      offsets[0] = new Vector2(-deltaX, deltaY);
      offsets[1] = new Vector2(deltaX, -deltaY);

      List<Vector2> colliderPoints = new List<Vector2> {
          positions[0] + offsets[0],
          positions[1] + offsets[0],
          positions[1] + offsets[1],
          positions[0] + offsets[1]
      };

      return colliderPoints;
    }

    public Vector3[] GetPositions() {
        Vector3[] positions = new Vector3[lr.positionCount];
        lr.GetPositions(positions);
        return positions;
    }

}
