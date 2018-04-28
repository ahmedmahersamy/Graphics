using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class VirtualJoyStick : MonoBehaviour , IDragHandler ,IPointerUpHandler , IPointerDownHandler
{
    private Image bgImg;
    private Image joyStickImg;
    private Vector3 inputVector;


    // Use this for initialization
    void Start () {
        bgImg = GetComponent<Image>();
        joyStickImg = transform.GetChild(0).GetComponent<Image>();
	}
	public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) 
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.x / bgImg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x*3f +1 , 0f, pos.y*3f - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized: inputVector;

            // moving joystick
            joyStickImg.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x/3),
                inputVector.z * (bgImg.rectTransform.sizeDelta.y/3));
        }    
        
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {

    }
    public virtual void OnPointerUp(PointerEventData ped)
    {

    }
    // Update is called once per frame
    void Update () {
		
	}
}
