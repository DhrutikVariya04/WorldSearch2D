using UnityEngine;

public class Selecting : MonoBehaviour
{
    private bool isDrawing = false;

    [SerializeField]
    LineRenderer LineRenderer;

    void Start()
    {
        LineRenderer = GetComponent<LineRenderer>();
        LineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                LineRenderer.SetPosition(0, hit.transform.position);
            }
        }

        if (isDrawing)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            LineRenderer.SetPosition(1, mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                print("MouseUP");
                LineRenderer.SetPosition(1, hit.transform.position);
            }
            else
            {
                //LineRenderer
            }
        }
    }
}
