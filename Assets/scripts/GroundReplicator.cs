using UnityEngine;
using System.Collections;

public class GroundReplicator : MonoBehaviour {
	public GameObject prefab;

	void Start() {
		//Gets object boundaries
		SpriteRenderer objectSprite = GetComponent<SpriteRenderer>();
		float boundsX = objectSprite.bounds.extents.x;
		float boundsY = objectSprite.bounds.extents.y;

		//Gets tile boundaries
		SpriteRenderer tileSprite = prefab.GetComponent<SpriteRenderer>();
		float tileBoundsX = tileSprite.bounds.extents.x;
		float tileBoundsY = tileSprite.bounds.extents.y - 0.087f; //Adjustment

		float x = objectSprite.bounds.center.x;
		float y = -boundsY + tileBoundsY;
		float xEnd = boundsX;
		float yEnd = boundsY;
		float offsetX = tileBoundsX;
		float offsetY = tileBoundsY * 2;
		int i = 2;
		GameObject tile;
		//Loop through and create repeated tiles
		while(x <= xEnd) {
			while (y <= yEnd) {
				tile = Instantiate (prefab) as GameObject;
				tile.transform.position = new Vector3 (x, y, 0.0f);
				y += offsetY;
			}
			x += offsetX;
			y = -boundsY + (i * tileBoundsY);
			yEnd = boundsY - (i * tileBoundsY);
			i++;
		}

		x = objectSprite.bounds.center.x - tileBoundsX;
		y = -boundsY + (tileBoundsY * 2);
		xEnd = -boundsX;
		yEnd = boundsY - tileBoundsY;
		i = 2;

		while(x >= xEnd) {
			while (y <= yEnd) {
				tile = Instantiate (prefab) as GameObject;
				tile.transform.position = new Vector3 (x, y, 0.0f);
				y += offsetY;
			}
			x -= offsetX;
			y = -boundsY + tileBoundsY + (i * tileBoundsY);
			yEnd = boundsY - (i * tileBoundsY);
			i++;
		}

		//Disables object sprite
		objectSprite.enabled = false;
	}
}