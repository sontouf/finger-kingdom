using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bkk : MonoBehaviour
{
    public string sortingLayerName;
    public int sortingOrder;




    private MeshRenderer render;
    private float offset;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.sortingLayerName = sortingLayerName;
        mesh.sortingOrder = sortingOrder;
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
