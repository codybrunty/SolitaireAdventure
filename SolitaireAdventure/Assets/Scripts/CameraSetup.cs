using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public GameObject targetBoundsGO;
    public float padding;
    public Bounds targetBounds;

    private void Start() {
        SetupCamera();
    }

    void SetupCamera() {
        targetBounds = GetBoundingBox(targetBoundsGO);

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = targetBounds.size.x / targetBounds.size.y;

        if (screenRatio >= targetRatio) {
            Camera.main.orthographicSize = targetBounds.size.y / 2;
        }
        else {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = targetBounds.size.y / 2 * differenceInSize;
        }

        transform.position = new Vector3(targetBounds.center.x, targetBounds.center.y, -1f);

    }

    Bounds GetBoundingBox(GameObject objeto) {
        Bounds bounds;
        Renderer childRender;
        bounds = GetRenderBounds(objeto);
        if (bounds.extents.x == 0) {
            bounds = new Bounds(objeto.transform.position, Vector3.zero);
            foreach (Transform child in objeto.transform) {
                childRender = child.GetComponent<Renderer>();
                if (childRender) {
                    bounds.Encapsulate(childRender.bounds);
                }
                else {
                    bounds.Encapsulate(GetBoundingBox(child.gameObject));
                }
            }
        }

        return bounds;
    }

    Bounds GetRenderBounds(GameObject objeto) {
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        Renderer render = objeto.GetComponent<Renderer>();
        if (render != null) {
            return render.bounds;
        }
        return bounds;
    }
}