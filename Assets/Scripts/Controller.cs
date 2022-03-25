using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] private bool isDropToTarget = false;

    [SerializeField] public GameObject dragElement = null;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject image3D;
    [SerializeField] private GameObject content;

    [SerializeField] private Material material = null;
    [SerializeField] private Material[] materialsOption;

    public GameObject objectInstantiate = null;

    void Update()
    {
        if (dragElement.GetComponent<DragElement>().isDrag)
        {
            foreach (Material item in materialsOption)
            {
                if (item.name == dragElement.gameObject.name)
                {
                    material = item;
                }
            }
        }
    }
    public void EndDrag()
    {
        dragElement.transform.SetParent(dragElement.GetComponent<DragElement>().initialParent.transform, true);
        dragElement.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);

        if (dragElement.GetComponent<DragElement>().speed >= 1500 )
        {
            Vector3 imageVector = new Vector3(target.transform.position.x, target.transform.position.y + 2, target.transform.position.z - 5);
            objectInstantiate = Instantiate(image3D, imageVector, Quaternion.identity);
            objectInstantiate.GetComponent<MeshRenderer>().material = material;
            Color color = new Color(0, 0, 0, 0);
            dragElement.GetComponent<Image>().color = color;
            isDropToTarget = true;
        }
        else
        {
            dragElement.GetComponent<DragElement>().isDrag = false;
            dragElement.transform.position = dragElement.GetComponent<DragElement>().initialParent.transform.position;
            Color color = new Color(1, 1, 1, 1);
            dragElement.GetComponent<Image>().color = color;
        }
    }
    public void PanelOpacityAndScale()
    {
        if (dragElement.GetComponent<DragElement>().isDrag)
        {
            content.GetComponent<CanvasGroup>().alpha -= 0.7f * Time.deltaTime;
            content.GetComponent<Transform>().localScale -= new Vector3(0.08f, 0.03f, 0f) * Time.deltaTime;
        }
        else
        {
            content.GetComponent<CanvasGroup>().alpha = 1f;
            content.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
            dragElement.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
        }
    }
    public void Image3DTranlate() 
    {
        if (isDropToTarget && objectInstantiate != null)
        {
            objectInstantiate.transform.Translate(new Vector3(0, 0.2f, 1) * 2f * Time.deltaTime);
        }
    }
}
