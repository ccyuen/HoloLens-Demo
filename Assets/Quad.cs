using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;

public class Quad : MonoBehaviour
{
    public Transform prefab;

    void Start()
    {
        this.tapToPlace = this.GetComponent<TapToPlace>();
    }

    void OnPlaced(object sender, System.EventArgs e)
    {
        // We're done now.
        this.tapToPlace = null;

        var windowAndContent = Instantiate(prefab);
        windowAndContent.transform.parent = this.transform.parent;
        windowAndContent.transform.localPosition = this.transform.localPosition;
        windowAndContent.transform.forward = this.transform.forward;
        this.GetComponent<MeshRenderer>().enabled = false;
    }
    TapToPlace tapToPlace;
}
