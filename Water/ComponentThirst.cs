using System;
using Engine;
using Engine.Input;
using Engine.Media;
using GameEntitySystem;
using TemplatesDatabase;

namespace Game
{
	public class ComponentThirst : Component, IUpdateable
	{
		public float Water
		{
			get
			{
				return this.m_water;
			}
			set
			{
				this.m_water = MathUtils.Saturate(value);
			}
		}
		
		public ValueBarWidget WaterBarWidget { get; set; }
		public ButtonWidget DrinkButton;
		
		public UpdateOrder UpdateOrder
		{
			get
			{
				return UpdateOrder.Default;
			}
		}

		
		public void Update(float dt)
		{
			this.WaterBarWidget.Value = this.Water;
			this.Test();
		}

		public override void Load(ValuesDictionary valuesDictionary, IdToEntityMap idToEntityMap)
		{
			this.m_componentPlayer = base.Entity.FindComponent<ComponentPlayer>(true);
			this.Water = valuesDictionary.GetValue<float>("Water");
			this.WaterBarWidget = new ValueBarWidget();
			this.WaterBarWidget.LayoutDirection = LayoutDirection.Horizontal;
			this.WaterBarWidget.HorizontalAlignment = WidgetAlignment.Center;
			this.WaterBarWidget.VerticalAlignment = WidgetAlignment.Near;
			this.WaterBarWidget.Margin = new Vector2(0f, 0f);
			this.WaterBarWidget.BarsCount = 10;
			this.WaterBarWidget.BarSize = new Vector2(32f, 32f);
			this.WaterBarWidget.HalfBars = true;
			this.WaterBarWidget.LitBarColor = new Color(0, 255, 255, 255);
			this.WaterBarWidget.BarSubtexture = ContentManager.Get<Subtexture>("Textures/Water", null);
			this.WaterBarWidget.IsVisible = true;
			this.m_subsystemAudio = base.Project.FindSubsystem<SubsystemAudio>(true);
			this.WaterBarWidget.Value = this.Water;
			ContainerWidget guiWidget = this.m_componentPlayer.GuiWidget;
			guiWidget.Children.Find<CanvasWidget>("ControlsContainer", true).Children.Add(this.WaterBarWidget);
			m_componentPlayer = Entity.FindComponent<ComponentPlayer>();
			m_componentPlayer = Entity.FindComponent<ComponentPlayer>(true);
			componentMiner = Entity.FindComponent<ComponentMiner>(true);
			componentHealth = Entity.FindComponent<ComponentHealth>(true);
			componentLocomotion = Entity.FindComponent<ComponentLocomotion>(true);
			subsystemTime = Project.FindSubsystem<SubsystemTime>(true);
			m_subsystemGameInfo = Project.FindSubsystem<SubsystemGameInfo>(true);
			m_subsystemPlayers = Project.FindSubsystem<SubsystemPlayers>(true);
			componentBody = Entity.FindComponent<ComponentBody>(true);
			m_subsystemBodies = Project.FindSubsystem<SubsystemBodies>(true);
			subsystemSky = Project.FindSubsystem<SubsystemSky>(true);
			base.Load(valuesDictionary, idToEntityMap);
			try
			{
				DrinkButton = m_componentPlayer.ViewWidget.GameWidget.Children.Find<ButtonWidget>("DrinkButton", true);
			}
			catch
			{
				DrinkButton = new BevelledButtonWidget
				{
					Name = "DrinkButton",
					Text = "饮水", 
					Font = ContentManager.Get<BitmapFont>("Fonts/Pericles"), 
					Size = new Vector2(110f, 60f), 
					IsEnabled = true
				};
				m_componentPlayer.ViewWidget.GameWidget.Children.Find<StackPanelWidget>("RightControlsContainer", true).Children
					.Add(DrinkButton);
			}
		}

		public override void Save(ValuesDictionary valuesDictionary, EntityToIdMap entityToIdMap)
		{
			valuesDictionary.SetValue<float>("Water", this.Water);
		}

		public void Test()
		{
			int num = this.m_random.Int(1, 3);
			ComponentInventory componentInventory = this.m_componentPlayer.Entity.FindComponent<ComponentInventory>();
			if (m_componentPlayer.ComponentInput.PlayerInput.Move.Length() > 0f)
			{
				this.Water -= 0.00005f;
			}
			if ((m_componentPlayer.ComponentMiner.ActiveBlockValue == 1000 && Water >= 0.9f) && DrinkButton.IsClicked)
			{
				this.m_componentPlayer.ComponentGui.DisplaySmallMessage("你还不渴", Color.Red, true, true);
			}
			
			if (m_componentPlayer.ComponentBody.ImmersionDepth > 0.4f)
			{
				this.Water += 0.005f;
			}
			if (Water <= 0f)
			{
				this.m_componentPlayer.ComponentHealth.Injure(0.05f, null, false, "渴死了");
			}
			if (m_componentPlayer.ComponentMiner.ActiveBlockValue == 416 && DrinkButton.IsClicked)
			{
				Water = 1f;
				this.m_componentPlayer.ComponentMiner.RemoveActiveTool(1);
				componentInventory.AddSlotItems(componentInventory.ActiveSlotIndex, 414, 1);
				m_componentPlayer.m_subsystemAudio.PlaySound("Audio/Drink/1", 1f, 0f, this.m_componentPlayer.ComponentBody.Position, 1f, true);
			}
			if (m_componentPlayer.ComponentMiner.ActiveBlockValue == 415 && DrinkButton.IsClicked)
			{
				m_componentPlayer.ComponentGui.DisplaySmallMessage("你没有什么可以喝的", Color.Red, true, true);
			}
			if (m_componentPlayer.ComponentMiner.ActiveBlockValue == 414 && DrinkButton.IsClicked)
			{
				m_componentPlayer.ComponentGui.DisplaySmallMessage("你没有什么可以喝的", Color.Red, true, true);
			}
		}

		private float m_water;

		public ComponentPlayer m_componentPlayer;

		public ComponentMiner componentMiner;
		
		public ComponentHealth componentHealth;
		
		public ComponentLocomotion componentLocomotion;
		
		public SubsystemTime subsystemTime;
		
		public SubsystemGameInfo m_subsystemGameInfo;
		
		public SubsystemPlayers m_subsystemPlayers;
		
		public SubsystemBodies m_subsystemBodies;
		
		public SubsystemSky subsystemSky;

		public ComponentBody componentBody;

		public Random m_random = new Random();

		public Block block;

		public SubsystemAudio m_subsystemAudio;
	}
}
