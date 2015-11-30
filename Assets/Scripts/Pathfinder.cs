using UnityEngine;
using System.Collections.Generic;
using System.Collections;



public class Pathfinder : MonoBehaviour {

    Tile[,] mapTile;
    Vector2 tileSize;
    public int width=1, height=1;

    // Use this for initialization
    void Start () {
        //generateGrid(width, height);
	}
	
    public void generateGrid() {
        tileSize = new Vector2(gameObject.GetComponent<BoxCollider2D>().size.x / width, gameObject.GetComponent<BoxCollider2D>().size.y / height);
        tileSize.Scale(transform.localScale);
        mapTile = new Tile[width, height];
		for(int x=0; x<width; x++){
			for(int y=0; y<height; y++){
				Tile tile = new Tile();
				mapTile[x,y] = tile;
				tile.passable = true;
                tile.x = x;
                tile.y = y;
                tile.cost = -1;
                Vector2 pos = GetPositionFromTile(tile);
                Collider2D[] colliders = Physics2D.OverlapAreaAll(pos - tileSize / 2, pos + tileSize / 2);
				foreach(Collider2D collider in colliders){
					if(collider.tag == "Obstacle"){
						tile.passable = false;
						break;
					}
				}
			}
		}
		foreach(Tile tile in mapTile){
			for(int x = -1; x<=1; x++){
				for(int y = -1; y<=1; y++){
					if(!(x == 0 && y == 0)){
						if(tile.x+x>=0 && tile.x+x<width && tile.y+y>=0 && tile.y+y<height){
							if(mapTile[tile.x+x, tile.y+y].passable){
								tile.neighbors.Add(mapTile[tile.x+x, tile.y+y]);
							}
						}
					}
				}
			}
		}
    }

    Vector2 GetPositionFromTile(int x, int y) {
        return new Vector2(
            tileSize.x * (x - width / 2.0f + 0.5f) + transform.position.x,
            tileSize.y * (y - height / 2.0f + 0.5f) + transform.position.y);
    }

    Vector2 GetPositionFromTile(Tile tile) {
        return GetPositionFromTile(tile.x, tile.y);
    }

	public Tile GetTileFromPosition(Vector2 position){
        int x, y;
        x = (int)((position.x - transform.position.x) / tileSize.x + (width / 2.0f));
        y = (int)((position.y - transform.position.y) / tileSize.y + (height / 2.0f));
        print((position.x - transform.position.x)/tileSize.x);
        print ("("+x + ", " + y + "): "+mapTile[x, y]);
		return mapTile [x, y];
	}

	public Vector2[] FindPath(Tile startTile, Tile endTile){
		
		for(int x=0; x<width; x++){
			for(int y=0; y<height; y++){
				mapTile[x,y].cost = -1;
			}
		}
		startTile.cost = 0;
		
		
		Queue<Tile> frontier = new Queue<Tile>();
		frontier.Enqueue(startTile);
		Dictionary<Tile, Tile> cameFrom = new Dictionary<Tile, Tile>();
		cameFrom.Add(startTile, null);
		
		while(frontier.Count>0){
			Tile current = frontier.Dequeue();
			if(current == endTile) break;
			foreach(Tile next in current.GetNeighbors()){
				int cost = current.cost + next.moveCost * (1 + Mathf.Abs(next.x-current.x)+Mathf.Abs(next.y-current.y));
				if(next.cost == -1 || cost < next.cost){
					next.cost = cost;
					frontier.Enqueue(next);
					cameFrom[next] = current;
				}
			}
		}

		if(cameFrom.ContainsKey(endTile)){
			List<Vector2> path = new List<Vector2>();
			Tile current = endTile;
			while(current != null){
				path.Add(GetPositionFromTile(current));
				current = cameFrom[current];
			}
			path.Reverse();
			return path.ToArray();
		} else return null;
	}

    public void OnDrawGizmos() {
        tileSize = new Vector2(gameObject.GetComponent<BoxCollider2D>().size.x / width, gameObject.GetComponent<BoxCollider2D>().size.y / height);
        tileSize.Scale(transform.localScale);
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Vector2 pos = GetPositionFromTile(x, y);
                Collider2D[] colliders = Physics2D.OverlapAreaAll(pos - tileSize / 2, pos + tileSize / 2);
                bool passable = true;
                foreach (Collider2D collider in colliders) {
                    if (collider.tag == "Obstacle") {
                        passable = false;
                        break;
                    }
                }
                if(passable)
                    Gizmos.DrawWireCube(pos, new Vector3(tileSize.x, tileSize.y, 0.0f));
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
