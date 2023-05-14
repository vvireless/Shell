using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Tilemap tilemap;

    private float offsetX = 0f;
    private float offsetY = 0f;

    void Update()
    {
        Vector3 targetPos = target.position;

        targetPos.x += offsetX;
        targetPos.y += offsetY;
        targetPos.z = transform.position.z;

        // tilemap bounds
        Vector3Int minCell = tilemap.cellBounds.min;
        Vector3Int maxCell = tilemap.cellBounds.max;

        // Convert the cell coordinates to world coordinates
        Vector3 minWorld = tilemap.CellToWorld(minCell);
        Vector3 maxWorld = tilemap.CellToWorld(maxCell);

        // Clamp the camera's position to stay within the tilemap bounds
        float cameraHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        float cameraHalfHeight = Camera.main.orthographicSize;

        float minX = minWorld.x + cameraHalfWidth;
        float maxX = maxWorld.x - cameraHalfWidth;
        float minY = minWorld.y + cameraHalfHeight;
        float maxY = maxWorld.y - cameraHalfHeight;

        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        // Update the camera's position
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5f);
    }
}
