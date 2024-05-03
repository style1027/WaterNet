using System;
using Engine;
using Engine.Graphics;

namespace Game
{
	public class Empty : Block
	{
		public override void Initialize()
		{
			this.DefaultDisplayName = "空的水瓶（测试）";
			this.DefaultDescription = "水瓶（测试）";
			this.DefaultCategory = "style的饮水";
			this.CraftingId = "empty";
			this.FirstPersonScale = 0.4f;
			this.FirstPersonOffset = new Vector3(0.5f, -0.5f, -0.6f);
			this.InHandScale = 0.3f;
			this.IsPlaceable = false;
			this.MaxStacking = 1;
			base.Initialize();
			this.m_texture = ContentManager.Get<Texture2D>("Textures/Empty", null);
		}

		public override void GenerateTerrainVertices(BlockGeometryGenerator generator, TerrainGeometry geometry, int value, int x, int y, int z)
		{
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
			BlocksManager.DrawFlatBlock(primitivesRenderer, value, size * 0.5f, ref matrix, this.m_texture, Color.White, true, environmentData);
		}

		public const int Index = 414;

		public Texture2D m_texture;
	}
}
