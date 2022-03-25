using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Controller controller;
    [SerializeField] public GameObject dragElement = null;
    [SerializeField] private Animator character;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sticker")) 
        {
            character.SetBool("Hit", true);
            dragElement.GetComponent<DragElement>().isDrag = false;
            controller.EndDrag();
            Destroy(other.gameObject);
            StartCoroutine(EndAnimation());
        }
    }
    IEnumerator EndAnimation() 
    {
        yield return new WaitForSeconds(1.5f);
        character.SetBool("Hit", false);
        
    }

}
