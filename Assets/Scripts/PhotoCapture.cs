using UnityEngine;

public class PhotoCapture : MonoBehaviour
{
    public Camera arCamera;
    public RenderTexture renderTexture;

    public void CapturePhoto()
    {
        arCamera.targetTexture = renderTexture;
        arCamera.Render();

        RenderTexture.active = renderTexture;

        Texture2D photo = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        photo.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        photo.Apply();

        arCamera.targetTexture = null;
        RenderTexture.active = null;

        NativeGallery.SaveImageToGallery(photo, "FaceFilterApp", "CapturedPhoto_{0}.png");


        Destroy(photo);
    }
}
