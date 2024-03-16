using UnityEngine;

public class ChangetextureToMateril : MonoBehaviour
{
    public void SetMaterial(Texture texture)
    {
        var material = this.GetComponent<Renderer>().material;
        material.mainTexture = texture;
    }
}
