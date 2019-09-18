using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.5f;
    private Material myMaterial;
    private Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        // Scrolling up on Y axis
        offSet = new Vector2(0.0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Frame rate independent moving speed
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
