using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AgentPCG : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;
    [SerializeField]
    private TileBase floorTile;
    [SerializeField]
    private float pChangeDir = 0;
    [SerializeField]
    private float pChangeDirIncr = 5;
    [SerializeField]
    private float pBuildRoom = 100;
    [SerializeField]
    private float pBuildRoomIncr = 5;
    [SerializeField]
    private Vector2Int startPos = Vector2Int.zero;
    [SerializeField]
    private int steps = 500;

    private List<Vector2Int> directions = new List<Vector2Int>{Vector2Int.up, Vector2Int.down, Vector2Int.right, Vector2Int.left};

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Generate() {
        var currentPos = startPos;
        var currentDir = RandomDir();
        for (var i = 0; i < steps; i++) {
            print("Schleife");
            CreateTile(currentPos);
            currentPos = currentPos + currentDir;
            if (Random.value * 100 < pChangeDir) {
                currentDir = RandomDir();
                pChangeDir = 0;
                print("ChangedDirection");
            } else {
                pChangeDir += pChangeDirIncr;
            }
        }
    }

    private Vector2Int RandomDir() {
        return directions[(Random.Range(0, 4))];

    }

    private void CreateTile(Vector2Int pos) {
//        var tilePos = map.WorldToCell((Vector3Int) pos);

        map.SetTile((Vector3Int) pos, floorTile);
    }
}
