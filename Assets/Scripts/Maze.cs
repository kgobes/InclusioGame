using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Maze : MonoBehaviour {
	//public int sizeX;
	//public int sizeZ;
	public MazeCell cellPrefab;
	private MazeCell[,] cells;
	public ChallengeManager eventPrefab;
	[Range(0f, 1f)]
	public float doorProbability; //how many intersections do you want?

	public EndGame endPrefab;

	//edges
	public MazePassage passagePrefab;
	public MazeWall wallPrefab;

	public float generationStepDelay;
	public static IntVector2 size = new IntVector2 (5, 5);
	// Use this for initialization
	void Start () {
		//size = new IntVector2 (5, 5);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//CREATE CELLS
	public IEnumerator Generate () {
		WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
		cells = new MazeCell[size.x, size.z];
		List<MazeCell> activeCells = new List<MazeCell>();
		DoFirstGenerationStep(activeCells);
		while (activeCells.Count > 0) {
			yield return delay;
			DoNextGenerationStep(activeCells);
		}
		createEndLoc ();
	}
	
	private MazeCell CreateCell (IntVector2 coordinates, bool end) {
		MazeCell newCell;
		if (end) {
			newCell = Instantiate (endPrefab) as EndGame;
			newCell.name = "Maze End";
		} else {
			newCell = Instantiate (cellPrefab) as MazeCell;
			newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
		}
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;

		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
		return newCell;
	}

	private void DoFirstGenerationStep (List<MazeCell> activeCells) {
		activeCells.Add(CreateCell(RandomCoordinates, false));
	}
	//if the cell already exists, backtrack and create another one
	private void DoNextGenerationStep (List<MazeCell> activeCells) {
		int currentIndex = activeCells.Count - 1;
		MazeCell currentCell = activeCells[currentIndex];
		if (currentCell.IsFullyInitialized) {
			activeCells.RemoveAt(currentIndex);
			return;
		}

		MazeDirection direction = currentCell.RandomUninitializedDirection;
		IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();
		if (ContainsCoordinates(coordinates) && GetCell(coordinates) == null) {
			MazeCell neighbor = GetCell(coordinates);
			if (neighbor == null) {
				neighbor = CreateCell(coordinates, false);
				CreatePassage(currentCell, neighbor, direction);
				activeCells.Add(neighbor);
			}
			else {
				CreateWall(currentCell, null, direction);
			}
		}
		else {
			CreateWall(currentCell, null, direction);
		}
	}

	//get cell coordinates
	public MazeCell GetCell (IntVector2 coordinates) {
		return cells[coordinates.x, coordinates.z];
	}

	public IntVector2 RandomCoordinates {
		get {
			return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
		}
	}
	
	public bool ContainsCoordinates (IntVector2 coordinate) {
		return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
	}


	private void CreatePassage (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazePassage prefab;
		if (Random.value < doorProbability) {
			prefab = eventPrefab;
			MazePassage chal = Instantiate (prefab) as ChallengeManager;
			chal.Initialize (cell, otherCell, direction);
			prefab = passagePrefab;
			chal = Instantiate (prefab) as MazePassage;
			chal.Initialize (otherCell, cell, direction.GetOpposite ());
		}
		else {
			prefab = passagePrefab;
			//MazePassage prefab = Random.value < doorProbability ? doorPrefab : passagePrefab;
			MazePassage passage = Instantiate (prefab) as MazePassage;
			passage.Initialize (cell, otherCell, direction);
			passage = Instantiate (prefab) as MazePassage;
			passage.Initialize (otherCell, cell, direction.GetOpposite ());
		}
	}
	
	private void CreateWall (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazeWall wall = Instantiate(wallPrefab) as MazeWall;
		wall.Initialize(cell, otherCell, direction);
		if (otherCell != null) {
			wall = Instantiate(wallPrefab) as MazeWall;
			wall.Initialize(otherCell, cell, direction.GetOpposite());
		}
	}

	public void createEndLoc(){
		IntVector2 endSpot = new IntVector2 (size.x-1, size.z-1); //creates in top right corner
		CreateCell (endSpot, true);
	}
}
