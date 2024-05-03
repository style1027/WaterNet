using System;
using Engine;
using Engine.Graphics;

namespace Game
{
	// Token: 0x02000004 RID: 4
	public class Test2 : Block
	{
		// Token: 0x0600000D RID: 13 RVA: 0x0000229C File Offset: 0x0000049C
		public override void Initialize()
		{
			this.DefaultDisplayName = "满的海水瓶水瓶（测试）";
			this.DefaultDescription = "水瓶（测试）";
			this.DefaultCategory = "style的饮水";
			this.CraftingId = "test2";
			this.FirstPersonScale = 0.4f;
			this.FirstPersonOffset = new Vector3(0.5f, -0.5f, -0.6f);
			this.InHandScale = 0.3f;
			this.IsPlaceable = false;
			this.MaxStacking = 1;
			base.Initialize();
			this.m_texture = ContentManager.Get<Texture2D>("Textures/FullSeaWater", null);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002050 File Offset: 0x00000250
		public override void GenerateTerrainVertices(BlockGeometryGenerator generator, TerrainGeometry geometry, int value, int x, int y, int z)
		{
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021E4 File Offset: 0x000003E4
		public override int GetTextureSlotCount(int value)
		{
			return 1;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000021F8 File Offset: 0x000003F8
		public override int GetFaceTextureSlot(int face, int value)
		{
			return 0;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000020A2 File Offset: 0x000002A2
		public override void DrawBlock(PrimitivesRenderer3D primitivesRenderer, int value, Color color, float size, ref Matrix matrix, DrawBlockEnvironmentData environmentData)
		{
			BlocksManager.DrawFlatBlock(primitivesRenderer, value, size * 0.5f, ref matrix, this.m_texture, Color.White, true, environmentData);
		}

		// Token: 0x04000005 RID: 5
		public const int Index = 415;

		// Token: 0x04000006 RID: 6
		public Texture2D m_texture;
	}
}
