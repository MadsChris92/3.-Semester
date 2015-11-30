using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {
	public Transform start, goal;
	public Pathfinder pather;
	public GameObject marker;
	Transform[] points;

	// Use this for initialization
	void Start () {
		pather.generateGrid ();
		Tile startTile = pather.GetTileFromPosition (start.position);
		Tile goalTile = pather.GetTileFromPosition (goal.position);
		Vector2[] path = pather.FindPath (startTile, goalTile);
		for(int i=1;i<path.Length;i++) {
			GameObject mark = Instantiate(marker);
			mark.transform.position = path[i];
			mark.GetComponent<LineRenderer>().SetPosition(0, path[i-1]-path[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
