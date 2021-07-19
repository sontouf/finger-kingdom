using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class ArrowScript : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler 
{
    const string prefabPath = "Prefabs/ArrowPrefab";


    [SerializeField]
    private GameObject arrowPrefab;
    private GameObject arrowObject;

   
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        arrowObject = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
    }


    private bool checkEndDrop = false;
    public bool CheckEndDrop { get; set; }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drop");
        Destroy(arrowObject);
        CheckEndDrop = true;
    }

    private void Awake()
    {
        arrowPrefab = Resources.Load(prefabPath) as GameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (arrowObject != null) {
            Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
            arrowObject.transform.rotation = Quaternion.Euler(0, 0, 180+z);
            Debug.Log(Vector2.SqrMagnitude(len));
        }
       
    }
}
