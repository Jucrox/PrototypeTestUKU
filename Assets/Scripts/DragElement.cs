using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Controller controller;
    [SerializeField] private PlayerCollision playerCollision;

    [SerializeField] private Canvas canvas;

    [SerializeField] public GameObject initialParent;

    [SerializeField] private Vector3 lastPosition;
    [SerializeField] public float speed;
    [SerializeField] public bool isDrag = false ;


    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
        controller.dragElement = gameObject;
        playerCollision.dragElement = gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        transform.SetParent(canvas.transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        controller.EndDrag();
    }
    private void Update()
    {
        speed = (((transform.position - lastPosition).magnitude) / Time.deltaTime);
        lastPosition = transform.position;

        controller.PanelOpacityAndScale();
        controller.Image3DTranlate();
    }
}
