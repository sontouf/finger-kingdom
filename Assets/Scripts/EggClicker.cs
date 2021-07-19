using UnityEngine;
using UnityEngine.EventSystems;

public class EggClicker : MonoBehaviour, IPointerClickHandler
{
    // Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(name + " Game Object Clicked!");
        this.gameObject.GetComponent<EggManager>().IsSelected = true;
        Debug.Log(this.gameObject.GetComponent<EggManager>().IsSelected);
    } 
}