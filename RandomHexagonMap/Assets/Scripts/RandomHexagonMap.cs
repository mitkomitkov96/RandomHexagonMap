using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHexagonMap : MonoBehaviour
{
    [SerializeField]
    private int width, height;

    public GameObject hexagonPrefab;
    public Material[] hexagonMaterials;

    private float[] materialHeightRanges = { 0.5f, 0.6f, 0.85f, 1f };

    private Hexagon[,] hexagons;

    void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        hexagons = new Hexagon[width+1,height+1];
        float[,] perlinNoiseMap = PerlinNoise.GeneratePerlinNoiseMap(width, height, 4f, 4);

        for (int col = 0; col < width; col++)
        {
            for (int row = 0; row < height; row++)
            {
                float latitude = perlinNoiseMap[col,row];
                Hexagon h = new Hexagon(col, row);

                hexagons[col,row] = h;
                GameObject HexagonGameObject = Instantiate(hexagonPrefab, h.GetPosition(), Quaternion.identity, this.transform);
                MeshRenderer meshRenderer = HexagonGameObject.GetComponentInChildren<MeshRenderer>();

                for (int i = 0; i < materialHeightRanges.Length; i++)
                {
                    if (latitude <= materialHeightRanges[i]) {
                        meshRenderer.material = hexagonMaterials[i];
                        break;
                    }
                }
            }       
        }
    }

}
