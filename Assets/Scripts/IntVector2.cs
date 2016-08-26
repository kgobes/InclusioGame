/*"It would be convenient if we could manipulate the coordinates as a single value, like Vector2 but with ints instead of floats. Unfortunately such a structure does not exist, but we can create one ourselves.
Let's add a new IntVector2 script and make it a struct instead of a class. We give it a public x and z integer. That gives us two integers bundled together as a single value. 
We'll also add a special constructor method to it, which allows us to define values via new IntVector2(1, 2).*/

[System.Serializable]
public struct IntVector2 {
	
	public int x, z;
	
	public IntVector2 (int x, int z) {
		this.x = x;
		this.z = z;
	}
	public static IntVector2 operator + (IntVector2 a, IntVector2 b) {
		a.x += b.x;
		a.z += b.z;
		return a;
	}

}