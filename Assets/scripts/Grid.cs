using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public float width = 32.0f;
    public float height = 32.0f;
    public Color color = Color.white;

    private void OnDrawGizmos()
    {
        Vector3 pos = Camera.current.transform.position;
        Gizmos.color = this.color;

        for(float y = pos.y - 800.0f; y < pos.y + 800.0f; y += this.height)
        {
            Gizmos.DrawLine(new Vector3(-10000000.0f, Mathf.Floor(y / this.height) * this.height, 0.0f), new Vector3(1000000.0f, Mathf.Floor(y / this.height) * this.height, 0.0f));
        }
        for(float x=pos.x-1200.0f;x<pos.x + 1200.0f; x += this.width)
        {
            Gizmos.DrawLine(new Vector3(Mathf.Floor(x / this.width) * this.width, -1000000.0f, 0.0f), new Vector3(Mathf.Floor(x / this.width) * this.width, 1000000.0f, 0.0f));
        }
    }
}
