using UnityEngine;
using UnityEngine.UI;

public class ParallaxUp : MonoBehaviour
{
    private Image _image;
    private float scrollSpeed = 0.5f;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        var offset = Time.time * scrollSpeed;
        _image.material.SetTextureOffset("_MainTex", new Vector2(offset, offset));
    }
}
