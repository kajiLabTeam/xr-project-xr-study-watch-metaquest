using UnityEngine;

public class LabImageInsertTexture : MonoBehaviour
{
    public void SetMaterial(Texture texture)
    {
        var material = this.GetComponent<Renderer>().material;
        material.mainTexture = texture;
    }
}
