using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{

    [SerializeField]
    private Color flashColor;

    [SerializeField]
    private float duration;

    private SpriteRenderer sprite;
    private Color thisColor;
    private Coroutine flashRoutine;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        thisColor = sprite.color;
    }

    public void Flash()
    {
        if(flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        sprite.color = flashColor;
        yield return new WaitForSeconds(duration);
        sprite.color = thisColor;
        flashRoutine = null;
    }
}
