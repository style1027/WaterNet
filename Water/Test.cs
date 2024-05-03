using System;
using Engine;
using Engine.Graphics;

namespace Game
{
	// Token: 0x02000002 RID: 2
	public class Test : Block
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002154 File Offset: 0x00000354
		public override void Initialize()
		{
			this.DefaultDisplayName = "满的饮用水瓶（测试）";
			this.DefaultDescription = "水瓶（测试）";
			this.DefaultCategory = "style的饮水";
			this.CraftingId = "test";
			this.FirstPersonScale = 0.4f;
			this.FirstPersonOffset = new Vector3(0.5f, -0.5f, -0.6f);
			this.InHandScale = 0.3f;
			this.IsPlaceable = false;
			this.MaxStacking = 1;
			base.Initialize();
			this.m_texture = ContentManager.Get<Texture2D>("Textures/FullWater", null);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
		public override void GenerateTerrainVertices(BlockGeometryGenerator generator, TerrainGeometry geometry, int value, int x, int y, int z)
		{
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000021E4 File Offset: 0x000003E4
		public override int GetTextureSlotCount(int value)
		{
			return 1;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021F8 File Offset: 0x000003F8
		public override int GetFaceTextureSlot(int face, int value)
		{
			return 0;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002053 File Offset: 0x00000253
		public override void DrawBlock(PrimitivesRenderer3D primitivesRenderer, int value, Color color, float size, ref Matrix matrix, DrawBlockEnvironmentData environmentData)
		{
			BlocksManager.DrawFlatBlock(primitivesRenderer, value, size * 0.5f, ref matrix, this.m_texture, Color.White, true, environmentData);
		}

		// Token: 0x04000001 RID: 1
		public const int Index = 416;

		// Token: 0x04000002 RID: 2
		public Texture2D m_texture;
	}
}
