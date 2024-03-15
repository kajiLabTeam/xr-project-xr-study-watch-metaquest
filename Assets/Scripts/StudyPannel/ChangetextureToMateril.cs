using UnityEngine;

public class ChangetextureToMateril : MonoBehaviour
{
    [SerializeField] Material _material;

    public void SetMaterial(Texture texture)
    {
        _material.SetTexture("lab", texture);
    }
}
