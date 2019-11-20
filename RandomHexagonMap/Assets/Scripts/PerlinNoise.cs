using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PerlinNoise
{
    
    public static float[,] GeneratePerlinNoiseMap(int width, int height, float scale, int octaves)
    {
        float[,] perlinNoiseMap = new float[width,height];

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float amplitude = 1f;
                float frequency = 1f;
                float noiseHeight = 0f;

                
                for (int i = 1; i < octaves; i++)
                {

                    noiseHeight += Mathf.PerlinNoise(x / scale * frequency, y / scale * frequency) * amplitude;

                    amplitude *= 0.3f;
                    frequency *= 1.8f;
                }
                perlinNoiseMap[x, y] = Mathf.Clamp01(noiseHeight);
            }
        }

        return perlinNoiseMap;
    }

}
