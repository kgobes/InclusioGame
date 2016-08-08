using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Maze : MonoBehaviour {
	//public int sizeX;
	//public int sizeZ;
	public MazeCell cellPrefab;
	private MazeCell[,] cells;
	public EventTrigger eventPrefab;
	public int eventCounter = 8;
	[Range(0f, 1f)]
	public float eventProbability; //how many events do you want?

	public EndGame endPrefab;

	//edges
	public MazePassage passagePrefab;
	public MazeWall wallPrefab;

	public float generationStepDelay;
	public static IntVector2 size = new IntVector2 (5, 5);
    public ChallengeManager challengeManagerInst;

    public float mazeMeshScale = 2;

    private List<MazeWall> walls;

    public GameObject[] wallPiecesDoubleOpen;
    public GameObject[] wallPiecesDoublePerp;
    public GameObject[] wallPiecesDoublePar;
    public GameObject[] wallPiecesParPerp;
    public GameObject[] wallPiecesPerpPar;
    public GameObject[] wallPiecesOpenPar;
    public GameObject[] wallPiecesParOpen;
    public GameObject[] wallPiecesOpenPerp;
    public GameObject[] wallPiecesPerpOpen;

    enum WallNeighbor
    {
        None = 0,
        Parallel = 1,
        Perpendicular = 2
    };

	// Use this for initialization
	void Start ()
    {
        walls = new List<MazeWall>();
		//size = new IntVector2 (5, 5);

        challengeManagerInst = GameObject.Find("Challenge Manager").GetComponent<ChallengeManager>();

        if (!challengeManagerInst)
            Debug.LogError("Challenge Manager object not found in scene! Unable to store reference");
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
        GenerateWallPieces();
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
        newCell.transform.localPosition = new Vector3((coordinates.x - size.x * 0.5f + 0.5f) * mazeMeshScale, 0f, (coordinates.z - size.z * 0.5f + 0.5f) * mazeMeshScale);
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
		if (Random.value < eventProbability && eventCounter >0) {
		//if(eventCounter > 0){
			eventCounter--;
			prefab = eventPrefab;
			MazePassage chal = Instantiate (prefab) as EventTrigger;
			chal.Initialize (cell, otherCell, direction);
            chal.GetComponent<EventTrigger>().SetChallengeManagerRef(challengeManagerInst);
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
        walls.Add(wall);
	}

	public void createEndLoc(){
		IntVector2 endSpot = new IntVector2 (size.x-1, size.z-1); //creates in top right corner
		CreateCell (endSpot, true);
	}

    private void GenerateWallPieces()
    {
        for (int i = 0; i < walls.Count; ++i)
        {
            walls[i].transform.GetChild(0).GetComponent<Collider>().enabled = false;

            RaycastHit _hit;
            Color _raycastColor = Color.red;
            WallNeighbor _right = WallNeighbor.None;
            WallNeighbor _left = WallNeighbor.None;

            if (Physics.Raycast(walls[i].transform.GetChild(0).position, walls[i].transform.GetChild(0).right, out _hit, mazeMeshScale))
            {
                if (_hit.transform.parent.transform.rotation == walls[i].transform.rotation)
                {
                    _raycastColor = Color.green;
                    _right = WallNeighbor.Parallel;
                }
                else
                {
                    _raycastColor = Color.yellow;
                    _right = WallNeighbor.Perpendicular;
                }
            }
            //Debug.DrawLine(walls[i].transform.GetChild(0).position, walls[i].transform.GetChild(0).position + (walls[i].transform.GetChild(0).right * mazeMeshScale), _raycastColor, 60f, false);

            if (Physics.Raycast(walls[i].transform.GetChild(0).position, -walls[i].transform.GetChild(0).right, out _hit, mazeMeshScale))
            {
                if (_hit.transform.parent.transform.rotation == walls[i].transform.rotation)
                {
                    _left = WallNeighbor.Parallel;
                }
                else
                {
                    _left = WallNeighbor.Perpendicular;
                }
            }
            
            walls[i].transform.GetChild(0).GetComponent<Collider>().enabled = true;

            Text _text = walls[i].GetComponentInChildren<Text>();

            GameObject _wallPiece;

            switch(_right)
            {
                case WallNeighbor.None:
                    {
                        switch (_left)
                        {
                            case WallNeighbor.None:
                                {
                                    _text.text = "No Neighbors";
                                    _wallPiece = Instantiate(wallPiecesDoubleOpen[0]) as GameObject;
                                    _wallPiece.transform.SetParent(walls[i].transform, false);
                                    _wallPiece.transform.localPosition = new Vector3(-2, 0, 2);
                                    _wallPiece.transform.localRotation = Quaternion.identity;
                                    break;
                                }
                            case WallNeighbor.Parallel:
                                {
                                    _text.text = "< Parallel";
                                    _wallPiece = Instantiate(wallPiecesParOpen[0]) as GameObject;
                                    _wallPiece.transform.SetParent(walls[i].transform, false);
                                    _wallPiece.transform.localPosition = new Vector3(-2, 0, 2);
                                    _wallPiece.transform.localRotation = Quaternion.identity;
                                    break;
                                }
                            case WallNeighbor.Perpendicular:
                                {
                                    _text.text = "< Perpendicular";
                                    _wallPiece = Instantiate(wallPiecesPerpOpen[0]) as GameObject;
                                    _wallPiece.transform.SetParent(walls[i].transform, false);
                                    _wallPiece.transform.localPosition = new Vector3(-2, 0, 2);
                                    _wallPiece.transform.localRotation = Quaternion.identity;
                                    break;
                                }
                        }
                        break;
                    }

                case WallNeighbor.Parallel:
                    {
                        switch (_left)
                        {
                            case WallNeighbor.None:
                                {
                                    _text.text = "Parallel >";
                                    _wallPiece = Instantiate(wallPiecesOpenPar[0]) as GameObject;
                                    _wallPiece.transform.SetParent(walls[i].transform, false);
                                    _wallPiece.transform.localPosition = new Vector3(-2, 0, 2);
                                    _wallPiece.transform.localRotation = Quaternion.identity;
                                    break;
                                }
                            case WallNeighbor.Parallel:
                                {
                                    _text.text = " < Parallel >";
                                    _wallPiece = Instantiate(wallPiecesDoublePar[0]) as GameObject;
                                    _wallPiece.transform.SetParent(walls[i].transform, false);
                                    _wallPiece.transform.localPosition = new Vector3(-2, 0, 2);
                                    _wallPiece.transform.localRotation = Quaternion.identity;
                                    break;
                                }
                            case WallNeighbor.Perpendicular:
                                {
                                    _text.text = "< Perp - Par >";
                                    _wallPiece = Instantiate(wallPiecesPerpPar[0]) as GameObject;
                                    _wallPiece.transform.SetParent(walls[i].transform, false);
                                    _wallPiece.transform.localPosition = new Vector3(-2, 0, 2);
                                    _wallPiece.transform.localRotation = Quaternion.identity;
                                    break;
                                }
                        }
                        break;
                    }

                case WallNeighbor.Perpendicular:
                    {
                        switch (_left)
                        {
                            case WallNeighbor.None:
                                {
                                    _text.text = "Perpendicular >";
                                    _wallPiece = Instantiate(wallPiecesOpenPerp[0]) as GameObject;
                                    _wallPiece.transform.SetParent(walls[i].transform, false);
                                    _wallPiece.transform.localPosition = new Vector3(-2, 0, 2);
                                    _wallPiece.transform.localRotation = Quaternion.identity;
                                    break;
                                }
                            case WallNeighbor.Parallel:
                                {
                                    _text.text = "< Par - Perp >";
                                    _wallPiece = Instantiate(wallPiecesParPerp[0]) as GameObject;
                                    _wallPiece.transform.SetParent(walls[i].transform, false);
                                    _wallPiece.transform.localPosition = new Vector3(-2, 0, 2);
                                    _wallPiece.transform.localRotation = Quaternion.identity;
                                    break;
                                }
                            case WallNeighbor.Perpendicular:
                                {
                                    _text.text = "< Perpendicular >";
                                    _wallPiece = Instantiate(wallPiecesDoublePerp[0]) as GameObject;
                                    _wallPiece.transform.SetParent(walls[i].transform, false);
                                    _wallPiece.transform.localPosition = new Vector3(-2, 0, 2);
                                    _wallPiece.transform.localRotation = Quaternion.identity;
                                    break;
                                }
                        }
                        break;
                    }
            }

            
        }
    }
}