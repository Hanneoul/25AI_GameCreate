using UnityEngine;

public class SceneScroller : MonoBehaviour
{
    public float ScrollSpeed = 1.0f;
    Material myMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float newOffSetX = myMaterial.mainTextureOffset.x + (ScrollSpeed * Time.deltaTime);
        Debug.Log("x오프셋 : " + myMaterial.mainTextureOffset.x);

        Debug.Log("뉴오프셋 : " + newOffSetX);

        Vector2 newOffset = new Vector2(newOffSetX, 0);

        myMaterial.mainTextureOffset = newOffset;
    }
}



