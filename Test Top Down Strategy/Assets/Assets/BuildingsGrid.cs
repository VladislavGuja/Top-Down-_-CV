using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    public Resurs resurs;
    public House house;
    public Vector2Int GridSize = new Vector2Int(10, 10);

    private Building[,] grid;
    private Building flyingBuilding;
    private Camera mainCamera;
    
    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];
        
        mainCamera = Camera.main;
        resurs = GameObject.FindGameObjectWithTag("Resurs").GetComponent<Resurs>();
       
    }

    public void StartPlacingBuilding1(Building buildingPrefab)
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }
        
        flyingBuilding = Instantiate(buildingPrefab);
        if(resurs.WoodResurs < 5)
        {
            Debug.Log("NoMoney");
        }
        else
        {
            resurs.WoodResurs -= 5;
        }
    }
    public void StartPlacingBuilding2(Building buildingPrefab)
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }

        flyingBuilding = Instantiate(buildingPrefab);
        if(resurs.WoodResurs < 10)
        {
            Debug.Log("NoMoney");
        }
        else
        {
            resurs.WoodResurs -= 10;
        }
    }
    public void StartPlacingBuilding3(Building buildingPrefab)
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }

        flyingBuilding = Instantiate(buildingPrefab);
        if (resurs.IronResurs < 7)
        {
            Debug.Log("NoMoney");
        }
        else
        {
            resurs.IronResurs -= 7;
        }
    }
    public void StartPlacingBuilding4(Building buildingPrefab)
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }

        flyingBuilding = Instantiate(buildingPrefab);
        if (resurs.GoldResurs < 10)
        {
            Debug.Log("NoMoney");
        }
        else
        {
            resurs.GoldResurs -= 10;
        }
    }
    private void Update()
    {
        if (flyingBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                bool available = true;

                if (x < 0 || x > GridSize.x - flyingBuilding.Size.x) available = false;
                if (y < 0 || y > GridSize.y - flyingBuilding.Size.y) available = false;

                if (available && IsPlaceTaken(x, y)) available = false;

                flyingBuilding.transform.position = new Vector3(x, 0, y);
                flyingBuilding.SetTransparent(available);

                if (available && Input.GetMouseButtonDown(0))
                {
                    PlaceFlyingBuilding(x, y);
                   
                }
            }
        }
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }

        return false;
    }

    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                grid[placeX + x, placeY + y] = flyingBuilding;
            }
        }
        
        flyingBuilding.SetNormal();
        flyingBuilding = null;
    }
}
