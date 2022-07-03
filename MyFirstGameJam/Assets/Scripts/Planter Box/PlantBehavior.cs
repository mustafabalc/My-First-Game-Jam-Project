using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehavior : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray = new Sprite[4];
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(TimerCoroutine());
    }
   
   

    private IEnumerator TimerCoroutine()
    {
        Debug.Log("Coroutine Activated");
        

        for (int i = 0; i < spriteArray.Length; i++)
        {
            spriteRenderer.sprite = spriteArray[i];
            Debug.Log("It should have changed to sprite " + i);
            yield return new WaitForSeconds(2.5f);
        }
    }
}
