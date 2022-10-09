using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambAppearance : MonoBehaviour
{
    private Vector2 startPosition = new Vector2(16.267f, -4.941309f);
    private Vector2 endPosition = new Vector2(14.90f, -4.941309f); //Vector2.zero; 
    private float showDuration = 0.5f;
    private float duration = 1f;

    private IEnumerator ShowHide(Vector2 end, Vector2 start)
    {
        transform.localPosition = start;

        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);

            elapsed += Time.deltaTime;
            yield return null;
        }


        transform.localPosition = end;


        yield return new WaitForSeconds(duration);


        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = start;

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowHide(startPosition, endPosition)); 
    }

 
}
