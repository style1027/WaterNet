using System;
using Engine;
using Engine.Graphics;
using Engine.Input;
using Engine.Media;
using GameEntitySystem;
using TemplatesDatabase;
namespace Game
{
    public class WaterPlantBlock
    {
        public class StrawberryBlock : Block
        {
            public Texture2D m_texture;
            public override void Initialize()
            {
                DefaultDisplayName = "草莓";
                DefaultDescription = "草莓";
                DefaultCategory = "style的饮水";
                CraftingId = "StrawberryBlock";
                FirstPersonScale = 0.4f;
                DefaultNutritionalValue = 1f;
                FirstPersonOffset = new Vector3(0.5f, -0.5f, -0.6f);
                InHandScale = 0.3f;
                IsPlaceable = false;
                base.Initialize();
                m_texture = ContentManager.Get<Texture2D>("Textures/Plant/StrawberryBlock");
            }
            public const int Index = 417;
            public override void GenerateTerrainVertices(BlockGeometryGenerator generator, TerrainGeometry geometry, int value, int x, int y, int z)
            {
                generator.GenerateCrossfaceVertices(this, value, x, y, z, BlockColorsMap.GrassColorsMap.Lookup(generator.Terrain, x, y, z), GetFaceTextureSlot(0, value), geometry.SubsetAlphaTest);
            }
            public override int GetTextureSlotCount(int value)
            {
                return 1;
            }
            public override int GetFaceTextureSlot(int face, int value)
            {
                return 0;
            }
                            
            public override void DrawBlock(PrimitivesRenderer3D primitivesRenderer, int value, Color color, float size, ref Matrix matrix, DrawBlockEnvironmentData environmentData)
            {
                BlocksManager.DrawFlatBlock(primitivesRenderer, value, size * 0.5f, ref matrix, m_texture, Color.White, isEmissive: true, environmentData);
            }
        }
        public class StrawberryCongBlock : CrossBlock
        {
            public override void Initialize()
            {
                DefaultDisplayName = "草莓丛";
                DefaultDescription = "草莓丛";
                DefaultCategory = "style的饮水";
                CraftingId = "StrawberryCongBlock";
                FirstPersonScale = 0.4f;
                DigMethod = BlockDigMethod.Hack;
                DigResilience = 0.01f;
                DefaultDropContent = 417;
                DefaultTextureSlot = 251;
                DefaultDropCount = 1.5f;
                IsGatherable = true;
                RequiredToolLevel = 0;
                FirstPersonOffset = new Vector3(0.5f, -0.5f, -0.6f);
                InHandScale = 0.3f;
                IsTransparent = true;
                base.Initialize();
            }
            public const int Index = 418;
        }
    }
}