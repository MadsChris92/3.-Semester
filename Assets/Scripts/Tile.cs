using UnityEngine;
using System.Collections.Generic;

public class Tile {
    public bool passable;
	public int moveCost = 1;
    public int cost;
	public int x,y;
	public List<Tile> neighbors;

	public Tile(){
		neighbors = new List<Tile> ();
	}

	public Tile[] GetNeighbors(){
		return neighbors.ToArray ();
	}
}
