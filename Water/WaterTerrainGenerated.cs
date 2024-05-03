using System.Linq;
using Game;
using Engine.Serialization;
using System.Xml.Linq;
using Engine;
using System;
using Engine.Media;
using Random = Game.Random;
using Engine.Graphics;
using GameEntitySystem;
using System.Collections.Generic;
using System.Globalization;
using TemplatesDatabase;
using System.Reflection;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using XmlUtilities;
using Engine.Input;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class WaterTerrainGenerated : ModLoader
    {
        public Random m_random = new Random();

        public override void __ModInitialize()
        {
            ModsManager.RegisterHook("OnTerrainContentsGenerated", this);
        }

        public override void OnTerrainContentsGenerated(TerrainChunk chunk)
        {
            GenerateChunk(chunk, 3, 300, 418, 19);
        }

        public void GenerateChunk(TerrainChunk chunk, int min, int max, int index, int oldindex)
        {
            List<TerrainBrush> m_goldBrushes = new List<TerrainBrush>();
            int x = chunk.Coords.X;
            int y = chunk.Coords.Y;
            for (int l = 0; l < 16; l++)
            {
                TerrainBrush terrainBrush = new TerrainBrush();
                int num2 = m_random.Int(15, 16);
                for (int m = 0; m < num2; m++)
                {
                    Vector3 vector2 = 0.5f * Vector3.Normalize(new Vector3(m_random.Float(-1f, 1f), m_random.Float(-1f, 1f), m_random.Float(-1f, 1f)));
                    int num3 = m_random.Int(10, 15);
                    Vector3 zero2 = Vector3.Zero;
                    for (int n = 0; n < num3; n++)
                    {
                        terrainBrush.AddBox((int)MathUtils.Floor(zero2.X), (int)MathUtils.Floor(zero2.Y), (int)MathUtils.Floor(zero2.Z), 1, 1, 1, index);
                        zero2 += vector2;
                    }
                }
                terrainBrush.Compile();
                m_goldBrushes.Add(terrainBrush);
            }
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    int num = (int)(5f + 2f * SimplexNoise.OctavedNoise(i + 713, j + 211, 0.33f, 1, 1f, 1f));
                    for (int n = 0; n < num; n++)
                    {
                        int x1 = i * 16 + m_random.Int(0, 15);
                        int y1 = m_random.Int(min, max);
                        int z1 = j * 16 + m_random.Int(0, 15);
                        m_goldBrushes[m_random.Int(0, m_goldBrushes.Count - 1)].PaintFastSelective(chunk, x1, y1, z1, oldindex);
                    }
                }
            }
        }
    }
}